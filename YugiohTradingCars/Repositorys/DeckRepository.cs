using System.Collections.ObjectModel;
using YugiohTradingCars.DataModels;
using YugiyohApiHandler.DataModels;

namespace YugiohTradingCars.Repositorys
{
    public class DeckRepository
    {
        private static DeckRepository cardRepository;
        public static DeckRepository Instance
        {
            get
            {
                if (cardRepository is null)
                    cardRepository = new();

                return cardRepository;
            }
        }

        private ObservableCollection<Deck> Decks = new();

        private DeckRepository()
        {

        }

        /// <summary>
        /// Hier wird die Referenz von den decks zurückgegeben
        /// </summary>
        /// <returns>globale Liste</returns>
        public ObservableCollection<Deck> GetDecks()
        {
            return this.Decks;
        }

        /// <summary>
        /// Fügt eine Karte <paramref name="cardToAdd"/> dem Deck <paramref name="idofDeck"/> hinzu
        /// </summary>
        /// <param name="idofDeck">Id des decks</param>
        /// <param name="cardToAdd">Karte für das deck</param>
        public void AddCardToDeck(Guid idofDeck, Card cardToAdd)
        {
            var deck = this.Decks.FirstOrDefault(x => x.Id.Equals(idofDeck));

            if (deck is not null && deck.Cards is not null)
                deck.Cards.Add(cardToAdd);
        }

        /// <summary>
        /// Fügt ein Deck <paramref name="deck"/> der Liste <paramref name="Decks"/> hinzu.
        /// </summary>
        /// <param name="deck">Das Deck welches hinzugefügt wird</param>
        public void AddDeck(Deck deck)
        {
            this.Decks.Add(deck);
        }


    }
}
