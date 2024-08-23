namespace CountryInfo.Core.Entities
{
    public class Country
    {
        public string Name { get; set; }
        public string Capital { get; set; }
        public long Population { get; set; }
        public List<string> Currencies { get; set; }
        public List<string> Languages { get; set; }
        public List<string> Borders { get; set; }
    }
}