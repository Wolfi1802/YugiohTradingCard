using System.Diagnostics;
using System.Windows.Input;
using YugiohTradingCars.MVVM;
using YugiohTradingCars.MVVM.ViewModels;

namespace YugiohTradingCars
{
    public class MainWindowViewModel : ViewModelBase
    {

        public ViewModelBase CurrentPage
        {
            set => SetProperty(nameof(CurrentPage), value);
            get => GetProperty<ViewModelBase>(nameof(CurrentPage));
        }

        public string GlobalUserMessage
        {
            set => SetProperty(nameof(GlobalUserMessage), value);
            get => GetProperty<string>(nameof(GlobalUserMessage));
        }

        public static EventHandler ClosePageEvent;
        public static EventHandler<string> SendUserMessageEvent;

        public HomeViewModel HomeViewModel = new HomeViewModel();
        public TestViewModel TestViewModel = new TestViewModel();

        public MainWindowViewModel()
        {
            this.CurrentPage = this.HomeViewModel;

            ClosePageEvent += (o, e) =>
            {
                this.ShowHomeCommand.Execute(null);
            };

            SendUserMessageEvent += (o, e) =>
            {
                this.GlobalUserMessage = e;
            };
        }

        public ICommand ShowHomeCommand => new RelayCommand(param =>
        {
            try
            {
                this.CurrentPage = this.HomeViewModel;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{nameof(MainWindowViewModel)},{nameof(ShowHomeCommand)},\nEX :[{ex}]");
            }
        });

        public ICommand ShowTestCommand => new RelayCommand(param =>
        {
            try
            {
                this.CurrentPage = this.TestViewModel;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{nameof(MainWindowViewModel)},{nameof(ShowTestCommand)},\nEX :[{ex}]");
            }
        });
    }
}
