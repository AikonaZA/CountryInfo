namespace CountryInfo.Shared.DTOs
{
    public class CountryDto
    {
        public string Name { get; set; }
        public List<string> Currencies { get; set; }
        public List<string> Capitals { get; set; }
        public string Region { get; set; }
        public string Subregion { get; set; }
        public List<string> Languages { get; set; }
        public List<string> Borders { get; set; }
        public int Population { get; set; }
    }
}