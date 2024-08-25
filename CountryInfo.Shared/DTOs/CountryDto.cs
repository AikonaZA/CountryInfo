namespace CountryInfo.Shared.DTOs
{
    /// <summary>
    /// Represents a country with detailed information including name, currencies, capitals, region, subregion, languages, borders, and population.
    /// </summary>
    public class CountryDto
    {
        /// <summary>
        /// Gets or sets the name of the country.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the list of official currencies used in the country.
        /// </summary>
        public List<string> Currencies { get; set; }

        /// <summary>
        /// Gets or sets the list of capital cities of the country.
        /// </summary>
        public List<string> Capitals { get; set; }

        /// <summary>
        /// Gets or sets the region in which the country is located.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Gets or sets the subregion in which the country is located.
        /// </summary>
        public string Subregion { get; set; }

        /// <summary>
        /// Gets or sets the list of official languages spoken in the country.
        /// </summary>
        public List<string> Languages { get; set; }

        /// <summary>
        /// Gets or sets the list of neighboring countries' alpha codes (borders).
        /// </summary>
        public List<string> Borders { get; set; }

        /// <summary>
        /// Gets or sets the total population of the country.
        /// </summary>
        public long Population { get; set; }
    }
}