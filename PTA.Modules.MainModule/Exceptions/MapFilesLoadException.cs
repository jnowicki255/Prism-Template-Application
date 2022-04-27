using System;
using System.Runtime.Serialization;

namespace PTA.Modules.MainModule.Exceptions
{
    /// <summary>
    /// The exception that is thrown when an error occurs while file load attempt.
    /// </summary>
    [Serializable]
    public class MapFilesLoadException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapFilesLoadException"/> class.
        /// </summary>
        public MapFilesLoadException() : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MapFilesLoadException"/> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        protected MapFilesLoadException(SerializationInfo info, StreamingContext context) : base(info, context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MapFilesLoadException"/> class with the specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public MapFilesLoadException(string message) : base(message)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MapFilesLoadException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The inner exception reference.</param>
        public MapFilesLoadException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
