using CountryInfo.Core.Common;
using CountryInfo.Core.Entities;
using CountryInfo.Infrastructure.Configuration;
using System.Text.Json;

namespace CountryInfo.Infrastructure.Services
{
    public abstract class BaseRestCountriesClient
    {
        protected readonly HttpClient _httpClient;
        protected readonly RestCountriesApiSettings _apiSettings;

        protected BaseRestCountriesClient(HttpClient httpClient, RestCountriesApiSettings apiSettings)
        {
            _httpClient = httpClient;
            _apiSettings = apiSettings;
        }

        protected async Task<NewResult<List<Country>>> GetCountriesAsync(string endpoint)
        {
            try
            {
                var response = await _httpClient.GetAsync(_apiSettings.GetFullUrl(endpoint));

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