using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.DependencyInjection;

internal sealed class OptionsConfigurationOptionsValidateOptions<T> : IValidateOptions<OptionsConfigurationOptions<T>>
{
    private readonly OptionsConfigurationOptionsValidator<T> validator;

    public OptionsConfigurationOptionsValidateOptions(OptionsConfigurationOptionsValidator<T> validator)
    {
        this.validator = validator;
    }

    public ValidateOptionsResult Validate(string name, OptionsConfigurationOptions<T> options)
    {
        var result = this.validator.Validate(options);
        if (result.IsValid)
        {
            return ValidateOptionsResult.Success;
        }
        return ValidateOptionsResult.Fail(result.ToString());
    }
}