using FluentValidation;
using PTA.Contracts.Entities.Validation;
using PTA.Services.Database.Interfaces.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PTA.Services.Database.Validators
{
    public class ValidationProvider : IValidationProvider
    {
        private Dictionary<Type, IValidator> validators;

        public ValidationProvider(bool forceEnglishLanguage = false)
        {
            if (forceEnglishLanguage)
            {
                ValidatorOptions.Global.LanguageManager.Enabled = false;
            }
            InitializeValidatorsFromAssembly();
        }

        /// <summary>
        /// Validates given object.
        /// Ruleset is destined for complex entities, most objects are quite simple and don't need it.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validatedObject"></param>
        /// <param name="ruleset"></param>
        /// <returns></returns>
        public ValidationResult Validate<T>(T validatedObject, string ruleset = null)
        {
            if (validators.TryGetValue(typeof(T), out IValidator validator)
                && validator is IValidator<T> customValidator)
            {
                var validationResult = customValidator.Validate(validatedObject,
                    options =>
                    {
                        if (ruleset != null)
                        {
                            options.IncludeRuleSets(ruleset);
                        }
                    });
                return MapResult(validationResult);
            }
            else
            {
                throw new InvalidOperationException("Validator not found.");
            }
        }

        /// <summary>
        /// Allows to register classic and generic validatators, e.g. NewRobotTypeValidator.
        /// </summary>
        private void InitializeValidatorsFromAssembly()
        {
            var tmp = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => x.GetInterfaces().Any(y => y.IsGenericType && y.Name == "IValidator`1"))
                .Select(x => new
                {
                    ValidatedType = x.ContainsGenericParameters
                        ? x.GetInterface("IValidator`1").GenericTypeArguments[0].BaseType
                        : x.GetInterface("IValidator`1").GenericTypeArguments[0],
                    Validator = x.ContainsGenericParameters
                        ? (IValidator)Activator.CreateInstance(x.MakeGenericType(x.GetInterface("IValidator`1").GenericTypeArguments[0].BaseType))
                        : (IValidator)Activator.CreateInstance(x)
                }).ToList();

            validators = tmp
                .ToDictionary(x => x.ValidatedType, x => x.Validator);
        }

        private ValidationResult MapResult(FluentValidation.Results.ValidationResult validationResult)
        {
            return new ValidationResult
            {
                IsValid = validationResult.IsValid,
                Errors = validationResult?.Errors?
                    .Select(x => new ValidationFailure
                    {
                        ErrorMessage = x.ErrorMessage,
                        PropertyName = x.PropertyName
                    })
                    .ToArray()
            };
        }
    }
}
