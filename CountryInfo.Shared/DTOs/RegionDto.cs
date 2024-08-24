namespace CountryInfo.Shared.DTOs
{
    public class RegionDto
    {
        public string Name { get; set; }
        public List<CountryDto> Countries { get; set; }
        public int Population { get; set; }
    }
}