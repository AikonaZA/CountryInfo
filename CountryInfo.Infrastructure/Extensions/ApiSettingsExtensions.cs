using CountryInfo.Infrastructure.Configuration;

namespace CountryInfo.Infrastructure.Extensions
{
    public static class ApiSettingsExtensions
    {
        /// <summary>
        /// Constructs the full URL for the given API endpoint by combining the base URL, API version, and the specified endpoint.
        /// </summary>
        /// <param name="settings">The RestCountriesApiSettings object containing the base URL and API version.</param>
        /// <param name="endpoint">The specific API endpoint to be appended to the base URL and version.</param>
        /// <returns>The full URL as a string, combining the base URL, API version, and endpoint.</returns>
        public static string GetFullUrl(this RestCountriesApiSettings settings, string endpoint)
        {
            return $"{settings.BaseUrl}{settings.ApiVersion}/{endpoint}";
        }
    }
}