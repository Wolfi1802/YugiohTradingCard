using System.Windows;
using System.Windows.Media;

namespace YugiohTradingCars.Helper
{
    public class BrushHelper
    {
        public LinearGradientBrush GetLinearGradientBrush(Color startColor, Color endColor, Point startPoint, Point endPoint)
        {
            var brush = new LinearGradientBrush
            (
                startColor,
                endColor,
                startPoint,
                endPoint
            );

            return brush;
        }

    }
}
