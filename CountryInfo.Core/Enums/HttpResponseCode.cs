namespace CountryInfo.Core.Enums
{
    public enum HttpResponseCode
    {
        Success = 200,                // OK
        NoContent = 204,              // No Content
        BadRequest = 400,             // Bad Request
        NotFound = 404,               // Not Found
        InternalServerError = 500,    // Internal Server Error
        NotImplemented = 501,         // Not Implemented
    }
}