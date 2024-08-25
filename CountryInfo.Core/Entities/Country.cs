using System.Text.Json.Serialization;

namespace CountryInfo.Core.Entities
{
    public class Country
    {
        [JsonPropertyName("name")]
        public Name Name { get; set; }

        [JsonPropertyName("currencies")]
        public Dictionary<string, CurrencyDetail> Currencies { get; set; }

        [JsonPropertyName("capital")]
        public List<string> Capital { get; set; }

        [JsonPropertyName("region")]
        public string Region { get; set; }

        [JsonPropertyName("subregion")]
        public string Subregion { get; set; }

        [JsonPropertyName("languages")]
        public Dictionary<string, string> Languages { get; set; }

        [JsonPropertyName("borders")]
        public List<string> Borders { get; set; }

        [JsonPropertyName("population")]
        public long Population { get; set; }
    }
}