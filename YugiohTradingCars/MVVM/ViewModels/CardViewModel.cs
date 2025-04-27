using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using YugiohTradingCars.Repositorys;
using YugiyohApiHandler;
using YugiyohApiHandler.DataModels;

namespace YugiohTradingCars.MVVM.ViewModels
{
    public class CardViewModel : ViewModelBase
    {
        public CardViewModel()
        {
            this.CardDatas = CardRepository.Instance.Get();
        }

        public ObservableCollection<Card> CardDatas { set; get; } = new();

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
