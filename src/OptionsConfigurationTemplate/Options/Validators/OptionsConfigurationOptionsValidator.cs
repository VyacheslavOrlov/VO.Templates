using FluentValidation;

namespace Microsoft.Extensions.DependencyInjection;

internal sealed class OptionsConfigurationOptionsValidator<T> : AbstractValidator<OptionsConfigurationOptions<T>>
{
    public OptionsConfigurationOptionsValidator()
    {
        RuleFor(config => config.BaseAddress).NotEmpty();
    }
}
