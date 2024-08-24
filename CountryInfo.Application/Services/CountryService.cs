using CountryInfo.Application.Interfaces;
using CountryInfo.Core.Common;
using CountryInfo.Core.Entities;
using CountryInfo.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CountryInfo.Application.Services
{
    public class CountryService(IRestCountriesClient restCountriesClient) : ICountryService
    {
        public async Task<NewResult<List<Country>>> GetAllCountriesAsync()
        {
            try
            {
                var countries = await restCountriesClient.GetAllCountriesAsync();
                if (countries != null && countries.Count > 0)
                {
                    return NewResult<List<Country>>.Success(countries, "Countries retrieved successfully.");
                }
                else
                {
                    return NewResult<List<Country>>.NotFound(null, "No countries found.");
                }
            }
            catch (Exception ex)
            {
                return NewResult<List<Country>>.Failed(null, $"Error occurred: {ex.Message}");
            }
        }

        public async Task<NewResult<Country>> GetCountryDetailsAsync(string countryName)
        {
            try
            {
                var country = await restCountriesClient.GetCountryDetailsAsync(countryName);
                if (country != null)
                {
                    return NewResult<Country>.Success(country, "Country details retrieved successfully.");
                }
                else
                {
                    return NewResult<Country>.NotFound(null, "Country not found.");
                }
            }
            catch (Exception ex)
            {
                return NewResult<Country>.Failed(null, $"Error occurred: {ex.Message}");
            }
        }

        public async Task<NewResult<Region>> GetRegionDetailsAsync(string regionName)
        {
            try
            {
                var region = await restCountriesClient.GetRegionDetailsAsync(regionName);
                if (region != null)
                {
                    return NewResult<Region>.Success(region, "Region details retrieved successfully.");
                }
                else
                {
                    return NewResult<Region>.NotFound(null, "Region not found.");
                }
            }
            catch (Exception ex)
            {
                return NewResult<Region>.Failed(null, $"Error occurred: {ex.Message}");
            }
        }

        public async Task<NewResult<Subregion>> GetSubregionDetailsAsync(string subregionName)
        {
            try
            {
                var subregion = await restCountriesClient.GetSubregionDetailsAsync(subregionName);
                if (subregion != null)
                {
                    return NewResult<Subregion>.Success(subregion, "Subregion details retrieved successfully.");
                }
                else
                {
                    return NewResult<Subregion>.NotFound(null, "Subregion not found.");
                }
            }
            catch (Exception ex)
            {
                return NewResult<Subregion>.Failed(null, $"Error occurred: {ex.Message}");
            }
        }
    }
}
