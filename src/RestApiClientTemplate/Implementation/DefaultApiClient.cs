using RestApiClientTemplate.Api;
using RestApiClientTemplate.Implementation.Mappers;
using RestApiClientTemplate.Structures;

namespace RestApiClientTemplate.Implementation;

internal sealed class DefaultApiClient<T> : IApiClient<T>
{
    private readonly IApi<T> _api;

    public DefaultApiClient(IApi<T> api)
    {
        _api = api;
    }
    public async Task<ExampletResult> MethodExampleAsync(string name, CancellationToken cancellationToken = default)
    {
        var getResponse = await _api.GetAsync(name, cancellationToken);
        return getResponse.ToExampletResult();
    }
}
