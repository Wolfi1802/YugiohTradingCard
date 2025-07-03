using System.Globalization;
using System.Windows.Data;

namespace YugiohTradingCars.Helper
{
    public class PriceShartConverter : IValueConverter
    {


        /// <summary>
        /// Von Model zu UI
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"{value} €";
        }

        /// <summary>
        /// Von ui zu modell
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString();
        }
    }
}
