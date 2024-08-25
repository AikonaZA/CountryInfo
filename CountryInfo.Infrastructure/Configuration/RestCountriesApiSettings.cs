namespace CountryInfo.Infrastructure.Configuration
{
    /// <summary>
    /// Configuration settings for the REST Countries API, including the base URL, API version, and specific endpoints for various API calls.
    /// </summary>
    public class RestCountriesApiSettings
    {
        /// <summary>
        /// Gets or sets the base URL of the REST Countries API.
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        /// Gets or sets the version of the REST Countries API to use.
        /// </summary>
        public string ApiVersion { get; set; }

        /// <summary>
        /// Gets or sets the endpoint for retrieving all countries.
        /// </summary>
        public string AllCountriesEndpoint { get; set; }

        /// <summary>
        /// Gets or sets the endpoint for retrieving details of a specific country by its name.
        /// </summary>
        public string CountryDetailsEndpoint { get; set; }

        /// <summary>
        /// Gets or sets the endpoint for retrieving details of a specific region by its name.
        /// </summary>
        public string RegionEndpoint { get; set; }

        /// <summary>
        /// Gets or sets the endpoint for retrieving details of a specific subregion by its name.
        /// </summary>
        public string SubregionEndpoint { get; set; }

        /// <summary>
        /// Gets or sets the endpoint for retrieving details of multiple countries by their alpha codes.
        /// </summary>
        public string CountriesByCodesEndpoint { get; set; }
    }
}