using System.Text.Json.Serialization;

namespace CountryInfo.Core.Entities
{
    public class Name
    {
        [JsonPropertyName("common")]
        public string Common { get; set; }

        [JsonPropertyName("official")]
        public string Official { get; set; }
    }
}