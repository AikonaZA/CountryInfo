using CountryInfo.Core.Entities;
using CountryInfo.Infrastructure.Interfaces;
using System.Text.Json;

namespace CountryInfo.Infrastructure.Services
{
    public class RestCountriesClient(HttpClient httpClient) : IRestCountriesClient
    {
        public async Task<List<Country>> GetAllCountriesAsync()
        {
            var response = await httpClient.GetAsync("https://restcountries.com/v3.1/all");
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Country>>(jsonResponse);
        }

        public async Task<Country> GetCountryDetailsAsync(string countryName)
        {
            var response = await httpClient.GetAsync($"https://restcountries.com/v3.1/name/{countryName}");
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var countries = JsonSerializer.Deserialize<List<Country>>(jsonResponse);
            return countries?.FirstOrDefault();
        }

        public Task<Region> GetRegionDetailsAsync(string regionName)
        {
            throw new NotImplementedException();
        }

        public Task<Subregion> GetSubregionDetailsAsync(string subregionName)
        {
            throw new NotImplementedException();
        }

        // Implement other methods similarly...
    }
}