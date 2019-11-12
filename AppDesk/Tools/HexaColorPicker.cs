using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace AppDesk.Tools
{
    public static class HexaColorPicker
    {
        public static SolidColorBrush TextBoxValidoColor
        {
            get
            {
                return (SolidColorBrush)(new BrushConverter().ConvertFrom("#00ff13"));
            }
        }

        public static SolidColorBrush TextBoxInvalidoColor
        {
            get
            {
                return (SolidColorBrush)(new BrushConverter().ConvertFrom("#ff0000"));
            }
        }

        ///<summary>
        ///Retorna um SolidColorBrush da cor especificada em HexaDecimal
        ///</summary>
        public static SolidColorBrush HexaColorSBrush(string HexaDecimalString)
        {
            if (!(HexaDecimalString[0] == '#'))
            {
                throw new Exception("Invalid HexaDecimal string on ColorBrush");
            }
            return (SolidColorBrush)(new BrushConverter().ConvertFrom(HexaDecimalString));
        }
    }
}
