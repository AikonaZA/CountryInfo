using CountryInfo.Core.Common;
using CountryInfo.Core.Enums;
using CountryInfo.Shared.DTOs;
using System.Net.Http.Json;

namespace CountryInfo.Web.Services
{
    public class CountryService(HttpClient httpClient)
    {
        public async Task<List<CountryDto>> GetAllCountriesAsync()
        {
            // Call the API and get the wrapped response
            var apiResponse = await httpClient.GetFromJsonAsync<NewResult<List<CountryDto>>>("api/Countries");

            // Check if the response code indicates success
            if (apiResponse.ResponseCode == HttpResponseCode.Success)
            {
                // Return the actual data
                return apiResponse.ResponseDetails;
            }
            else
            {
                // Handle other response codes, log errors, etc.
                // For now, just return an empty list
                return [];
            }
        }
    }
}