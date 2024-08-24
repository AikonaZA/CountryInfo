namespace CountryInfo.Core.Enums
{
    public enum HttpResponseCode
    {
        Success = 200,                // OK
        Created = 201,                // Created
        NoContent = 204,              // No Content
        BadRequest = 400,             // Bad Request
        Unauthorized = 401,           // Unauthorized
        Forbidden = 403,              // Forbidden
        NotFound = 404,               // Not Found
        Conflict = 409,               // Conflict
        InternalServerError = 500,    // Internal Server Error
        NotImplemented = 501,         // Not Implemented
        ServiceUnavailable = 503      // Service Unavailable
    }
}
