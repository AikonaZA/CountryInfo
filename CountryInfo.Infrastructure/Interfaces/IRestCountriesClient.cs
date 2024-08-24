using CountryInfo.Core.Entities;

namespace CountryInfo.Infrastructure.Interfaces
{
    public interface IRestCountriesClient
    {
        Task<List<Country>> GetAllCountriesAsync();

        Task<Country> GetCountryDetailsAsync(string countryName);

        Task<Region> GetRegionDetailsAsync(string regionName);

        Task<Subregion> GetSubregionDetailsAsync(string subregionName);
    }
}