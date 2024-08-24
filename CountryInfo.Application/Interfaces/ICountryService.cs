using CountryInfo.Core.Common;
using CountryInfo.Shared.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CountryInfo.Application.Interfaces
{
    public interface ICountryService
    {
        Task<NewResult<List<CountryDto>>> GetAllCountriesAsync();
        Task<NewResult<CountryDto>> GetCountryDetailsAsync(string countryName);
        Task<NewResult<RegionDto>> GetRegionDetailsAsync(string regionName);
        Task<NewResult<SubregionDto>> GetSubregionDetailsAsync(string subregionName);

        // New method to get countries by alpha codes
        Task<NewResult<List<CountryDto>>> GetCountriesByCodesAsync(List<string> countryCodes);
    }
}
