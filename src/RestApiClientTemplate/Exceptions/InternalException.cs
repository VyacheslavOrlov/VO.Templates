using System.Net;
using System.Runtime.Serialization;

namespace RestApiClientTemplate.Exceptions;

/// <summary>
/// InternalException
/// </summary>
/// <seealso cref="System.Exception" />
[Serializable]
public sealed class InternalException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InternalException"/> class.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="content">The content.</param>
    /// <param name="statusCode">The status code.</param>
    /// <param name="innerException">The inner exception.</param>
    public InternalException(string message, string? content, HttpStatusCode statusCode, Exception innerException) : base(message, innerException)
    {
        this.Content = content;
        this.StatusCode = statusCode;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InternalException"/> class.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (<see langword="Nothing" /> in Visual Basic) if no inner exception is specified.</param>
    public InternalException(string message, Exception innerException) : base(message, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InternalException"/> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public InternalException(string message) : base(message)
    {

    }

    /// <summary>
    /// Gets the content.
    /// </summary>
    /// <value>
    /// The content.
    /// </value>
    public string? Content { get; }
    /// <summary>
    /// Gets the status code.
    /// </summary>
    /// <value>
    /// The status code.
    /// </value>
    public HttpStatusCode? StatusCode { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="InternalException"/> class.
    /// </summary>
    /// <param name="serializationInfo">The serialization information.</param>
    /// <param name="streamingContext">The streaming context.</param>
    private InternalException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext) { }

    /// <summary>
    /// When overridden in a derived class, sets the <see cref="T:System.Runtime.Serialization.SerializationInfo" /> with information about the exception.
    /// </summary>
    /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
    /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        base.GetObjectData(info, context);
    }
}
