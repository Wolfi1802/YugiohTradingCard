using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Input;
using YugiohTradingCars.MVVM.ViewModels.DataModels;
using YugiohTradingCars.Repositorys;
using YugiyohApiHandler.DataModels;

namespace YugiohTradingCars.MVVM.ViewModels
{
    public class CardsPageViewModel : ViewModelBase
    {
        public CardsPageViewModel()
        {
            this.ShowDetails(false);//[TS] Default immer überschreiben

            foreach (Card card in CardRepository.Instance.Get()) //[SK] Stammdatensatz GET
            {
                this.CardDatas.Add(new(card));
            }
        }
        /// <summary>
        /// UI Datensatz CardDatas
        /// </summary>
        public ObservableCollection<CardViewModel> CardDatas { set; get; } = new();

        public CardViewModel SelectedCard
        {
            set
            {
                if (value is not null && this.SelectedCard != value)
                    this.ShowDetails(true);
                else
                    this.ShowDetails(false);

                base.SetProperty(nameof(this.SelectedCard), value);
            }
            get => base.GetProperty<CardViewModel>(nameof(this.SelectedCard));
        }

        public Visibility DetailsVisibility
        {
            set => SetProperty(nameof(DetailsVisibility), value);
            get => GetProperty<Visibility>(nameof(DetailsVisibility));
        }

        public string SearchText //[SK]
        {
            set
            {
                SetProperty(nameof(SearchText), value);
                FilterCards();
            }
            get => GetProperty<string>(nameof(SearchText));
        }

        /// <summary>
        /// Steuert die Anzeige der Details
        /// </summary>
        /// <param name="isVisible"></param>
        private void ShowDetails(bool isVisible)
        {
            //TODO[TS] umbauen und als extra fenster anzeigen ?
            this.DetailsVisibility = isVisible ? Visibility.Visible : Visibility.Collapsed;
        }

        private void FilterCards() //[SK] Filtert die Suche
        {
            //var filteredCards = CardRepository.Instance.Get()
            //    .Where(card => card.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase))
            //    .Select(card => new CardViewModel(card))
            //    .ToList();

            CardDatas.Clear();

            ObservableCollection<Card> allCards = CardRepository.Instance.Get();
           
            foreach (Card card in allCards)
            {
                if (card.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase))
                {
                    CardDatas.Add(new CardViewModel(card));
                }
            }
        }
        public ICommand SearchDatas => new RelayCommand(param =>
        {
            try
            {
                FilterCards();
                Debug.WriteLine(SearchText); // [SK] Test für die Ausgabe der Suche
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{nameof(CardsPageViewModel)},{nameof(SearchDatas)},\nEX :[{ex}]");
            }
        });
        /// <summary>
        /// Setzt die Suche auf die ursprünlgiche Vollständige Liste zurück,Fehler noch zu beheben: Erst nach löschen der Zeile
        /// und erneutes klicken auf den "Suche" Button wird die volle Liste wieder angezeigt.
        /// </summary>
        private void ResetSearch()
        {
            CardDatas.Clear();
            foreach (Card card in CardRepository.Instance.Get()) //[SK] Stammdatensatz neu laden
            {
                CardDatas.Add(new CardViewModel(card));
            }
        }

        public ICommand ShowDatas => new RelayCommand(param =>
        {
            try
            {

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{nameof(CardsPageViewModel)},{nameof(ShowDatas)},\nEX :[{ex}]");
            }
        });

        public ICommand CloseDetails => new RelayCommand(param =>
        {
            try
            {
                this.ShowDetails(false);
                this.SelectedCard = null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{nameof(CardsPageViewModel)},{nameof(CloseDetails)},\nEX :[{ex}]");
            }
        });
    }
}
