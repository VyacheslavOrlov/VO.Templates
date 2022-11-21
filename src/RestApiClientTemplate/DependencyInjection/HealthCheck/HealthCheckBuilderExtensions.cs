using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.DependencyInjection;

public static class HealthCheckBuilderExtensions
{
    public static IBuilder<T> AddHealthCheck<T>(this IBuilder<T> builder, Action<HealthCheckOptions<T>>? options)
    {
        HealthCheckOptions<T> opt = new();
        options?.Invoke(opt);
        builder.Services
            .AddHealthChecks()
            .AddUrlGroup(
                uriProvider: sp => 
                {
                    var baseAddress = sp.GetRequiredService<IOptionsMonitor<ApiClientOptions<T>>>().CurrentValue.BaseAddress;
                    return new Uri($"{baseAddress.AbsoluteUri.TrimEnd('/')}/pingpong");
                },
                name: opt.Name,
                failureStatus: opt.FailureStatus,
                tags: opt.Tags,
                timeout: opt.Timeout);

        return builder;
    }
}
