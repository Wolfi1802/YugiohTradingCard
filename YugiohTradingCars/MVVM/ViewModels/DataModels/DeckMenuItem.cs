using System.Collections.Specialized;
using System.Windows.Input;
using YugiohTradingCars.DataModels;

namespace YugiohTradingCars.MVVM.ViewModels.DataModels
{
    public class DeckMenuItem
    {
        public string DisplayText { get; set; }
        public ICommand Command { get; set; }
        public Deck Deck { get; set; }
    }
}
