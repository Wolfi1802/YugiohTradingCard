using System.Collections.ObjectModel;
using YugiyohApiHandler.DataModels;

namespace YugiohTradingCars.DataModels
{
    public class Deck
    {
        public Deck()
        {
            this.Id = Guid.NewGuid();
        }

        public Deck(Guid loadedGuid)//[TS] Vorbereitet für das laden
        {
            this.Id = loadedGuid;
        }

        public Guid Id { private set; get; }
        public string Name { set; get; }
        public ObservableCollection<Card> Cards { set; get; } = new();
    }
}
