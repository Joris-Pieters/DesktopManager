using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DesktopManager
{
    public static class Settings
    {
        public static IntPtr MainHandle;

        public static Color ScreenColor1 = Color.FromArgb(123, 144, 193);
        public static Color ScreenColor2 = Color.FromArgb(49, 72, 136);

        public static Color TaskBarColor1 = Color.FromArgb(74, 95, 144);
        public static Color TaskBarColor2 = Color.FromArgb(0, 23, 87);

        public static Color ZoneColor1 = Color.FromArgb(123, 193, 144);
        public static Color ZoneColor2 = Color.FromArgb(49, 136, 72);

        public static Color SelectedZoneColor1 = Color.FromArgb(193, 144, 123);
        public static Color SelectedZoneColor2 = Color.FromArgb(136, 72, 49);

        public static int BorderColorMultiplier = 30;
        public static int BorderColorConstant = 120;

        public static int ProfileImageScreenTextSize = 60;
        public static int ProfileImageZoneTextSize = 24;
        public static int PdFTextSize = 8;

        public static string DefaultDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Desktop Manager";
    }
}
