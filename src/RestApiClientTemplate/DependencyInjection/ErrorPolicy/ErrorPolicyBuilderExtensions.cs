using Polly;

namespace Microsoft.Extensions.DependencyInjection;

public static class ErrorPolicyBuilderExtensions
{
    public static IBuilder<T> AddErrorPolicy<T>(this IBuilder<T> builder)
    {
        builder.HttpClientBuilder
            .AddTransientHttpErrorPolicy(builder =>
                    builder.WaitAndRetryAsync(2, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))));
        return builder;
    }
}
