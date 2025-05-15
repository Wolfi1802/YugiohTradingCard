using System.Text.Json.Serialization;
using static YugiyohApiHandler.ApiManager;

namespace YugiyohApiHandler.DataModels
{
    public class Card
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public List<string> Typeline { get; set; }
        public string? Type { get; set; }
        public string HumanReadableCardType { get; set; }
        public string? FrameType { get; set; }
        public string? Desc { get; set; }
        public string? Race { get; set; }
        public int? Atk { get; set; }
        public int? Def { get; set; }
        public int? Level { get; set; }
        public string? Attribute { get; set; }
        public string? Archetype { get; set; }
        public string? YgoprodeckUrl { get; set; }
        
       

        [JsonPropertyName("card_sets")]
        public List<CardSet> CardSets { get; set; }

        [JsonPropertyName("card_images")]
        public List<CardImage> CardImages { get; set; }

        [JsonPropertyName("card_prices")]
        public List<CardPrice> CardPrices { get; set; }
    }
}
