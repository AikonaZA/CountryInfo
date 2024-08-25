using CountryInfo.Core.Common;
using CountryInfo.Shared.DTOs;

namespace CountryInfo.Application.Interfaces
{
    public interface ICountryService
    {
        /// <summary>
        /// Retrieves a list of all countries.
        /// </summary>
        /// <returns>A result containing a list of CountryDto objects or an appropriate error message.</returns>
        Task<NewResult<List<CountryDto>>> GetAllCountriesAsync();

        /// <summary>
        /// Retrieves details for a specific country by its name.
        /// </summary>
        /// <param name="countryName">The name of the country to retrieve details for.</param>
        /// <returns>A result containing the CountryDto object or an appropriate error message.</returns>
        Task<NewResult<CountryDto>> GetCountryDetailsAsync(string countryName);

        /// <summary>
        /// Retrieves details for a specific region by its name.
        /// </summary>
        /// <param name="regionName">The name of the region to retrieve details for.</param>
        /// <returns>A result containing the RegionDto object or an appropriate error message.</returns>
        Task<NewResult<RegionDto>> GetRegionDetailsAsync(string regionName);

        /// <summary>
        /// Retrieves details for a specific subregion by its name.
        /// </summary>
        /// <param name="subregionName">The name of the subregion to retrieve details for.</param>
        /// <returns>A result containing the SubregionDto object or an appropriate error message.</returns>
        Task<NewResult<SubregionDto>> GetSubregionDetailsAsync(string subregionName);

        /// <summary>
        /// Retrieves details for multiple countries by their alpha codes.
        /// </summary>
        /// <param name="countryCodes">A list of alpha codes representing the countries to retrieve details for.</param>
        /// <returns>A result containing a list of CountryDto objects or an appropriate error message.</returns>
        Task<NewResult<List<CountryDto>>> GetCountriesByCodesAsync(List<string> countryCodes);
    }
}