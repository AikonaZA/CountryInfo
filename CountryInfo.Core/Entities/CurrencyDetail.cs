using System.Text.Json.Serialization;

namespace CountryInfo.Core.Entities
{
    public class CurrencyDetail
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
    }
}