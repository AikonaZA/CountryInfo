using AutoMapper;
using CountryInfo.Application.Interfaces;
using CountryInfo.Core.Common;
using CountryInfo.Core.Enums;
using CountryInfo.Infrastructure.Interfaces;
using CountryInfo.Shared.DTOs;

namespace CountryInfo.Application.Services
{
    public class CountryService : ICountryService
    {
        private readonly IRestCountriesClient _restCountriesClient;
        private readonly IMapper _mapper;

        public CountryService(IRestCountriesClient restCountriesClient, IMapper mapper)
        {
            _restCountriesClient = restCountriesClient;
            _mapper = mapper;
        }

        public async Task<NewResult<List<CountryDto>>> GetAllCountriesAsync()
        {
            try
            {
                var countriesResult = await _restCountriesClient.GetAllCountriesAsync();

                if (countriesResult.ResponseCode == HttpResponseCode.Success && countriesResult.ResponseDetails != null)
                {
                    var countryDtos = _mapper.Map<List<CountryDto>>(countriesResult.ResponseDetails);
                    return NewResult<List<CountryDto>>.Success(countryDtos, "Countries retrieved successfully.");
                }
                else
                {
                    return NewResult<List<CountryDto>>.NotFound(null, "No countries found.");
                }
            }
            catch (Exception ex)
            {
                return NewResult<List<CountryDto>>.Failed(null, $"Error occurred: {ex.Message}");
            }
        }

        public async Task<NewResult<CountryDto>> GetCountryDetailsAsync(string countryName)
        {
            try
            {
                var countryResult = await _restCountriesClient.GetCountryDetailsAsync(countryName);

                if (countryResult.ResponseCode == HttpResponseCode.Success && countryResult.ResponseDetails != null)
                {
                    var countryDto = _mapper.Map<CountryDto>(countryResult.ResponseDetails);
                    return NewResult<CountryDto>.Success(countryDto, "Country details retrieved successfully.");
                }
                else
                {
                    return NewResult<CountryDto>.NotFound(null, "Country not found.");
                }
            }
            catch (Exception ex)
            {
                return NewResult<CountryDto>.Failed(null, $"Error occurred: {ex.Message}");
            }
        }

        public async Task<NewResult<RegionDto>> GetRegionDetailsAsync(string regionName)
        {
            try
            {
                var regionResult = await _restCountriesClient.GetRegionDetailsAsync(regionName);

                if (regionResult.ResponseCode == HttpResponseCode.Success && regionResult.ResponseDetails != null)
                {
                    var regionDto = new RegionDto
                    {
                        Name = regionName,
                        Countries = _mapper.Map<List<CountryDto>>(regionResult.ResponseDetails),
                        Population = regionResult.ResponseDetails.Sum(c => c.population)
                    };
                    return NewResult<RegionDto>.Success(regionDto, "Region details retrieved successfully.");
                }
                else
                {
                    return NewResult<RegionDto>.NotFound(null, "Region not found.");
                }
            }
            catch (Exception ex)
            {
                return NewResult<RegionDto>.Failed(null, $"Error occurred: {ex.Message}");
            }
        }

        public async Task<NewResult<SubregionDto>> GetSubregionDetailsAsync(string subregionName)
        {
            try
            {
                var subregionResult = await _restCountriesClient.GetSubregionDetailsAsync(subregionName);

                if (subregionResult.ResponseCode == HttpResponseCode.Success && subregionResult.ResponseDetails != null)
                {
                    var subregionDto = new SubregionDto
                    {
                        Name = subregionName,
                        Region = subregionResult.ResponseDetails.FirstOrDefault()?.region,
                        Countries = _mapper.Map<List<CountryDto>>(subregionResult.ResponseDetails),
                        Population = subregionResult.ResponseDetails.Sum(c => c.population)
                    };
                    return NewResult<SubregionDto>.Success(subregionDto, "Subregion details retrieved successfully.");
                }
                else
                {
                    return NewResult<SubregionDto>.NotFound(null, "Subregion not found.");
                }
            }
            catch (Exception ex)
            {
                return NewResult<SubregionDto>.Failed(null, $"Error occurred: {ex.Message}");
            }
        }
    }
}