using System.Diagnostics;
using System.Reflection;
using System.Windows.Input;
using YugiohTradingCars.MVVM;
using YugiohTradingCars.MVVM.ViewModels;
using YugiohTradingCars.Repositorys;

namespace YugiohTradingCars
{
    public class MainWindowViewModel : ViewModelBase
    {
        public const string PROJECT_TITLE = "Trading Cards";
        public ViewModelBase CurrentPage
        {
            set => SetProperty(nameof(CurrentPage), value);
            get => GetProperty<ViewModelBase>(nameof(CurrentPage));
        }

        public string? WindowTitle
        {
            set => SetProperty(nameof(WindowTitle), value);
            get => GetProperty<string?>(nameof(WindowTitle));
        }

        public string GlobalUserMessage
        {
            set => SetProperty(nameof(GlobalUserMessage), value);
            get => GetProperty<string>(nameof(GlobalUserMessage));
        }

        public HomePageViewModel HomeViewModel = new HomePageViewModel();
        public CardsPageViewModel CardViewModel = new CardsPageViewModel();
        private EventRepository eventRepository { get { return EventRepository.Instance; } }

        public MainWindowViewModel()
        {
            this.CurrentPage = this.HomeViewModel;
            this.WindowTitle = $"{PROJECT_TITLE} - {Assembly.GetExecutingAssembly()?.GetName()?.Version}";
            this.eventRepository.MainWindowMessage += this.OnMainWindowMessage;
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
                this.CurrentPage = this.CardViewModel;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{nameof(MainWindowViewModel)},{nameof(ShowTestCommand)},\nEX :[{ex}]");
            }
        });

        private void OnMainWindowMessage(object sender, string? message)
        {
            if (!string.IsNullOrEmpty(message))
                this.GlobalUserMessage = message;
        }
    }
}
