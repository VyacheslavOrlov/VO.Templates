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

    private async Task<TResult> HandleAsync<TResult>(Func<Task<TResult>> func)
    {
        try
        {
            return await func();
        }
        catch (AggregateException exception)
        {
            foreach (var innerException in exception.InnerExceptions)
            {

            }
            if (exception.InnerException is Refit.ValidationApiException)
            {

            }
            throw;
        }
    }

    private void HandleException(Exception exception)
    {
        var t = new Dictionary<string, string>();
        
        if (exception is Refit.ValidationApiException validationApiException)
        {

        }
        if (exception is Refit.ApiException apiException)
        {

        }
    }

    private async Task HandleAsync(Func<Task> func)
    {
        try
        {
            await func();
        }
        catch (AggregateException exception)
        {
            foreach (var innerException in exception.InnerExceptions)
            {

            }
            throw;
        }
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
