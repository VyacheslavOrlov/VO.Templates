namespace Microsoft.Extensions.DependencyInjection;

public sealed class ApiClientOptions<T>
{
    public Uri BaseAddress { get; set; } = default!;
}
