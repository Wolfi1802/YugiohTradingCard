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
            //this.SplashText = "Vorbereitung läuft";//TODO[TS]
            // Image ist nur lokal Verfügbar!
        }

        /// <summary>
        /// Text für den SplashScreen
        /// </summary>
        public string SplashImagePath
        {
            set => SetProperty(nameof(SplashImagePath), value);
            get => GetProperty<string>(nameof(SplashImagePath));
        }
    }
}
