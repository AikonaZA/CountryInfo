namespace CountryInfo.Core.Enums
{
    /// <summary>
    /// Represents the standard HTTP response codes used to indicate the result of an API call.
    /// </summary>
    public enum HttpResponseCode
    {
        /// <summary>
        /// The request has succeeded. Corresponds to HTTP status code 200.
        /// </summary>
        Success = 200,

        /// <summary>
        /// The server successfully processed the request, but is not returning any content. Corresponds to HTTP status code 204.
        /// </summary>
        NoContent = 204,

        /// <summary>
        /// The server could not understand the request due to invalid syntax. Corresponds to HTTP status code 400.
        /// </summary>
        BadRequest = 400,

        /// <summary>
        /// The server can not find the requested resource. Corresponds to HTTP status code 404.
        /// </summary>
        NotFound = 404,

        /// <summary>
        /// The server has encountered a situation it doesn't know how to handle. Corresponds to HTTP status code 500.
        /// </summary>
        InternalServerError = 500,

        /// <summary>
        /// The request method is not supported by the server and cannot be handled. Corresponds to HTTP status code 501.
        /// </summary>
        NotImplemented = 501,
    }
}