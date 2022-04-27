using PTA.Contracts.Entities.Result;
using PTA.Services.Database.Interfaces.Validation;
using System;

namespace PTA.Services.Database.Interfaces.Providers
{
    public class BaseProvider
    {
        protected readonly IValidationProvider validationProvider;

        public BaseProvider(IValidationProvider validationProvider)
        {
            this.validationProvider = validationProvider;
        }

        public TResult ExecuteIfValidationSucceeded<TObject, TResult>(TObject validatedObject, Func<TResult> action) where TResult : BaseOperationResult
        {
            var validationResult = validationProvider.Validate(validatedObject);
            if (!validationResult.IsValid)
                return (TResult)Activator.CreateInstance(typeof(TResult), new object[] { validationResult.Errors });
            return action();

        }
    }
}
