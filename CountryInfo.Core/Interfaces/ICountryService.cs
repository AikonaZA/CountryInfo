﻿using CountryInfo.Core.Entities;

namespace CountryInfo.Core.Interfaces
{
    public interface ICountryService
    {
        Task<List<Country>> GetAllCountriesAsync();
        Task<Country> GetCountryDetailsAsync(string countryName);
        Task<Region> GetRegionDetailsAsync(string regionName);
        Task<Subregion> GetSubregionDetailsAsync(string subregionName);
    }

}
