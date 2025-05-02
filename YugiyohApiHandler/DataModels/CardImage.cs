using System.Text.Json.Serialization;

namespace YugiyohApiHandler.DataModels
{
    public class CardImage
    {
        public int? Id { get; set; }

        [JsonPropertyName("image_url")]
        public string? ImageUrl { get; set; }

        [JsonPropertyName("image_url_small")]
        public string? ImageUrlSmall { get; set; }

        [JsonPropertyName("image_url_cropped")]
        public string? ImageUrlCropped { get; set; }
    }
}
