using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Microsoft.Extensions.DependencyInjection;

public sealed class HealthCheckOptions<T>
{
    public string? Name { get; set; }
    public HealthStatus? FailureStatus { get; set; }
    public IEnumerable<string>? Tags { get; set; }
    public TimeSpan? Timeout { get; set; }
}
