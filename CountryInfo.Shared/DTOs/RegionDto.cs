namespace CountryInfo.Shared.DTOs
{
    /// <summary>
    /// Represents a region with detailed information including name, a list of countries within the region, and the total population.
    /// </summary>
    public class RegionDto
    {
        /// <summary>
        /// Gets or sets the name of the region.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the list of countries within the region.
        /// </summary>
        public List<CountryDto> Countries { get; set; }

        /// <summary>
        /// Gets or sets the total population of the region.
        /// </summary>
        public long Population { get; set; }
    }
}