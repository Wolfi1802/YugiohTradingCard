using DataBaseBinder;
using System.Data.Common;
using System.Diagnostics;
using System.Windows.Input;
using YugiohTradingCars.Repositorys;

namespace YugiohTradingCars.MVVM.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private EventRepository eventRepository { get { return EventRepository.Instance; } }
        private DBRepository dbRepository { get { return DBRepository.Instance; } }

        public ICommand ShowMessage => new RelayCommand(param =>
        {
            try
            {
                this.dbRepository.LoadDatas();
                this.eventRepository.TriggerMainWindowMessage("Global Message Test");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{nameof(HomeViewModel)},{nameof(ShowMessage)},\nEX :[{ex}]");
            }
        });
    }
}
