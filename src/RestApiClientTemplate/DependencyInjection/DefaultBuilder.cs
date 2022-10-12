namespace Microsoft.Extensions.DependencyInjection;

internal sealed class DefaultBuilder<T> : IBuilder<T>
{
    public DefaultBuilder(IServiceCollection services, IHttpClientBuilder httpClientBuilder)
    {
        this.Services = services;
        this.HttpClientBuilder = httpClientBuilder;
    }

    public IServiceCollection Services { get; }

    public IHttpClientBuilder HttpClientBuilder { get; }
}
