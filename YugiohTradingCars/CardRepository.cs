using System.Collections.ObjectModel;
using YugiyohApiHandler;
using YugiyohApiHandler.DataModels;

namespace YugiohTradingCars
{
    public class CardRepository
    {
        private static CardRepository cardRepository;
        public static CardRepository Instance
        {
            get
            {
                if (cardRepository is null)
                    cardRepository = new();

                return cardRepository;
            }
        }

        private ObservableCollection<Card> CardData = new();
        private ApiManager ApiManager = new();
        private CardRepository()
        {
            this.LoadDatas();
        }

        public ObservableCollection<Card> Get()
        {
            return new (CardData);
        }

private async Task LoadDatas()
        {
            CardData = new(await this.ApiManager.Get());
        }


    }
}
