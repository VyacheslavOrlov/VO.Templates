namespace Microsoft.Extensions.DependencyInjection;

public interface IBuilder<T>
{
    IServiceCollection Services { get; }
}
