using System.Net;
using System.Text.Json;
using YugiyohApiHandler.DataModels;

namespace YugiyohApiHandler
{
    /// <summary>
    /// Kommuniziert mit der Api
    /// </summary>
    public class ApiManager
    {
        public const string GET_ALL_CARDS = "https://db.ygoprodeck.com/api/v7/cardinfo.php";//ACHTUNG DER SCHEI? IS ZU GROß...
        public const string GET_RUSH_DUEL_FORMAT = "https://db.ygoprodeck.com/api/v7/cardinfo.php?format=Speed Duel";
        public const string GET_TCG_DATE = "https://db.ygoprodeck.com/api/v7/cardinfo.php?&startdate=2024-12-1&enddate=2025-01-01&dateregion=tcg";

        private HttpClient httpClient;
        public ApiManager()
        {
            this.httpClient = new();
            this.httpClient.Timeout = new TimeSpan(0, 0, 100);
        }

        public async Task<IList<Card>?> Get()
        {
            string datas = string.Empty;

            try
            {
                HttpResponseMessage result = await this.httpClient.GetAsync(GET_TCG_DATE);
                var test = result.EnsureSuccessStatusCode();

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    datas = await result.Content.ReadAsStringAsync();
                    return await this.Convert(datas);
                }

                await Task.Delay(1000);//[TS] Api darf nur jede 1 sek maximal 20 request machen, also machen wir pro sekunde einen.
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{nameof(ApiManager)}][{nameof(Get)}] - [{ex.InnerException}]");
            }
            return null;
        }

        private async Task<IList<Card>?> Convert(string datas)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var myCards = JsonSerializer.Deserialize<CardData>(datas, options);
                if (myCards is not null)
                    return myCards.Data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{nameof(ApiManager)}][{nameof(Convert)}] - [{ex.InnerException}]");
            }

            return null;
        }
    }
}
