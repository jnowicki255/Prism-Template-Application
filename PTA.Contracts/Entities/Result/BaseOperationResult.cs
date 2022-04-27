using PTA.Contracts.Entities.Validation;
using PTA.Contracts.Properties;
using System;
using System.Linq;

namespace PTA.Contracts.Entities.Result
{
    /// <summary>
    /// Result of some operation that returns no value.
    /// </summary>
    public class BaseOperationResult
    {
        /// <summary>
        /// True when the operation ends with success, required.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Errors occured while operation, optional.
        /// </summary>
        public ErrorCollection Errors { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public BaseOperationResult() { }

        /// <summary>
        /// Parameterized constructor for single errors.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="errorContext"></param>
        public BaseOperationResult(string errorMessage, string errorContext = null)
        {
            Errors = new ErrorCollection
            {
                ErrorMessage = Resources.CheckErrorList,
                Errors = new Error[]
                {
                    new Error
                    {
                        Context = errorContext,
                        Message = errorMessage
                    }
                }
            };
        }

        /// <summary>
        /// Parameterized constructor for single errors with custom summary message.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="errorContext"></param>
        public BaseOperationResult(string errorSummary, string errorMessage, string errorContext = null)
        {
            Errors = new ErrorCollection
            {
                ErrorMessage = errorSummary,
                Errors = new Error[]
                {
                    new Error
                    {
                        Context = errorContext,
                        Message = errorMessage
                    }
                }
            };
        }

        /// <summary>
        /// Parameterized constructor for exceptions.
        /// </summary>
        /// <param name="ex"></param>
        public BaseOperationResult(Exception ex)
        {
            Errors = new ErrorCollection
            {
                ErrorMessage = Resources.ExceptionOccured,
                Errors = new Error[]
                {
                    new Error
                    {
                        Message = ex.Message,
                        Context = ex.GetType().Name
                    }
                }
            };
        }

        /// <summary>
        /// Parameterized constructor for validation errors.
        /// </summary>
        /// <param name="errors"></param>
        public BaseOperationResult(ValidationFailure[] errors)
        {
            Errors = new ErrorCollection
            {
                ErrorMessage = Resources.ValidationErrorOccured,
                Errors = errors
                    .Select(x => new Error
                    {
                        Context = x.PropertyName,
                        Message = x.ErrorMessage
                    }).ToArray()
            };
        }

        /// <summary>
        /// Parameterized constructor for already prepared error collection.
        /// </summary>
        /// <param name="errorCollection"></param>
        public BaseOperationResult(ErrorCollection errorCollection)
        {
            Errors = errorCollection;
        }

        /// <summary>
        /// Returns an instance of result for successful operation.
        /// </summary>
        public static BaseOperationResult SuccessfulOperation
            => new()
            {
                Success = true
            };
    }
}
