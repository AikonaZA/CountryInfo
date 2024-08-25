namespace CountryInfo.Shared.DTOs
{
    /// <summary>
    /// Represents a subregion with detailed information including name, the region it belongs to, a list of countries within the subregion, and the total population.
    /// </summary>
    public class SubregionDto
    {
        /// <summary>
        /// Gets or sets the name of the subregion.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the region to which the subregion belongs.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Gets or sets the list of countries within the subregion.
        /// </summary>
        public List<CountryDto> Countries { get; set; }

        /// <summary>
        /// Gets or sets the total population of the subregion.
        /// </summary>
        public long Population { get; set; }
    }
}