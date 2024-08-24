using CountryInfo.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CountryInfo.API.Controllers
{
    /// <summary>
    /// Provides API endpoints to retrieve information about countries, regions, and subregions.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CountriesController(ICountryService countryService) : ControllerBase
    {
        /// <summary>
        /// Retrieves a list of all countries.
        /// </summary>
        /// <remarks>
        /// This endpoint returns a comprehensive list of all recognized countries, including their basic details such as name, capital, population, and region.
        /// </remarks>
        /// <returns>A JSON response containing a list of countries or an appropriate error message.</returns>
        /// <response code="200">Returns the list of countries.</response>
        /// <response code="404">If no countries are found.</response>
        /// <response code="500">If an internal server error occurs.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllCountries()
        {
            var response = await countryService.GetAllCountriesAsync();
            return StatusCode((int)response.ResponseCode, response);
        }

        /// <summary>
        /// Retrieves details for a specific country by its name.
        /// </summary>
        /// <remarks>
        /// Provide the name of the country to retrieve detailed information including its capital, population, region, and subregion.
        /// </remarks>
        /// <param name="name">The name of the country to retrieve details for. Example: "South Africa".</param>
        /// <returns>A JSON response containing the country details or an appropriate error message.</returns>
        /// <response code="200">Returns the details of the specified country.</response>
        /// <response code="404">If the country is not found.</response>
        /// <response code="500">If an internal server error occurs.</response>
        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCountryDetails(string name)
        {
            var response = await countryService.GetCountryDetailsAsync(name);
            return StatusCode((int)response.ResponseCode, response);
        }

        /// <summary>
        /// Retrieves details for a specific region by its name.
        /// </summary>
        /// <remarks>
        /// Provide the name of the region to retrieve a list of countries within that region, including their basic details.
        /// </remarks>
        /// <param name="regionName">The name of the region to retrieve details for. Example: "Africa".</param>
        /// <returns>A JSON response containing the region details or an appropriate error message.</returns>
        /// <response code="200">Returns the details of the specified region.</response>
        /// <response code="404">If the region is not found.</response>
        /// <response code="500">If an internal server error occurs.</response>
        [HttpGet("region/{regionName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRegionDetails(string regionName)
        {
            var response = await countryService.GetRegionDetailsAsync(regionName);
            return StatusCode((int)response.ResponseCode, response);
        }

        /// <summary>
        /// Retrieves details for a specific subregion by its name.
        /// </summary>
        /// <remarks>
        /// Provide the name of the subregion to retrieve a list of countries within that subregion, including their basic details.
        /// </remarks>
        /// <param name="subregionName">The name of the subregion to retrieve details for. Example: "Southern Africa".</param>
        /// <returns>A JSON response containing the subregion details or an appropriate error message.</returns>
        /// <response code="200">Returns the details of the specified subregion.</response>
        /// <response code="404">If the subregion is not found.</response>
        /// <response code="500">If an internal server error occurs.</response>
        [HttpGet("subregion/{subregionName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSubregionDetails(string subregionName)
        {
            var response = await countryService.GetSubregionDetailsAsync(subregionName);
            return StatusCode((int)response.ResponseCode, response);
        }

        /// <summary>
        /// Retrieves details for multiple countries by their alpha codes.
        /// </summary>
        /// <remarks>
        /// Provide a comma-separated list of country alpha codes to retrieve details for multiple countries.
        /// </remarks>
        /// <param name="codes">Comma-separated list of country alpha codes. Example: "ZA,US,GB".</param>
        /// <returns>A JSON response containing details of the countries or an appropriate error message.</returns>
        /// <response code="200">Returns the details of the specified countries.</response>
        /// <response code="404">If none of the countries are found.</response>
        /// <response code="500">If an internal server error occurs.</response>
        [HttpGet("codes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCountriesByCodes([FromQuery] string codes)
        {
            var countryCodes = codes.Split(',').ToList();
            var response = await countryService.GetCountriesByCodesAsync(countryCodes);
            return StatusCode((int)response.ResponseCode, response);
        }
    }
}