namespace CountryInfo.Infrastructure.Configuration
{
    public class RestCountriesApiSettings
    {
        public string BaseUrl { get; set; }
        public string ApiVersion { get; set; }
        public string AllCountriesEndpoint { get; set; }
        public string CountryDetailsEndpoint { get; set; }
        public string RegionEndpoint { get; set; }
        public string SubregionEndpoint { get; set; }
        public string CountriesByCodesEndpoint { get; set; }

        public string GetFullUrl(string endpoint)
        {
            return $"{BaseUrl}{ApiVersion}/{endpoint}";
        }
    }
}