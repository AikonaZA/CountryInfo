using CountryInfo.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CountryInfo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        /// <summary>
        /// Retrieves a list of all countries.
        /// </summary>
        /// <returns>A response containing a list of countries or an appropriate error message.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllCountries()
        {
            var response = await _countryService.GetAllCountriesAsync();
            return StatusCode((int)response.ResponseCode, response);
        }

        /// <summary>
        /// Retrieves details for a specific country by its name.
        /// </summary>
        /// <param name="name">The name of the country to retrieve details for.</param>
        /// <returns>A response containing the country details or an appropriate error message.</returns>
        [HttpGet("{name}")]
        public async Task<IActionResult> GetCountryDetails(string name)
        {
            var response = await _countryService.GetCountryDetailsAsync(name);
            return StatusCode((int)response.ResponseCode, response);
        }

        /// <summary>
        /// Retrieves details for a specific region by its name.
        /// </summary>
        /// <param name="regionName">The name of the region to retrieve details for.</param>
        /// <returns>A response containing the region details or an appropriate error message.</returns>
        [HttpGet("region/{regionName}")]
        public async Task<IActionResult> GetRegionDetails(string regionName)
        {
            var response = await _countryService.GetRegionDetailsAsync(regionName);
            return StatusCode((int)response.ResponseCode, response);
        }

        /// <summary>
        /// Retrieves details for a specific subregion by its name.
        /// </summary>
        /// <param name="subregionName">The name of the subregion to retrieve details for.</param>
        /// <returns>A response containing the subregion details or an appropriate error message.</returns>
        [HttpGet("subregion/{subregionName}")]
        public async Task<IActionResult> GetSubregionDetails(string subregionName)
        {
            var response = await _countryService.GetSubregionDetailsAsync(subregionName);
            return StatusCode((int)response.ResponseCode, response);
        }


        /// <summary>
        /// Retrieves details for multiple countries by their alpha codes.
        /// </summary>
        /// <param name="codes">Comma-separated list of country alpha codes.</param>
        /// <returns>A response containing details of the countries or an appropriate error message.</returns>
        [HttpGet("codes")]
        public async Task<IActionResult> GetCountriesByCodes([FromQuery] string codes)
        {
            var countryCodes = codes.Split(',').ToList();
            var response = await _countryService.GetCountriesByCodesAsync(countryCodes);
            return StatusCode((int)response.ResponseCode, response);
        }
    }
}