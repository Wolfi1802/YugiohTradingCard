using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace YugiohTradingCars.Helper
{

    /// <summary>
    /// Konvertiert Hexadezimal-Farbcodes in WPF Color Objekte um.
    /// </summary>
    public static class ColorHelper
    {
        public static Color FromHex(string hex) 
        {
            hex = hex.TrimStart('#');
            // Prüft ob der Wert 6 Zeichen lang ist wenn ja fehlt der Alpha-Wert und es wird "FF" hinzugefügt das er 8 stellig wird.
            // Wenn er weder 6 noch 8 Stellig ist,wird eine Exception ausgelöst
            if (hex.Length == 6)
                hex = "FF" + hex;
            if (hex.Length != 8)
                throw new ArgumentException("Ungültiger Farbcode!");

            // a = Alpha, r = Rot, g = Grün, b = Blau. Convert.Tobyte konvertiert Hexadezimal nach Byte um.
            // Wandelt den Text von Hexadezimal (Basis 16) in eine Zahl von 0 bis 255 um.

            byte a = Convert.ToByte(hex.Substring(0, 2), 16);
            byte r = Convert.ToByte(hex.Substring(2, 2), 16);
            byte g = Convert.ToByte(hex.Substring(4, 2), 16);
            byte b = Convert.ToByte(hex.Substring(6, 2), 16);

            return Color.FromArgb(a, r, g, b);
        
        }
    }
}
