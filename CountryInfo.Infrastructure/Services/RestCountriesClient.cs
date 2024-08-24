using CountryInfo.Core.Common;
using CountryInfo.Core.Entities;
using CountryInfo.Infrastructure.Configuration;
using CountryInfo.Infrastructure.Interfaces;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace CountryInfo.Infrastructure.Services
{
    public class RestCountriesClient(HttpClient httpClient, IOptions<RestCountriesApiSettings> apiSettings) : IRestCountriesClient
    {
        private readonly RestCountriesApiSettings _apiSettings = apiSettings.Value;

        public async Task<NewResult<List<Country>>> GetAllCountriesAsync()
        {
            try
            {
                var response = await httpClient.GetAsync(_apiSettings.GetFullUrl(_apiSettings.AllCountriesEndpoint));

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

        public async Task<NewResult<Country>> GetCountryDetailsAsync(string countryName)
        {
            try
            {
                var endpoint = _apiSettings.CountryDetailsEndpoint.Replace("{countryName}", countryName);
                var response = await httpClient.GetAsync(_apiSettings.GetFullUrl(endpoint));

                if (!response.IsSuccessStatusCode)
                {
                    return NewResult<Country>.Failed(null, $"Error occurred: {response.ReasonPhrase}");
                }

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var countries = JsonSerializer.Deserialize<List<Country>>(jsonResponse);
                var country = countries?.FirstOrDefault();

                if (country != null)
                {
                    return NewResult<Country>.Success(country, "Country details retrieved successfully.");
                }
                else
                {
                    return NewResult<Country>.NotFound(null, "Country not found.");
                }
            }
            catch (Exception ex)
            {
                return NewResult<Country>.InternalServerError(null, $"Error occurred: {ex.Message}");
            }
        }

        public async Task<NewResult<List<Country>>> GetRegionDetailsAsync(string regionName)
        {
            try
            {
                var endpoint = _apiSettings.RegionEndpoint.Replace("{regionName}", regionName);
                var response = await httpClient.GetAsync(_apiSettings.GetFullUrl(endpoint));

                if (!response.IsSuccessStatusCode)
                {
                    return NewResult<List<Country>>.Failed(null, $"Error occurred: {response.ReasonPhrase}");
                }

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var countries = JsonSerializer.Deserialize<List<Country>>(jsonResponse);

                if (countries != null && countries.Count > 0)
                {
                    return NewResult<List<Country>>.Success(countries, $"Countries in region {regionName} retrieved successfully.");
                }
                else
                {
                    return NewResult<List<Country>>.NotFound(null, $"No countries found in region {regionName}.");
                }
            }
            catch (Exception ex)
            {
                return NewResult<List<Country>>.InternalServerError(null, $"Error occurred: {ex.Message}");
            }
        }

        public async Task<NewResult<List<Country>>> GetSubregionDetailsAsync(string subregionName)
        {
            try
            {
                var endpoint = _apiSettings.SubregionEndpoint.Replace("{subregionName}", subregionName);
                var response = await httpClient.GetAsync(_apiSettings.GetFullUrl(endpoint));

                if (!response.IsSuccessStatusCode)
                {
                    return NewResult<List<Country>>.Failed(null, $"Error occurred: {response.ReasonPhrase}");
                }

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var countries = JsonSerializer.Deserialize<List<Country>>(jsonResponse);

                if (countries != null && countries.Count > 0)
                {
                    return NewResult<List<Country>>.Success(countries, $"Countries in subregion {subregionName} retrieved successfully.");
                }
                else
                {
                    return NewResult<List<Country>>.NotFound(null, $"No countries found in subregion {subregionName}.");
                }
            }
            catch (Exception ex)
            {
                return NewResult<List<Country>>.InternalServerError(null, $"Error occurred: {ex.Message}");
            }
        }

        public async Task<NewResult<List<Country>>> GetCountriesByCodesAsync(List<string> countryCodes)
        {
            try
            {
                var codesQuery = string.Join(",", countryCodes);
                var endpoint = _apiSettings.CountriesByCodesEndpoint.Replace("{codes}", codesQuery);
                var response = await httpClient.GetAsync(_apiSettings.GetFullUrl(endpoint));

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
                    return NewResult<List<Country>>.NotFound(null, "No countries found for the provided codes.");
                }
            }
            catch (Exception ex)
            {
                return NewResult<List<Country>>.InternalServerError(null, $"Error occurred: {ex.Message}");
            }
        }
    }
}
