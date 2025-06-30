using System.Windows.Input;
using YugiohTradingCars.DataModels;

namespace YugiohTradingCars.MVVM.ViewModels.DataModels
{
    /// <summary>
    /// Dieses Objekt stellt ein Wrapper für die Ui dar , nämlich eines MenuItem's
    /// </summary>
    public class DeckMenuItem
    {
        /// <summary>
        /// Anzeige Name des Decks
        /// </summary>
        public string DisplayText { get; set; }

        /// <summary>
        /// Dies soll als Command zum hinzufügen zum deck genutzt werden
        /// </summary>
        public ICommand Command { get; set; }

        /// <summary>
        /// Objekt der des Decks, worin die Karten enthalten sind
        /// </summary>
        public Deck Deck { get; set; }
    }
}
