using AutoMapper;
using CountryInfo.Application.Interfaces;
using CountryInfo.Core.Common;
using CountryInfo.Core.Entities;
using CountryInfo.Infrastructure.Interfaces;
using CountryInfo.Shared.DTOs;

namespace CountryInfo.Application.Services
{
    public class CountryService(IRestCountriesClient restCountriesClient, IMapper mapper) : BaseService(mapper), ICountryService
    {
        public Task<NewResult<List<CountryDto>>> GetAllCountriesAsync()
        {
            return HandleApiCall<List<CountryDto>, Country>(
                restCountriesClient.GetAllCountriesAsync(),
                "Countries retrieved successfully.",
                "No countries found."
            );
        }

        public Task<NewResult<CountryDto>> GetCountryDetailsAsync(string countryName)
        {
            return HandleApiCall<CountryDto, Country>(
                restCountriesClient.GetCountryDetailsAsync(countryName),
                "Country details retrieved successfully.",
                "Country not found."
            );
        }

        public Task<NewResult<RegionDto>> GetRegionDetailsAsync(string regionName)
        {
            return HandleApiCall<RegionDto, Country>(
                restCountriesClient.GetRegionDetailsAsync(regionName),
                "Region details retrieved successfully.",
                "Region not found.",
                countries => new RegionDto
                {
                    Name = regionName,
                    Countries = mapper.Map<List<CountryDto>>(countries),
                    Population = countries.Sum(c => c.population)
                }
            );
        }

        public Task<NewResult<SubregionDto>> GetSubregionDetailsAsync(string subregionName)
        {
            return HandleApiCall<SubregionDto, Country>(
                restCountriesClient.GetSubregionDetailsAsync(subregionName),
                "Subregion details retrieved successfully.",
                "Subregion not found.",
                countries => new SubregionDto
                {
                    Name = subregionName,
                    Region = countries.FirstOrDefault()?.region,
                    Countries = mapper.Map<List<CountryDto>>(countries),
                    Population = countries.Sum(c => c.population)
                }
            );
        }

        public Task<NewResult<List<CountryDto>>> GetCountriesByCodesAsync(List<string> countryCodes)
        {
            return HandleApiCall<List<CountryDto>, Country>(
                restCountriesClient.GetCountriesByCodesAsync(countryCodes),
                "Countries retrieved successfully.",
                "No countries found for the provided codes."
            );
        }
    }
}
