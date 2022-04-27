using PTA.Contracts.Entities.Validation;

namespace PTA.Services.Database.Interfaces.Validation
{
    public interface IValidationProvider
    {
        ValidationResult Validate<T>(T validatedObject, string ruleset = null);
    }
}
