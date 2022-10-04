using VO.Templates.RestApiClient.Structures;

namespace VO.Templates.RestApiClient;

public interface IRestApiClient
{
    Task<ExampletResult> MethodExampleAsync(string name, CancellationToken cancellationToken = default);
}

public interface IRestApiClient<T> : IRestApiClient 
{
}


