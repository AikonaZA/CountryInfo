namespace CountryInfo.Shared.DTOs
{
    public class RegionDto
    {
        public string Name { get; set; }
        public List<CountryDto> Countries { get; set; }
        public long Population { get; set; }
    }
}