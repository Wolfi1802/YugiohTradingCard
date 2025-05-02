using System.Text.Json.Serialization;

namespace YugiyohApiHandler.DataModels
{
    public class CardSet
    {
        [JsonPropertyName("set_name")]
        public string? SetName { get; set; }

        [JsonPropertyName("set_code")]
        public string? SetCode { get; set; }

        [JsonPropertyName("set_rarity")]
        public string? SetRarity { get; set; }

        [JsonPropertyName("set_rarity_code")]
        public string? SetRarityCode { get; set; }

        [JsonPropertyName("set_price")]
        public string? SetPrice { get; set; }
    }
}
