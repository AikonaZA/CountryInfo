using CountryInfo.Core.Entities;
using CountryInfo.Core.Interfaces;

namespace CountryInfo.Application.Services
{
    public class CountryService : ICountryService
    {
        private readonly IRestCountriesClient _restCountriesClient;

        public CountryService(IRestCountriesClient restCountriesClient)
        {
            _restCountriesClient = restCountriesClient;
        }

        public async Task<List<Country>> GetAllCountriesAsync()
        {
            return await _restCountriesClient.GetAllCountriesAsync();
        }

        public async Task<Country> GetCountryDetailsAsync(string countryName)
        {
            return await _restCountriesClient.GetCountryDetailsAsync(countryName);
        }

        public async Task<Region> GetRegionDetailsAsync(string regionName)
        {
            return await _restCountriesClient.GetRegionDetailsAsync(regionName);
        }

        public async Task<Subregion> GetSubregionDetailsAsync(string subregionName)
        {
            return await _restCountriesClient.GetSubregionDetailsAsync(subregionName);
        }
    }
}