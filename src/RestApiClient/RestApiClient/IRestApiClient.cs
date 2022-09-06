using RestApiClient.Structures;

namespace RestApiClient;

public interface IRestApiClient
{
    Task<ExampletResult> MethodExampleAsync(string name, CancellationToken cancellationToken = default);
}

public interface IRestApiClient<T> : IRestApiClient
{
}


