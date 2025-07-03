using System.Diagnostics;
using System.Windows.Media;
using YugiohTradingCars.Helper;
using YugiyohApiHandler.DataModels;

namespace YugiohTradingCars.MVVM.ViewModels.DataModels
{
    public class CardViewModel : ViewModelBase
    {

        private readonly Card card;
        private readonly BrushHelper brushHelper;
        public Card Card { get { return this.card; } }


        /// <summary>
        /// Bild für die UI
        /// </summary>
        public string ImageUrl
        {
            set => SetProperty(nameof(ImageUrl), value);
            get => GetProperty<string>(nameof(ImageUrl));
        }

        /// <summary>
        /// Hintergrund Farbe
        /// </summary>
        public Brush CardBackgroundColor
        {
            set => base.SetProperty(nameof(CardBackgroundColor), value);
            get => base.GetProperty<Brush>(nameof(CardBackgroundColor));
        }

        /// <summary>
        /// Schriftfarbe der UI
        /// </summary>
        public Brush CardTextColor
        {
            set => base.SetProperty(nameof(CardTextColor), value);
            get => base.GetProperty<Brush>(nameof(CardTextColor));
        }

        public CardViewModel(Card card)
        {
            this.brushHelper = new();
            this.card = card;
            this.PrepareCard(card);
            this.PrepareBackground(card);
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

        private void PrepareBackground(Card card)
        {
            if (card is not null)
            {

                switch (card.Type)
                {//TODO[TS] refactoring als enum
                    case "Trap Card":
                        this.CardBackgroundColor =
                            this.brushHelper.GetLinearGradientBrush(
                            ColorHelper.FromHex("a14687"),
                            ColorHelper.FromHex("000000"),
                            new(0, 0), new(0, 2));
                        this.CardTextColor = Brushes.White;
                        break;

                    case "Spell Card":
                        this.CardBackgroundColor =
                            this.brushHelper.GetLinearGradientBrush(
                            ColorHelper.FromHex("32CD32"),
                            ColorHelper.FromHex("000000"),
                            new(0, 0), new(0, 2));
                        this.CardTextColor = Brushes.White;
                        break;

                    case "Normal Monster":
                        this.CardBackgroundColor =
                            this.brushHelper.GetLinearGradientBrush(
                            ColorHelper.FromHex("FFC300"),
                            ColorHelper.FromHex("000000"),
                            new(0, 0), new(0, 2));
                        this.CardTextColor = Brushes.White;
                        break;

                    case "Effect Monster":
                        this.CardBackgroundColor =
                            this.brushHelper.GetLinearGradientBrush(
                            ColorHelper.FromHex("A0522D"),
                            ColorHelper.FromHex("000000"),
                            new(0, 0), new(0, 2));
                        this.CardTextColor = Brushes.White;
                        break;

                    case "XYZ Monster":
                        this.CardBackgroundColor =
                            this.brushHelper.GetLinearGradientBrush(
                            ColorHelper.FromHex("333333"),
                            ColorHelper.FromHex("A9A9A9"),
                            new(0, 0), new(0, 2));
                        this.CardTextColor = Brushes.White;
                        break;

                    case "Pendulum Effect Monster":
                        this.CardBackgroundColor =
                            this.brushHelper.GetLinearGradientBrush(
                            ColorHelper.FromHex("A0522D"),
                            ColorHelper.FromHex("7FFFD4"),
                            new(0, 0), new(0, 2));
                        this.CardTextColor = Brushes.White;
                        break;

                    case "Synchro Pendulum Effect Monster":
                        this.CardBackgroundColor =
                            this.brushHelper.GetLinearGradientBrush(
                            ColorHelper.FromHex("7F7F7F"),
                            ColorHelper.FromHex("7FFFD4"),
                            new(0, 0), new(0, 2));
                        this.CardTextColor = Brushes.White;
                        break;

                    case "Synchro Monster":
                        this.CardBackgroundColor =
                            this.brushHelper.GetLinearGradientBrush(
                            ColorHelper.FromHex("7F7F7F"),
                            ColorHelper.FromHex("FFFFFF"),
                            new(0, 0), new(0, 2));
                        this.CardTextColor = Brushes.White;
                        break;

                    case "Tuner Monster":
                        this.CardBackgroundColor =
                            this.brushHelper.GetLinearGradientBrush(
                            ColorHelper.FromHex("A0522D"),
                            ColorHelper.FromHex("000000"),
                            new(0, 0), new(0, 2));
                        this.CardTextColor = Brushes.White;
                        break;

                    case "Fusion Monster":
                        this.CardBackgroundColor =
                            this.brushHelper.GetLinearGradientBrush(
                            ColorHelper.FromHex("9966CC"),
                            ColorHelper.FromHex("000000"),
                            new(0, 0), new(0, 2));
                        this.CardTextColor = Brushes.White;
                        break;

                    case "Ritual Monster":
                        this.CardBackgroundColor =
                            this.brushHelper.GetLinearGradientBrush(
                            ColorHelper.FromHex("0047AB"),
                            ColorHelper.FromHex("000000"),
                            new(0, 0), new(0, 2));
                        this.CardTextColor = Brushes.White;
                        break;

                    case "Flip Effect Monster":
                        this.CardBackgroundColor =
                            this.brushHelper.GetLinearGradientBrush(
                            ColorHelper.FromHex("A0522D"),
                            ColorHelper.FromHex("000000"),
                            new(0, 0), new(0, 2));
                        this.CardTextColor = Brushes.White;
                        break;

                    case "Skill Card":
                        this.CardBackgroundColor =
                            this.brushHelper.GetLinearGradientBrush(
                            ColorHelper.FromHex("5DADEC"),
                            ColorHelper.FromHex("000000"),
                            new(0, 0), new(0, 2));
                        this.CardTextColor = Brushes.White;
                        break;

                    case "Link Monster":
                        this.CardBackgroundColor =
                            this.brushHelper.GetLinearGradientBrush(
                            ColorHelper.FromHex("007FFF"),
                            ColorHelper.FromHex("000000"),
                            new(0, 0), new(0, 2));
                        this.CardTextColor = Brushes.White;
                        break;

                    case "Union Effect Monster":
                        this.CardBackgroundColor =
                            this.brushHelper.GetLinearGradientBrush(
                            ColorHelper.FromHex("A0522D"),
                            ColorHelper.FromHex("000000"),
                            new(0, 0), new(0, 2));
                        this.CardTextColor = Brushes.White;
                        break;

                    case "Synchro Tuner Monster":
                        this.CardBackgroundColor =
                            this.brushHelper.GetLinearGradientBrush(
                            ColorHelper.FromHex("A0522D"),
                            ColorHelper.FromHex("000000"),
                            new(0, 0), new(0, 2));
                        this.CardTextColor = Brushes.White;
                        break;

                    case "Gemini Monster":
                        this.CardBackgroundColor =
                            this.brushHelper.GetLinearGradientBrush(
                            ColorHelper.FromHex("A0522D"),
                            ColorHelper.FromHex("000000"),
                            new(0, 0), new(0, 2));
                        this.CardTextColor = Brushes.White;
                        break;

                    case "Normal Tuner Monster":
                        this.CardBackgroundColor =
                            this.brushHelper.GetLinearGradientBrush(
                            ColorHelper.FromHex("FFC300"),
                            ColorHelper.FromHex("000000"),
                            new(0, 0), new(0, 2));
                        this.CardTextColor = Brushes.White;
                        break;

                    case "Spirit Monster":
                        this.CardBackgroundColor =
                            this.brushHelper.GetLinearGradientBrush(
                            ColorHelper.FromHex("A0522D"),
                            ColorHelper.FromHex("000000"),
                            new(0, 0), new(0, 2));
                        this.CardTextColor = Brushes.White;
                        break;

                    case "Ritual Effect Monster":
                        this.CardBackgroundColor =
                            this.brushHelper.GetLinearGradientBrush(
                            ColorHelper.FromHex("0047AB"),
                            ColorHelper.FromHex("000000"),
                            new(0, 0), new(0, 2));
                        this.CardTextColor = Brushes.White;
                        break;

                    case "Token":
                        this.CardBackgroundColor =
                            this.brushHelper.GetLinearGradientBrush(
                            ColorHelper.FromHex("8A8A8A"),
                            ColorHelper.FromHex("000000"),
                            new(0, 0), new(0, 2));
                        this.CardTextColor = Brushes.White;
                        break;

                    case "Pendulum Effect Fusion Monster": // Name?
                        this.CardBackgroundColor =
                            this.brushHelper.GetLinearGradientBrush(
                            ColorHelper.FromHex("9966CC"),
                            ColorHelper.FromHex("008B8B"),
                            new(0, 0), new(0, 2));
                        this.CardTextColor = Brushes.White;
                        break;

                    case "Toon Monster":
                        this.CardBackgroundColor =
                            this.brushHelper.GetLinearGradientBrush(
                            ColorHelper.FromHex("A0522D"),
                            ColorHelper.FromHex("000000"),
                            new(0, 0), new(0, 2));
                        this.CardTextColor = Brushes.White;
                        break;

                    case "Pendulum Normal Monster":
                        this.CardBackgroundColor =
                            this.brushHelper.GetLinearGradientBrush(
                            ColorHelper.FromHex("FFC300"),
                            ColorHelper.FromHex("7FFFD4"),
                            new(0, 0), new(0, 2));
                        this.CardTextColor = Brushes.White;
                        break;

                    case "Pendulum Tuner Effect Monster":
                        this.CardBackgroundColor =
                            this.brushHelper.GetLinearGradientBrush(
                            ColorHelper.FromHex("A0522D"),
                            ColorHelper.FromHex("7FFFD4"),
                            new(0, 0), new(0, 2));
                        this.CardTextColor = Brushes.White;
                        break;

                    case "XYZ Pendulum Effect Monster":
                        this.CardBackgroundColor =
                            this.brushHelper.GetLinearGradientBrush(
                            ColorHelper.FromHex("333333"),
                            ColorHelper.FromHex("7FFFD4"),
                            new(0, 0), new(0, 2));
                        this.CardTextColor = Brushes.White;
                        break;

                    case "Pendulum Ritual Effect Monster":
                        this.CardBackgroundColor =
                            this.brushHelper.GetLinearGradientBrush(
                            ColorHelper.FromHex("0047AB"),
                            ColorHelper.FromHex("7FFFD4"),
                            new(0, 0), new(0, 2));
                        this.CardTextColor = Brushes.White;
                        break;

                    case "Pendulum Flip Effect Monster":
                        this.CardBackgroundColor =
                            this.brushHelper.GetLinearGradientBrush(
                            ColorHelper.FromHex("A0522D"),
                            ColorHelper.FromHex("7FFFD4"),
                            new(0, 0), new(0, 2));
                        this.CardTextColor = Brushes.White;
                        break;

                    case "Flip Tuner Effect Monster":
                        this.CardBackgroundColor =
                            this.brushHelper.GetLinearGradientBrush(
                            ColorHelper.FromHex("A0522D"),
                            ColorHelper.FromHex("000000"),
                            new(0, 0), new(0, 2));
                        this.CardTextColor = Brushes.White;
                        break;

                    default:
                        Debug.WriteLine($"[{nameof(CardViewModel)}] [{nameof(PrepareBackground)}] [{card.Type}] muss hinzugefügt werden, ist aktuell unbekannt!");
                        this.CardBackgroundColor = Brushes.Transparent; break;
                }

            }

        }
    }
}
