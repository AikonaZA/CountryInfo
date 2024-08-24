namespace CountryInfo.Core.Entities
{
    public class Country
    {
        public Name name { get; set; }
        public Dictionary<string, CurrencyDetail> currencies { get; set; }
        public List<string> capital { get; set; }
        public string region { get; set; }
        public string subregion { get; set; }
        public Dictionary<string, string> languages { get; set; }
        public List<string> borders { get; set; }
        public int population { get; set; }
    }
}