using Microsoft.Extensions.Logging;
using RestApiClientTemplate.Implementation.Decorators.ErrorHandling.Extensions;
using RestApiClientTemplate.Structures;

namespace RestApiClientTemplate.Implementation.Decorators.ErrorHandling;

internal sealed class ApiClientErrorHandlingDecorator<T> : IApiClient<T>
{
    private readonly IApiClient<T> _client;
    private readonly ILogger<ApiClientErrorHandlingDecorator<T>> _logger;
    public ApiClientErrorHandlingDecorator(IApiClient<T> client, ILogger<ApiClientErrorHandlingDecorator<T>> logger)
    {
        _client = client;
        _logger = logger;
    }

    public Task<ExampletResult> MethodExampleAsync(string name, CancellationToken cancellationToken = default)
        => HandleAsync(() => _client.MethodExampleAsync(name, cancellationToken));

    private Task<TResult> HandleAsync<TResult>(Func<Task<TResult>> func)
    {
        return func().ContinueWith(r =>
        {
            Handle(r);
            return r.Result;
        });
    }
    private Task HandleAsync(Func<Task> func)
    {
        return func().ContinueWith(r => {
            Handle(r);
            return r;
        });
    }

    private void Handle(Task task)
    {
        if (task.IsFaulted)
        {
            task.Exception?.InnerException
                .HandleNoException()
                .HandleInnerExceptions()
                .HandleValidationExceptions(_logger)
                .HandleBadRequestApiException(_logger)
                .HandleUnauthorizedApiException(_logger)
                .HandleForbiddenApiException(_logger)
                .HandleApiException(_logger)
                .HandleException(_logger);
        }
    }
}
