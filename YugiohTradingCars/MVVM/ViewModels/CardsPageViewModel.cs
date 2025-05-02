using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using YugiohTradingCars.MVVM.ViewModels.DataModels;
using YugiohTradingCars.Repositorys;
using YugiyohApiHandler;
using YugiyohApiHandler.DataModels;

namespace YugiohTradingCars.MVVM.ViewModels
{
    public class CardsPageViewModel : ViewModelBase
    {
        public CardsPageViewModel()
        {
            foreach (Card card in CardRepository.Instance.Get())
            {
                this.CardDatas.Add(new(card));
            }
        }

        public ObservableCollection<CardViewModel> CardDatas { set; get; } = new();

        public ICommand ShowDatas => new RelayCommand(param =>
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{nameof(MainWindowViewModel)},{nameof(ShowDatas)},\nEX :[{ex}]");
            }
        });
    }
}
