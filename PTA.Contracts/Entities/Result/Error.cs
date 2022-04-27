namespace PTA.Contracts.Entities.Result
{
    /// <summary>
    /// Single error
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Parametrized constructor 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="context"></param>
        public Error(string message, string context)
        {
            Message = message;
            Context = context;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Error() { }

        /// <summary>
        /// Error desription readable for users, required
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Error context (e.g. validated property name, operation name), optional
        /// </summary>
        public string Context { get; set; }
    }
}
