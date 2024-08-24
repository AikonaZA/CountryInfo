using CountryInfo.Core.Common;
using CountryInfo.Shared.DTOs;

namespace CountryInfo.Application.Interfaces
{
    public interface ICountryService
    {
        Task<NewResult<List<CountryDto>>> GetAllCountriesAsync();

        Task<NewResult<CountryDto>> GetCountryDetailsAsync(string countryName);

        Task<NewResult<RegionDto>> GetRegionDetailsAsync(string regionName);

        Task<NewResult<SubregionDto>> GetSubregionDetailsAsync(string subregionName);
    }
}