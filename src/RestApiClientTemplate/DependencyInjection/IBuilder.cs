using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection;

public interface IBuilder<T>
{
    IServiceCollection Services { get; }
    IHttpClientBuilder HttpClientBuilder { get; }
}
