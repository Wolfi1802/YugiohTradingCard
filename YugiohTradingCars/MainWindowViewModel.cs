using System.Diagnostics;
using System.Windows;
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

        public Visibility DebugVisibility
        {
            set => SetProperty(nameof(DebugVisibility), value);
            get => GetProperty<Visibility>(nameof(DebugVisibility));
        }

        public DebugViewModel DebugViewModel = new DebugViewModel();
        public CardsPageViewModel CardViewModel = new CardsPageViewModel();
        public MyCardPageViewModel MyCardViewModel = new MyCardPageViewModel();
        private EventRepository eventRepository { get { return EventRepository.Instance; } }

        public MainWindowViewModel()
        {
            this.CurrentPage = this.CardViewModel;
            this.WindowTitle = $"{PROJECT_TITLE} - {ProjectConfigs.CurrentVersion}";
            this.eventRepository.MainWindowMessage += this.OnMainWindowMessage;
            this.DebugVisibility = ProjectConfigs.IsDebugBuild ? Visibility.Visible : Visibility.Collapsed;
        }

        public ICommand ShowDebugCommand => new RelayCommand(param =>
        {
            try
            {
                this.CurrentPage = this.DebugViewModel;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{nameof(MainWindowViewModel)},{nameof(ShowDebugCommand)},\nEX :[{ex}]");
            }
        });

        public ICommand ShowAllCardsCommand => new RelayCommand(param =>
        {
            try
            {
                this.CurrentPage = this.CardViewModel;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{nameof(MainWindowViewModel)},{nameof(ShowAllCardsCommand)},\nEX :[{ex}]");
            }
        });

        public ICommand ShowMyCardsCommand => new RelayCommand(param =>
        {
            try
            {
                this.CurrentPage = this.MyCardViewModel;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{nameof(MainWindowViewModel)},{nameof(ShowMyCardsCommand)},\nEX :[{ex}]");
            }
        });

        private void OnMainWindowMessage(object sender, string? message)
        {
            if (!string.IsNullOrEmpty(message))
                this.GlobalUserMessage = message;
        }
    }
}
