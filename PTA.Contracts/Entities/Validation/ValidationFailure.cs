namespace PTA.Contracts.Entities.Validation
{
    /// <summary>
    /// Describes error for single property.
    /// </summary>
    public class ValidationFailure
    {
        /// <summary>
        /// The name of the property.
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// The formatted error message.
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
