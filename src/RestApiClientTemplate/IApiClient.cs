using RestApiClientTemplate.Structures;

namespace RestApiClientTemplate;

public interface IApiClient
{
    Task<ExampletResult> MethodExampleAsync(string name, CancellationToken cancellationToken = default);
}

public interface IApiClient<T> : IApiClient 
{
}


