namespace CountryInfo.Shared.DTOs
{
    public class SubregionDto
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public List<CountryDto> Countries { get; set; }
        public int Population { get; set; }
    }
}