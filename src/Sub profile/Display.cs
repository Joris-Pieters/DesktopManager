using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Diagnostics;
using System.Drawing;

namespace DesktopManager
{
    public class Display
    {
    
        public Area Bounds { get; set; }        
        public Area WorkingArea { get; set; }
        public bool Primary { get; set; }
        public string Name { get; set; }

        public Display()
        {
        }

        public Display(string name, Rectangle bounds, Rectangle workingArea, bool primary)
        {
            Bounds = new Area(bounds);
            WorkingArea = new Area(workingArea);
            Primary = primary;
            Name = name;
        }      

    }
}
