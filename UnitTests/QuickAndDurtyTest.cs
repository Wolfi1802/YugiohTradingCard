using YugiyohApiHandler;
using YugiyohApiHandler.DataModels;

namespace UnitTests
{
    public class Tests
    {
        private const string TEST_STRING = "{\"data\":[{\"id\":34022970,\"name\":\"Ext Ryzeal\",\"typeline\":[\"Pyro\",\"Effect\"],\"type\":\"Effect Monster\",\"humanReadableCardType\":\"Effect Monster\",\"frameType\":\"effect\",\"desc\":\"You can Special Summon this card (from your hand) by sending 1 Xyz Monster from your Extra Deck to the GY. If Summoned this way, you cannot Special Summon from the Extra Deck for the rest of this turn, except Rank 4 Xyz Monsters. You can only Special Summon \\\"Ext Ryzeal\\\" once per turn this way. If this card is Normal or Special Summoned and you control no other face-up monsters, except Level/Rank 4 monsters: You can add 1 FIRE Thunder monster from your Deck to your hand. You can only use this effect of \\\"Ext Ryzeal\\\" once per turn.\",\"race\":\"Pyro\",\"atk\":500,\"def\":2000,\"level\":4,\"attribute\":\"LIGHT\",\"archetype\":\"Ryzeal\",\"ygoprodeck_url\":\"https://ygoprodeck.com/card/ext-ryzeal-14636\",\"card_sets\":[{\"set_name\":\"Crossover Breakers\",\"set_code\":\"CRBR-EN004\",\"set_rarity\":\"Collector's Rare\",\"set_rarity_code\":\"(CR)\",\"set_price\":\"0\"},{\"set_name\":\"Crossover Breakers\",\"set_code\":\"CRBR-EN004\",\"set_rarity\":\"Quarter Century Secret Rare\",\"set_rarity_code\":\"\",\"set_price\":\"0\"},{\"set_name\":\"Crossover Breakers\",\"set_code\":\"CRBR-EN004\",\"set_rarity\":\"Ultra Rare\",\"set_rarity_code\":\"(UR)\",\"set_price\":\"0\"}],\"banlist_info\":{\"ban_tcg\":\"Semi-Limited\",\"ban_ocg\":\"Limited\"},\"card_images\":[{\"id\":34022970,\"image_url\":\"https://images.ygoprodeck.com/images/cards/34022970.jpg\",\"image_url_small\":\"https://images.ygoprodeck.com/images/cards_small/34022970.jpg\",\"image_url_cropped\":\"https://images.ygoprodeck.com/images/cards_cropped/34022970.jpg\"}],\"card_prices\":[{\"cardmarket_price\":\"11.53\",\"tcgplayer_price\":\"10.69\",\"ebay_price\":\"0.00\",\"amazon_price\":\"0.00\",\"coolstuffinc_price\":\"0.00\"     }\r\n      ]\r\n    }\r\n  ]\r\n}";
        [TestCase(null, null)]
        [TestCase(null, "Kein Json")]
        [TestCase(1, TEST_STRING)]//[TS]Wenn der String zu lang ist, kommen hier Fehlermeldungen...
        public async Task TestConvert(int? expectedResult, string? datas)
        {
            ApiManager apiManager = new();
            IList<Card>? result = await apiManager.Convert(datas);

            if (result is null)
                Assert.That(expectedResult is null, $"[{expectedResult}] ist nicht null");
            else
            {
                Assert.That(result.Count == expectedResult, $"[{nameof(result.Count)}]:[{result.Count}] == [{nameof(expectedResult)}]:[{expectedResult}]");
            }
        }
    }
}
