using CountryInfo.Application.Interfaces;
using CountryInfo.Core.Common;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CountryInfo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController(ICountryService countryService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllCountries()
        {
            var response = await countryService.GetAllCountriesAsync();

            return StatusCode((int)response.ResponseCode, response);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetCountryDetails(string name)
        {
            var response = await countryService.GetCountryDetailsAsync(name);

            return StatusCode((int)response.ResponseCode, response);
        }

        // Implement other endpoints similarly...
    }
}
