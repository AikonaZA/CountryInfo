using CountryInfo.Core.Common;
using CountryInfo.Core.Entities;

namespace CountryInfo.Infrastructure.Interfaces
{
    public interface IRestCountriesClient
    {
        /// <summary>
        /// Retrieves a list of all countries from the REST Countries API.
        /// </summary>
        /// <returns>A result containing a list of Country entities or an appropriate error message.</returns>
        Task<NewResult<List<Country>>> GetAllCountriesAsync();

        /// <summary>
        /// Retrieves details for a specific country by its name from the REST Countries API.
        /// </summary>
        /// <param name="countryName">The name of the country to retrieve details for.</param>
        /// <returns>A result containing the Country entity or an appropriate error message.</returns>
        Task<NewResult<Country>> GetCountryDetailsAsync(string countryName);

        /// <summary>
        /// Retrieves details for a specific region by its name from the REST Countries API.
        /// </summary>
        /// <param name="regionName">The name of the region to retrieve details for.</param>
        /// <returns>A result containing a list of Country entities within the region or an appropriate error message.</returns>
        Task<NewResult<List<Country>>> GetRegionDetailsAsync(string regionName);

        /// <summary>
        /// Retrieves details for a specific subregion by its name from the REST Countries API.
        /// </summary>
        /// <param name="subregionName">The name of the subregion to retrieve details for.</param>
        /// <returns>A result containing a list of Country entities within the subregion or an appropriate error message.</returns>
        Task<NewResult<List<Country>>> GetSubregionDetailsAsync(string subregionName);

        /// <summary>
        /// Retrieves details for multiple countries by their alpha codes from the REST Countries API.
        /// </summary>
        /// <param name="countryCodes">A list of alpha codes representing the countries to retrieve details for.</param>
        /// <returns>A result containing a list of Country entities corresponding to the provided codes or an appropriate error message.</returns>
        Task<NewResult<List<Country>>> GetCountriesByCodesAsync(List<string> countryCodes);
    }
}
