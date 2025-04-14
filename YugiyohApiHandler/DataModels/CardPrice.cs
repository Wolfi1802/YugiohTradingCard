using System.Text.Json.Serialization;

namespace YugiyohApiHandler.DataModels
{
    public class CardPrice
    {
        [JsonPropertyName("cardmarket_price")]
        public string CardmarketPrice { get; set; }

        [JsonPropertyName("tcgplayer_price")]
        public string TcgplayerPrice { get; set; }

        [JsonPropertyName("ebay_price")]
        public string EbayPrice { get; set; }

        [JsonPropertyName("amazon_price")]
        public string AmazonPrice { get; set; }

        [JsonPropertyName("coolstuffinc_price")]
        public string CoolstuffincPrice { get; set; }
    }
}
