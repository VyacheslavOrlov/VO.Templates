using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.DependencyInjection;

public static class CoreBuilderExtensions
{
    public static IBuilder<T> AddApiClientOptions<T>(this IBuilder<T> builder, Action<IServiceProvider, ApiClientOptions<T>> options)
    {
        builder.Services.TryAddSingleton<ApiClientOptionsValidator<T>>();
        builder.Services.TryAddSingleton<IValidateOptions<ApiClientOptions<T>>, ApiClientOptionsValidateOptions<T>>();
        builder.Services
            .AddOptions<ApiClientOptions<T>>()
            .ValidateOnStart()
            .PostConfigure<IServiceProvider>((o, sp) => options?.Invoke(sp, o));
        return builder;
    }

    public static IBuilder<T> AddApiClientOptions<T>(this IBuilder<T> builder, Action<ApiClientOptions<T>>? options = default)
        => builder.AddApiClientOptions((_, opt) => options?.Invoke(opt));

    public static IBuilder<T> AddApiClientOptions<T, TDep1>(this IBuilder<T> builder, Action<TDep1, ApiClientOptions<T>> options)
        where TDep1 : class
        => builder.AddApiClientOptions((sp, opt) => options?.Invoke(sp.GetRequiredService<TDep1>(), opt));

    public static IBuilder<T> AddApiClientOptions<T, TDep1, TDep2>(this IBuilder<T> builder, Action<TDep1, TDep2, ApiClientOptions<T>> options)
        where TDep1 : class
        where TDep2 : class
        => builder.AddApiClientOptions((sp, opt) => options?.Invoke(
            sp.GetRequiredService<TDep1>(),
            sp.GetRequiredService<TDep2>(),
            opt));

    public static IBuilder<T> AddApiClientOptions<T, TDep1, TDep2, TDep3>(this IBuilder<T> builder, Action<TDep1, TDep2, TDep3, ApiClientOptions<T>> options)
        where TDep1 : class
        where TDep2 : class
        where TDep3 : class
        => builder.AddApiClientOptions((sp, opt) => options?.Invoke(
            sp.GetRequiredService<TDep1>(),
            sp.GetRequiredService<TDep2>(),
            sp.GetRequiredService<TDep3>(),
            opt));
}
