using CountryInfo.Core.Enums;

namespace CountryInfo.Core.Common
{
    /// <summary>
    /// Represents a standard result containing response code and message.
    /// </summary>
    public class NewResult
    {
        /// <summary>
        /// Gets or sets the HTTP response code.
        /// </summary>
        public HttpResponseCode ResponseCode { get; set; }

        /// <summary>
        /// Gets or sets the response message.
        /// </summary>
        public string ResponseMsg { get; set; }
    }

    /// <summary>
    /// Represents a standard result containing response code, message, and additional data.
    /// </summary>
    /// <typeparam name="T">The type of the response details.</typeparam>
    public class NewResult<T> : NewResult
    {
        /// <summary>
        /// Gets or sets the detailed response data.
        /// </summary>
        public T ResponseDetails { get; set; }

        /// <summary>
        /// Creates a successful result with the specified data and message.
        /// </summary>
        /// <param name="instance">The data to be included in the response.</param>
        /// <param name="message">The success message.</param>
        /// <returns>A successful <see cref="NewResult{T}"/> instance.</returns>
        public static NewResult<T> Success(T instance, string message = "Successful")
        {
            return new NewResult<T>
            {
                ResponseCode = HttpResponseCode.Success,
                ResponseDetails = instance,
                ResponseMsg = message,
            };
        }

        /// <summary>
        /// Creates a failed result with the specified data and message.
        /// </summary>
        /// <param name="instance">The data to be included in the response.</param>
        /// <param name="message">The failure message.</param>
        /// <returns>A failed <see cref="NewResult{T}"/> instance.</returns>
        public static NewResult<T> Failed(T instance, string message = "Bad Request")
        {
            return new NewResult<T>
            {
                ResponseCode = HttpResponseCode.BadRequest,
                ResponseDetails = instance,
                ResponseMsg = message,
            };
        }

        /// <summary>
        /// Creates a not found result with the specified data and message.
        /// </summary>
        /// <param name="instance">The data to be included in the response.</param>
        /// <param name="message">The not found message.</param>
        /// <returns>A not found <see cref="NewResult{T}"/> instance.</returns>
        public static NewResult<T> NotFound(T instance, string message = "Not Found")
        {
            return new NewResult<T>
            {
                ResponseCode = HttpResponseCode.NotFound,
                ResponseDetails = instance,
                ResponseMsg = message,
            };
        }

        /// <summary>
        /// Creates an internal server error result with the specified data and message.
        /// </summary>
        /// <param name="instance">The data to be included in the response.</param>
        /// <param name="message">The internal server error message.</param>
        /// <returns>An internal server error <see cref="NewResult{T}"/> instance.</returns>
        public static NewResult<T> InternalServerError(T instance, string message = "Internal Server Error")
        {
            return new NewResult<T>
            {
                ResponseCode = HttpResponseCode.InternalServerError,
                ResponseDetails = instance,
                ResponseMsg = message,
            };
        }
    }
}