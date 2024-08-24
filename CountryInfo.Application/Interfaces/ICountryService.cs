using CountryInfo.Core.Entities;
using CountryInfo.Core.Common;

namespace CountryInfo.Application.Interfaces
{
    public interface ICountryService
    {
        Task<NewResult<List<Country>>> GetAllCountriesAsync();

        Task<NewResult<Country>> GetCountryDetailsAsync(string countryName);

        Task<NewResult<Region>> GetRegionDetailsAsync(string regionName);

        Task<NewResult<Subregion>> GetSubregionDetailsAsync(string subregionName);
    }
}