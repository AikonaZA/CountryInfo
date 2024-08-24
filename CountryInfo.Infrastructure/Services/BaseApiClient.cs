using CountryInfo.Core.Common;
using CountryInfo.Core.Entities;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CountryInfo.Infrastructure.Services
{
    public abstract class BaseApiClient(HttpClient httpClient)
    {
        protected readonly HttpClient _httpClient = httpClient;

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