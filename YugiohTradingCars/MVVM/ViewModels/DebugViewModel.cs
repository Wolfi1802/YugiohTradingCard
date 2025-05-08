using DataBaseBinder;
using System.Data;
using System.Diagnostics;
using System.Windows.Input;
using YugiohTradingCars.Repositorys;

namespace YugiohTradingCars.MVVM.ViewModels
{
    public class DebugViewModel : ViewModelBase
    {
        private EventRepository eventRepository { get { return EventRepository.Instance; } }
        private DBRepository dbRepository { get { return DBRepository.Instance; } }

        public string QueryText
        {
            set => SetProperty(nameof(QueryText), value);
            get => GetProperty<string>(nameof(QueryText));
        }

        public List<DataTable> CurrentTables
        {
            get => base.GetProperty<List<DataTable>>(nameof(CurrentTables));
            set => base.SetProperty(nameof(CurrentTables), value);
        }

        public ICommand ExecuteQuery => new RelayCommand(param =>
        {
            try
            {
                if (string.IsNullOrEmpty(this.QueryText))
                {
                    this.eventRepository.TriggerMainWindowMessage("Query is null");
                    return;
                }

                this.CurrentTables = new() { this.dbRepository.ExecuteQuery(this.QueryText) };
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{nameof(DebugViewModel)},{nameof(ExecuteQuery)},\nEX :[{ex}]");
            }
        });
    }
}
