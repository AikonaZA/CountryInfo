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

        private void HandleErrorResponse(HttpResponseCode responseCode, string responseMsg)
        {
            Console.WriteLine($"Error: {responseCode} - {responseMsg}");
        }
    }
}