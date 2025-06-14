﻿using System.Diagnostics;
using System.Windows.Media;
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
        static List<string> test = new();
        private void PrepareBackground(Card card)
        {
            if (card is not null)
            {

                switch (card.Type)
                {//TODO[TS] refactoring als enum
                    case "Trap Card": this.CardBackgroundColor = Brushes.Red; break;
                    case "Spell Card": this.CardBackgroundColor = Brushes.LightBlue; break;
                    case "Normal Monster": this.CardBackgroundColor = Brushes.Red; break;
                    case "Effect Monster": this.CardBackgroundColor = Brushes.Red; break;
                    case "XYZ Monster": this.CardBackgroundColor = Brushes.Red; break;
                    case "Pendulum Effect Monster": this.CardBackgroundColor = Brushes.Red; break;
                    case "Synchro Pendulum Effect Monster": this.CardBackgroundColor = Brushes.Red; break;
                    case "Synchro Monster": this.CardBackgroundColor = Brushes.Red; break;
                    case "Tuner Monster": this.CardBackgroundColor = Brushes.Red; break;
                    case "Fusion Monster": this.CardBackgroundColor = Brushes.Red; break;
                    case "Ritual Monster": this.CardBackgroundColor = Brushes.Red; break;
                    case "Flip Effect Monster": this.CardBackgroundColor = Brushes.Red; break;
                    case "Skill Card": this.CardBackgroundColor = Brushes.Red; break;
                    case "Link Monster": this.CardBackgroundColor = Brushes.Red; break;
                    case "Union Effect Monster": this.CardBackgroundColor = Brushes.Red; break;
                    case "Synchro Tuner Monster": this.CardBackgroundColor = Brushes.Red; break;
                    case "Gemini Monster": this.CardBackgroundColor = Brushes.Red; break;
                    case "Normal Tuner Monster": this.CardBackgroundColor = Brushes.Red; break;
                    case "Spirit Monster": this.CardBackgroundColor = Brushes.Red; break;
                    case "Ritual Effect Monster": this.CardBackgroundColor = Brushes.Red; break;
                    case "Token": this.CardBackgroundColor = Brushes.Red; break;
                    case "Pendulum Effect Fusion Monster": this.CardBackgroundColor = Brushes.Red; break;
                    case "Toon Monster": this.CardBackgroundColor = Brushes.Red; break;
                    case "Pendulum Normal Monster": this.CardBackgroundColor = Brushes.Red; break;
                    case "Pendulum Tuner Effect Monster": this.CardBackgroundColor = Brushes.Red; break;
                    case "XYZ Pendulum Effect Monster": this.CardBackgroundColor = Brushes.Red; break;
                    case "Pendulum Effect Ritual Monster": this.CardBackgroundColor = Brushes.Red; break;
                    case "Pendulum Flip Effect Monster": this.CardBackgroundColor = Brushes.Red; break;
                    case "Flip Tuner Effect Monster": this.CardBackgroundColor = Brushes.Red; break;
                    default:
                        Debug.WriteLine($"[{nameof(CardViewModel)}] [{nameof(PrepareBackground)}] [{card.Type}] muss hinzugefügt werden, ist aktuell unbekannt!");
                        this.CardBackgroundColor = Brushes.Transparent; break;
                }

            }

        }

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
            set => SetProperty(nameof(CardBackgroundColor), value);
            get => GetProperty<Brush>(nameof(CardBackgroundColor));
        }
    }
}
