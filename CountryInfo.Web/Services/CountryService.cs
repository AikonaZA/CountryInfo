using CountryInfo.Core.Common;
using CountryInfo.Core.Enums;
using CountryInfo.Shared.DTOs;
using System.Net.Http.Json;

namespace CountryInfo.Web.Services
{
    /// <summary>
    /// Service for interacting with the CountryInfo API to retrieve information about countries, regions, and subregions.
    /// </summary>
    /// <param name="httpClient">The HTTP client used for making API calls.</param>
    public class CountryService(HttpClient httpClient)
    {
        /// <summary>
        /// Retrieves a list of all countries from the API.
        /// </summary>
        /// <returns>A list of <see cref="CountryDto"/> containing country details if the request is successful; otherwise, an empty list.</returns>
        public async Task<List<CountryDto>> GetAllCountriesAsync()
        {
            var apiResponse = await httpClient.GetFromJsonAsync<NewResult<List<CountryDto>>>("api/Countries");

            if (apiResponse.ResponseCode == HttpResponseCode.Success)
            {
                return apiResponse.ResponseDetails;
            }
            else
            {
                HandleErrorResponse(apiResponse.ResponseCode, apiResponse.ResponseMsg);
                return new List<CountryDto>();
            }
        }

        /// <summary>
        /// Retrieves detailed information about a specific country by its name.
        /// </summary>
        /// <param name="countryName">The name of the country to retrieve details for.</param>
        /// <returns>A <see cref="CountryDto"/> containing country details if the request is successful; otherwise, null.</returns>
        public async Task<CountryDto> GetCountryDetailsAsync(string countryName)
        {
            var apiResponse = await httpClient.GetFromJsonAsync<NewResult<CountryDto>>($"api/Countries/{countryName}");

            if (apiResponse.ResponseCode == HttpResponseCode.Success)
            {
                return apiResponse.ResponseDetails;
            }
            else
            {
                HandleErrorResponse(apiResponse.ResponseCode, apiResponse.ResponseMsg);
                return null;
            }
        }

        /// <summary>
        /// Retrieves detailed information about a specific region by its name.
        /// </summary>
        /// <param name="regionName">The name of the region to retrieve details for.</param>
        /// <returns>A <see cref="RegionDto"/> containing region details if the request is successful; otherwise, null.</returns>
        public async Task<RegionDto> GetRegionDetailsAsync(string regionName)
        {
            var apiResponse = await httpClient.GetFromJsonAsync<NewResult<RegionDto>>($"api/Countries/region/{regionName}");

            if (apiResponse.ResponseCode == HttpResponseCode.Success)
            {
                return apiResponse.ResponseDetails;
            }
            else
            {
                HandleErrorResponse(apiResponse.ResponseCode, apiResponse.ResponseMsg);
                return null;
            }
        }

        /// <summary>
        /// Retrieves detailed information about a specific subregion by its name.
        /// </summary>
        /// <param name="subregionName">The name of the subregion to retrieve details for.</param>
        /// <returns>A <see cref="SubregionDto"/> containing subregion details if the request is successful; otherwise, null.</returns>
        public async Task<SubregionDto> GetSubregionDetailsAsync(string subregionName)
        {
            var apiResponse = await httpClient.GetFromJsonAsync<NewResult<SubregionDto>>($"api/Countries/subregion/{subregionName}");

            if (apiResponse.ResponseCode == HttpResponseCode.Success)
            {
                return apiResponse.ResponseDetails;
            }
            else
            {
                HandleErrorResponse(apiResponse.ResponseCode, apiResponse.ResponseMsg);
                return null;
            }
        }

        /// <summary>
        /// Retrieves information about multiple countries by their alpha codes.
        /// </summary>
        /// <param name="countryCodes">A list of alpha codes representing the countries to retrieve details for.</param>
        /// <returns>A list of <see cref="CountryDto"/> containing country details if the request is successful; otherwise, an empty list.</returns>
        public async Task<List<CountryDto>> GetCountriesByCodesAsync(List<string> countryCodes)
        {
            var codesQuery = string.Join(",", countryCodes);
            var apiResponse = await httpClient.GetFromJsonAsync<NewResult<List<CountryDto>>>($"api/Countries/codes?codes={codesQuery}");

            if (apiResponse.ResponseCode == HttpResponseCode.Success)
            {
                return apiResponse.ResponseDetails;
            }
            else
            {
                HandleErrorResponse(apiResponse.ResponseCode, apiResponse.ResponseMsg);
                return new List<CountryDto>();
            }
        }

        /// <summary>
        /// Handles error responses by logging the response code and message.
        /// </summary>
        /// <param name="responseCode">The HTTP response code returned by the API.</param>
        /// <param name="responseMsg">The message returned by the API.</param>
        private void HandleErrorResponse(HttpResponseCode responseCode, string responseMsg)
        {
            Console.WriteLine($"Error: {responseCode} - {responseMsg}");
        }
    }
}