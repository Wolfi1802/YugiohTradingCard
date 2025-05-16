using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YugiohTradingCars.DataModels;
using YugiohTradingCars.Repositorys;

namespace YugiohTradingCars.MVVM.ViewModels
{
    public class MyDecksViewModel : ViewModelBase
    {
        public MyDecksViewModel()
        {
            this.Decks = DeckRepository.Instance.GetDecks();
        }

        public string DeckName
        {
            set => SetProperty(nameof(DeckName), value);
            get => GetProperty<string>(nameof(DeckName));
        }

        public ObservableCollection<Deck> Decks { set; get; } = new();

        public ICommand CreateDeck => new RelayCommand(param =>
        {
            try
            {
                if (string.IsNullOrEmpty(this.DeckName))
                            EventRepository.Instance.TriggerMainWindowMessage($"Bitte geben Sie einen Namen für das Deck ein.");//TODO[TS] ALS KOSNTANTE AUSLAGERN
                else
                {
                    Deck deck = new() { Name = this.DeckName };
                    DeckRepository.Instance.AddDeck(deck);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{nameof(MyDecksViewModel)},{nameof(CreateDeck)},\nEX :[{ex}]");
            }
        });
    }
}
