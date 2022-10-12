using Refit;
using RestApiClientTemplate.Api.Structures;

namespace RestApiClientTemplate.Api;

internal interface IApi<T>
{
    [Get("/")]
    Task<GetResponse> GetAsync([Query] string name, CancellationToken cancellationToken = default);
}

