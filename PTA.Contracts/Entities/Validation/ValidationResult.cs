namespace PTA.Contracts.Entities.Validation
{
    /// <summary>
    /// Validation result of some object.
    /// </summary>
    public class ValidationResult
    {
        /// <summary>
        /// True means that the validated object is OK.
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// The collection of errors that caused a failure.
        /// </summary>
        public ValidationFailure[] Errors { get; set; }
    }
}
