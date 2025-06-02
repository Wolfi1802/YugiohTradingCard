using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using YugiohTradingCars.DataModels;
using System.Windows.Media;
using YugiohTradingCars.MVVM.ViewModels.DataModels;
using YugiohTradingCars.Repositorys;
using YugiyohApiHandler.DataModels;

namespace YugiohTradingCars.MVVM.ViewModels
{
    public class CardsPageViewModel : ViewModelBase
    {
        /// <summary>
        /// MS Delay für die Suche
        /// </summary>
        private const int MILISECONDS_DELAY_FOR_SEARCH = 400;

        /// <summary>
        /// Instanz zum abbrechen asynchroner vorgänge
        /// </summary>
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        /// <summary>
        /// ItemsSource um Karten zum Deck hinzuzufügen
        /// </summary>
        public ObservableCollection<DeckMenuItem> AddDecksItemsSource { set; get; } = new();

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
                this.ResetSearch(value);
                base.SetProperty(nameof(SearchText), value);
            }
            get => base.GetProperty<string>(nameof(SearchText));
        }

        public CardsPageViewModel()
        {
            this.ShowDetails(false);//[TS] Default immer überschreiben

            foreach (Card card in CardRepository.Instance.Get()) //[SK] Stammdatensatz GET
            {
                this.CardDatas.Add(new(card));
            }

            foreach (Deck deck in DeckRepository.Instance.GetDecks())
            {
                this.AddDecksItemsSource.Add(new() { DisplayText = $"Füge Karte \"{deck.Name}\" hinzu", Deck = deck, Command = this.GetRelayCommand(deck) });
            }
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

        private async void ResetSearch(string searchText)
        {
            try
            {
                if (await this.CanSearch(searchText))
                {
                    this.FilterCards(searchText);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[{nameof(CardsPageViewModel)}] [{nameof(ResetSearch)}] [{ex.Message}]");
            }
        }

        private async Task<bool> CanSearch(string searchText)
        {
            await Task.Delay(MILISECONDS_DELAY_FOR_SEARCH);
            return searchText.Equals(this.SearchText);
        }

        private void FilterCards(string searchText) //[SK] Filtert die Suche
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

        private RelayCommand GetRelayCommand(Deck deck)
        {
            RelayCommand command = new(param =>
            {
                try
                {
                    if (this.SelectedCard is null)
                        return;
                    else
                    {

                        if (deck is not null)
                        {
                            DeckRepository.Instance.AddCardToDeck(deck.Id, this.SelectedCard.Card);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"{nameof(CardsPageViewModel)},{nameof(GetRelayCommand)},\nEX :[{ex}]");
                }
            });
            return command;
        }

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
