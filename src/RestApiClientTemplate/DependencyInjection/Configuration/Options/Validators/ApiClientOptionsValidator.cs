using FluentValidation;

namespace Microsoft.Extensions.DependencyInjection;

internal sealed class ApiClientOptionsValidator<T> : AbstractValidator<ApiClientOptions<T>>
{
    public ApiClientOptionsValidator()
    {
        RuleFor(config => config.BaseAddress).NotEmpty();
    }
}
