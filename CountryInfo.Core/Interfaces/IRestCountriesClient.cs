using CountryInfo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryInfo.Core.Interfaces
{
    public interface IRestCountriesClient
    {
        Task<List<Country>> GetAllCountriesAsync();
        Task<Country> GetCountryDetailsAsync(string countryName);
        Task<Region> GetRegionDetailsAsync(string regionName);
        Task<Subregion> GetSubregionDetailsAsync(string subregionName);
    }
}
