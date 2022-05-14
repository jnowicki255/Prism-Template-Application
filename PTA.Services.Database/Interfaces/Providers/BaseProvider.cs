using PTA.Contracts.Entities.Result;
using PTA.Repository.Interfaces.Repos;
using PTA.Services.Database.Interfaces.Validation;
using System;

namespace PTA.Services.Database.Interfaces.Providers
{
    public class BaseProvider
    {
        protected readonly IValidationProvider validationProvider;
        protected readonly IRepository repository;

        public BaseProvider(IRepository repository, IValidationProvider validationProvider)
        {
            this.validationProvider = validationProvider;
            this.repository = repository;
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
