using CountryInfo.Core.Common;
using CountryInfo.Core.Entities;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CountryInfo.Infrastructure.Services
{
    /// <summary>
    /// Provides a base class for API clients that handle common HTTP request operations.
    /// </summary>
    public abstract class BaseApiClient
    {
        protected readonly HttpClient _httpClient;

        protected BaseApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Sends an HTTP GET request to the specified URL and processes the response to retrieve a list of countries.
        /// </summary>
        /// <param name="fullUrl">The full URL to send the HTTP GET request to.</param>
        /// <returns>A <see cref="NewResult{T}"/> containing a list of countries or an appropriate error message.</returns>
        protected async Task<NewResult<List<Country>>> GetCountriesAsync(string fullUrl)
        {
            try
            {
                var response = await _httpClient.GetAsync(fullUrl);

                if (!response.IsSuccessStatusCode)
                {
                    return NewResult<List<Country>>.Failed(null, $"Error occurred: {response.ReasonPhrase}");
                }

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var countries = JsonSerializer.Deserialize<List<Country>>(jsonResponse);

                if (countries != null && countries.Count > 0)
                {
                    return NewResult<List<Country>>.Success(countries, "Countries retrieved successfully.");
                }
                else
                {
                    return NewResult<List<Country>>.NotFound(null, "No countries found.");
                }
            }
            catch (Exception ex)
            {
                return NewResult<List<Country>>.InternalServerError(null, $"Error occurred: {ex.Message}");
            }
        }
    }
}