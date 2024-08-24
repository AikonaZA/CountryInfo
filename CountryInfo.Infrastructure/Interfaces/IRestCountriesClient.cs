using CountryInfo.Core.Common;
using CountryInfo.Core.Entities;

namespace CountryInfo.Infrastructure.Interfaces
{
    public interface IRestCountriesClient
    {
        Task<NewResult<List<Country>>> GetAllCountriesAsync();
        Task<NewResult<Country>> GetCountryDetailsAsync(string countryName);
        Task<NewResult<List<Country>>> GetRegionDetailsAsync(string regionName);
        Task<NewResult<List<Country>>> GetSubregionDetailsAsync(string subregionName);

        // New method to get countries by alpha codes
        Task<NewResult<List<Country>>> GetCountriesByCodesAsync(List<string> countryCodes);
    }
}
