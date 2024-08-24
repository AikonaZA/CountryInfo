using CountryInfo.Core.Enums;

namespace CountryInfo.Core.Common
{
    public class NewResult
    {
        public HttpResponseCode ResponseCode { get; set; }
        public string ResponseMsg { get; set; }
    }

    public class NewResult<T> : NewResult
    {
        public T ResponseDetails { get; set; }

        public static NewResult<T> Success(T instance, string message = "Successful")
        {
            return new NewResult<T>
            {
                ResponseCode = HttpResponseCode.Success,
                ResponseDetails = instance,
                ResponseMsg = message,
            };
        }

        public static NewResult<T> Failed(T instance, string message = "Bad Request")
        {
            return new NewResult<T>
            {
                ResponseCode = HttpResponseCode.BadRequest,
                ResponseDetails = instance,
                ResponseMsg = message,
            };
        }

        public static NewResult<T> Unauthorized(T instance, string message = "Unauthorized")
        {
            return new NewResult<T>
            {
                ResponseCode = HttpResponseCode.Unauthorized,
                ResponseDetails = instance,
                ResponseMsg = message,
            };
        }

        public static NewResult<T> Forbidden(T instance, string message = "Forbidden")
        {
            return new NewResult<T>
            {
                ResponseCode = HttpResponseCode.Forbidden,
                ResponseDetails = instance,
                ResponseMsg = message,
            };
        }

        public static NewResult<T> NotFound(T instance, string message = "Not Found")
        {
            return new NewResult<T>
            {
                ResponseCode = HttpResponseCode.NotFound,
                ResponseDetails = instance,
                ResponseMsg = message,
            };
        }

        public static NewResult<T> Conflict(T instance, string message = "Conflict")
        {
            return new NewResult<T>
            {
                ResponseCode = HttpResponseCode.Conflict,
                ResponseDetails = instance,
                ResponseMsg = message,
            };
        }

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