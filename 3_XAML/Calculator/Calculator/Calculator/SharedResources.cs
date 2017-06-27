using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculator
{
    public static class SharedResources
    {
        public static Color NumberButtonBkColor
        {
            get { return Color.White; }
        }

        public static Color OperatorButtonBkColor
        {
            get { return Color.FromRgb(0xff, 0xa5, 0); }
        }
        
        public static Color ClearButtonBkColor
        {
            get { return Color.FromRgb(128, 128, 128); }
        }

        public static Color EqualsButtonBkColor
        {
            get { return Color.FromRgb(0xff, 0xa5, 0); }
        }

    }
}
