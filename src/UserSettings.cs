using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesktopManager
{
    public class UserSettings
    {

        public bool ShowScreenNames { get; set; }
        public bool ShowZoneNames { get; set; }
        public bool StartWithWindows { get; set; }
        public string LastOpenFile { get; set; }

        public UserSettings()
        {
            ShowScreenNames = true;
            ShowZoneNames = true;
            StartWithWindows = true;
            LastOpenFile = "";
        }
       
    }
}
