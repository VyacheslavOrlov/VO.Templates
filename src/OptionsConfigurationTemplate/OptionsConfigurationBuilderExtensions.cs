using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace OptionsConfigurationTemplate;

public static class OptionsConfigurationBuilderExtensions
{
    public static IBuilder<T> AddOptionsConfiguration<T>(this IBuilder<T> builder, Action<IServiceProvider, OptionsConfigurationOptions<T>> options)
    {
        builder.Services.TryAddSingleton<OptionsConfigurationOptionsValidator<T>>();
        builder.Services.TryAddSingleton<IValidateOptions<OptionsConfigurationOptions<T>>, OptionsConfigurationOptionsValidateOptions<T>>();
        builder.Services
            .AddOptions<OptionsConfigurationOptions<T>>()
            .ValidateOnStart()
            .PostConfigure<IServiceProvider>((o, sp) => options?.Invoke(sp, o));
        return builder;
    }

    public static IBuilder<T> AddOptionsConfiguration<T>(this IBuilder<T> builder, Action<OptionsConfigurationOptions<T>>? options = default)
        => builder.AddOptionsConfiguration((_, opt) => options?.Invoke(opt));

    public static IBuilder<T> AddOptionsConfiguration<T, TDep1>(this IBuilder<T> builder, Action<TDep1, OptionsConfigurationOptions<T>> options)
        where TDep1 : class
        => builder.AddOptionsConfiguration((sp, opt) => options?.Invoke(sp.GetRequiredService<TDep1>(), opt));

    public static IBuilder<T> AddOptionsConfiguration<T, TDep1, TDep2>(this IBuilder<T> builder, Action<TDep1, TDep2, OptionsConfigurationOptions<T>> options)
        where TDep1 : class
        where TDep2 : class
        => builder.AddOptionsConfiguration((sp, opt) => options?.Invoke(
            sp.GetRequiredService<TDep1>(),
            sp.GetRequiredService<TDep2>(),
            opt));

    public static IBuilder<T> AddOptionsConfiguration<T, TDep1, TDep2, TDep3>(this IBuilder<T> builder, Action<TDep1, TDep2, TDep3, OptionsConfigurationOptions<T>> options)
        where TDep1 : class
        where TDep2 : class
        where TDep3 : class
        => builder.AddOptionsConfiguration((sp, opt) => options?.Invoke(
            sp.GetRequiredService<TDep1>(),
            sp.GetRequiredService<TDep2>(),
            sp.GetRequiredService<TDep3>(),
            opt));
}
