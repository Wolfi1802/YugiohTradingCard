using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YugiohTradingCars.MVVM.ViewModels
{
    public class SplashScreenViewModel : ViewModelBase
    {
        public SplashScreenViewModel()
        {
            this.SplashText = "Vorbereitung läuft";//TODO[TS]
        }

        /// <summary>
        /// Text für den SplashScreen
        /// </summary>
        public string SplashText
        {
            set => SetProperty(nameof(SplashText), value);
            get => GetProperty<string>(nameof(SplashText));
        }
    }
}
