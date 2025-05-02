using YugiyohApiHandler.DataModels;

namespace YugiohTradingCars.MVVM.ViewModels.DataModels
{
    public class CardViewModel : ViewModelBase
    {

        private readonly Card card;
        public Card Card { get { return this.card; } }
        public CardViewModel(Card card)
        {
            this.card = card;
            this.PrepareCard(card);
        }

        /// <summary>
        /// Diese Methode casted Daten in diese Instanz
        /// </summary>
        /// <param name="card"></param>
        private void PrepareCard(Card card)
        {
            if (card is not null && card.CardImages is not null && card.CardImages.Count >= 1)
                this.ImageUrl = card.CardImages[0].ImageUrl;
        }

        /// <summary>
        /// Bild für die UI
        /// </summary>
        public string ImageUrl
        {
            set => SetProperty(nameof(ImageUrl), value);
            get => GetProperty<string>(nameof(ImageUrl));
        }
    }
}
