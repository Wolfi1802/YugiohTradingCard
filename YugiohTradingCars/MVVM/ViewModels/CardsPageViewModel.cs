using System.Collections.ObjectModel;
using System.Diagnostics;
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

        public string SearchText
        {
            set => SetProperty(nameof(SearchText), value);
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
        public ICommand SearchDatas => new RelayCommand(param =>
        {
            try
            {
                Debug.WriteLine(SearchText); // [SK] Test für die Ausgabe der Suche
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{nameof(CardsPageViewModel)},{nameof(SearchDatas)},\nEX :[{ex}]");
            }
        });


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
