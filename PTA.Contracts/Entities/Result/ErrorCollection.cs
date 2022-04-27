namespace PTA.Contracts.Entities.Result
{
    /// <summary>
    /// Errors occured while some operation
    /// </summary>
    public class ErrorCollection
    {
        /// <summary>
        /// Short description of error, required
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Contains error details, optional
        /// </summary>
        public Error[] Errors { get; set; }
    }
}
