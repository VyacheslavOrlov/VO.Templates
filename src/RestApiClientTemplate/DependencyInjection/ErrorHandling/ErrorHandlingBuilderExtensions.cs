using Microsoft.Extensions.Logging;
using RestApiClientTemplate;
using RestApiClientTemplate.Implementation.Decorators.ErrorHandling;

namespace Microsoft.Extensions.DependencyInjection;

internal static class ErrorHandlingBuilderExtensions
{
    public static IBuilder<T> AddErrorHandling<T>(this IBuilder<T> builder, Action<IServiceProvider, ErrorHandlingOptions<T>> options)
    {
        //builder.Services.TryAddSingleton<ErrorHandlingOptionsValidator<T>>();
        //builder.Services.TryAddSingleton<IValidateOptions<ErrorHandlingOptions<T>>, ErrorHandlingOptionsValidateOptions<T>>();
        builder.Services
            .AddOptions<ErrorHandlingOptions<T>>()
            .ValidateOnStart()
            .PostConfigure<IServiceProvider>((o, sp) => options?.Invoke(sp, o));
        builder.Services.Decorate<IApiClient<T>>((inner, sp) => new ApiClientErrorHandlingDecorator<T>(inner, sp.GetRequiredService<ILogger<ApiClientErrorHandlingDecorator<T>>>()));
        return builder;
    }

    public static IBuilder<T> AddErrorHandling<T>(this IBuilder<T> builder, Action<ErrorHandlingOptions<T>>? options = default)
        => builder.AddErrorHandling((_, opt) => options?.Invoke(opt));
}
