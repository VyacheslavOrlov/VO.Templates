using RestApiClientTemplate.Structures;

namespace RestApiClientTemplate;

public interface IRestApiClient
{
    Task<ExampletResult> MethodExampleAsync(string name, CancellationToken cancellationToken = default);
}

public interface IRestApiClient<T> : IRestApiClient 
{
}


