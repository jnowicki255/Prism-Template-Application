using PTA.Contracts.Entities.Validation;
using System;

namespace PTA.Contracts.Entities.Result
{
    /// <summary>
    /// Result of some operation that returns value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class OperationResult<T> : BaseOperationResult
    {
        /// <summary>
        /// The result of the operation.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Parameterized constructor for successful operations.
        /// </summary>
        /// <param name="content"></param>
        public OperationResult(T content)
        {
            Success = true;
            Value = content;
        }

        /// <summary>
        /// Parameterized constructor for single errors.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="errorContext"></param>
        public OperationResult(string errorMessage, string errorContext) : base(errorMessage, errorContext)
        {
        }

        /// <summary>
        /// Parameterized constructor for validation errors.
        /// </summary>
        /// <param name="errors"></param>
        public OperationResult(ValidationFailure[] errors) : base(errors)
        {
        }

        /// <summary>
        /// Parameterized constructor for already prepared error collection.
        /// </summary>
        /// <param name="errorCollection"></param>
        public OperationResult(ErrorCollection errorCollection) : base(errorCollection)
        {
        }

        /// <summary>
        /// Parameterized constructor for exceptions.
        /// </summary>
        /// <param name="ex"></param>
        public OperationResult(Exception exception) : base(exception)
        {
        }
    }
}
