using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.DependencyInjection;

internal sealed class ApiClientOptionsValidateOptions<T> : IValidateOptions<ApiClientOptions<T>>
{
    private readonly ApiClientOptionsValidator<T> validator;

    public ApiClientOptionsValidateOptions(ApiClientOptionsValidator<T> validator)
    {
        this.validator = validator;
    }

    public ValidateOptionsResult Validate(string name, ApiClientOptions<T> options)
    {
        var result = this.validator.Validate(options);
        if (result.IsValid)
        {
            return ValidateOptionsResult.Success;
        }
        return ValidateOptionsResult.Fail(result.ToString());
    }
}