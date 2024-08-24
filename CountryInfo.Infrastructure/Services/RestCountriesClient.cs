using CountryInfo.Core.Common;
using CountryInfo.Core.Entities;
using CountryInfo.Infrastructure.Configuration;
using CountryInfo.Infrastructure.Extensions;
using CountryInfo.Infrastructure.Interfaces;
using Microsoft.Extensions.Options;

namespace CountryInfo.Infrastructure.Services
{
    public class RestCountriesClient(HttpClient httpClient, IOptions<RestCountriesApiSettings> apiSettings) : BaseApiClient(httpClient), IRestCountriesClient
    {
        private readonly RestCountriesApiSettings _apiSettings = apiSettings.Value;

        public async Task<NewResult<List<Country>>> GetAllCountriesAsync()
        {
            var fullUrl = _apiSettings.GetFullUrl(_apiSettings.AllCountriesEndpoint);
            return await GetCountriesAsync(fullUrl);
        }

        public async Task<NewResult<Country>> GetCountryDetailsAsync(string countryName)
        {
            var endpoint = _apiSettings.CountryDetailsEndpoint.Replace("{countryName}", countryName);
            var fullUrl = _apiSettings.GetFullUrl(endpoint);
            var result = await GetCountriesAsync(fullUrl);

            if (result.ResponseDetails != null && result.ResponseDetails.Count > 0)
            {
                return NewResult<Country>.Success(result.ResponseDetails.First(), "Country details retrieved successfully.");
            }
            return NewResult<Country>.NotFound(null, "Country not found.");
        }

        public async Task<NewResult<List<Country>>> GetRegionDetailsAsync(string regionName)
        {
            var endpoint = _apiSettings.RegionEndpoint.Replace("{regionName}", regionName);
            var fullUrl = _apiSettings.GetFullUrl(endpoint);
            return await GetCountriesAsync(fullUrl);
        }

        public async Task<NewResult<List<Country>>> GetSubregionDetailsAsync(string subregionName)
        {
            var endpoint = _apiSettings.SubregionEndpoint.Replace("{subregionName}", subregionName);
            var fullUrl = _apiSettings.GetFullUrl(endpoint);
            return await GetCountriesAsync(fullUrl);
        }

        public async Task<NewResult<List<Country>>> GetCountriesByCodesAsync(List<string> countryCodes)
        {
            var codesQuery = string.Join(",", countryCodes);
            var endpoint = _apiSettings.CountriesByCodesEndpoint.Replace("{codes}", codesQuery);
            var fullUrl = _apiSettings.GetFullUrl(endpoint);
            return await GetCountriesAsync(fullUrl);
        }
    }
}