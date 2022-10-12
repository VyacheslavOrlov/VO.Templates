using Microsoft.Extensions.Options;
using Refit;
using RestApiClientTemplate;
using RestApiClientTemplate.Implementation;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IBuilder<IDefault> AddApiClient(this IServiceCollection services, Action<ApiClientOptions<IDefault>>? configure = default)
    {
        services.AddSingleton<IApiClient, DefaultApiClient<IDefault>>();
        return services.AddApiClient<IDefault>(configure);
    }

    public static IBuilder<T> AddApiClient<T>(this IServiceCollection services, Action<ApiClientOptions<T>>? configure = default)
    {
        IHttpClientBuilder httpClientBuilder = services.AddRefitClient<IApiClient<T>>()
            .ConfigureHttpClient<IOptionsMonitor<ApiClientOptions<T>>>((options, client) => client.BaseAddress = options.CurrentValue.BaseAddress);

        services.AddSingleton<IApiClient<T>, DefaultApiClient<T>>();
        var builder = new DefaultBuilder<T>(services, httpClientBuilder)
            .AddApiClientOptions(configure);
        return builder;
    }
}
