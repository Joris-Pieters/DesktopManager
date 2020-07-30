using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Xml.Serialization;

namespace DesktopManager
{
    public class Profile : IDisposable
    {           
        public List<Zone> Zones { get; set; }

        [XmlIgnore]
        public Area TotalArea;

        [XmlIgnore]
        public List<Display> Displays;
                
        public Profile()
        {            
            Displays = new List<Display>();
            Zones = new List<Zone>();
        }

        public void Dispose()
        {
            foreach (Zone z in Zones)
            {
                z.Dispose();
            }
            Zones.Clear();
        }

        public void UpdateDisplays()
        {           
            TotalArea = new Area();
            for (int i = 0; i < Displays.Count; i++)
            {               
                TotalArea = new Area(
                    Math.Min(TotalArea.X, Displays[i].Bounds.X),
                    Math.Min(TotalArea.Y, Displays[i].Bounds.Y),
                    Math.Max(TotalArea.Width, Displays[i].Bounds.Right()),
                    Math.Max(TotalArea.Height, Displays[i].Bounds.Bottom()));
            }
            TotalArea.Width -= TotalArea.X;
            TotalArea.Height -= TotalArea.Y;
        }

        public void UpdateDisplays(Screen[] screens)
        {
            Displays = new List<Display>();
            for (int i = 0; i <= screens.GetUpperBound(0); i++)
            {
                var name = screens[i].DeviceName.Split('\\');
                Displays.Add(new Display(name[name.Count() - 1], screens[i].Bounds, screens[i].WorkingArea, screens[i].Primary));
            }
            UpdateDisplays();
        }
        
        public void AddZone(Zone zone)
        {
            Zones.Add(zone);
        }        

        public void AddMultipleZones(string display, int horizontal, int vertical)
        {
            int id = -1;
            for (int i = 0; i < Displays.Count(); i++)
            {
                if (Displays[i].Name == display)
                {
                    id = i;
                    break;
                }
            }
            if (id != -1)
            {
                AddMultipleZones(id, horizontal, vertical);
            }
        }

        public void AddMultipleZones(int display, int horizontal, int vertical)
        { 
            int pixX = Displays[display].WorkingArea.Width / horizontal;
            int pixY = Displays[display].WorkingArea.Height / vertical;
            int resX = Displays[display].WorkingArea.Width % horizontal;
            int resY = Displays[display].WorkingArea.Height % vertical;
            int x = 0;
            int y = 0;

            for (int j = 0; j < vertical; j++)
            {
                int h = pixY;
                if (resY > 0)
                {
                    h++;
                    resY--;
                }
            for (int i = 0; i < horizontal; i++)
            {
                int w = pixX;
                if (resX > 0)
                {
                    w++;
                    resX--;
                }
                
                    Zones.Add(new Zone(FreeZoneName(), new Area(
                        Displays[display].WorkingArea.X + x,
                        Displays[display].WorkingArea.Y + y,
                        w, h)));
                    x += w;                        
                }
                x = 0;
                y += h;
            }
        }

        public void AddMultipleZones(string display, ZoneTemplate template)
        {
            int id = -1;
            for (int i = 0; i < Displays.Count(); i++)
            {
                if (Displays[i].Name == display)
                {
                    id = i;
                    break;
                }
            }
            if (id != -1)
            {
                AddMultipleZones(id, template);
            }
        }

        public void AddMultipleZones(int display, ZoneTemplate template)
        {
            foreach (RelativeArea relArea in template.RelativeAreaList)
            {
                var area = relArea.ToArea(Displays[display].WorkingArea.Width, Displays[display].WorkingArea.Height);
                Zones.Add(new Zone(FreeZoneName(), new Area(
                    Displays[display].WorkingArea.X + area.X,
                    Displays[display].WorkingArea.Y + area.Y,
                    area.Width, area.Height)));
            }
        }

        public void SetLast(string zone)
        {
            for (int i = 0; i < Zones.Count; i++)
            {
                if (Zones[i].ToString() == zone)
                {                    
                    Zone tmp = Zones[i];
                    Zones.RemoveAt(i);
                    Zones.Add(tmp);
                    break;
                }
            }
        }

        public void SetLast(int zone)
        {
            Zone tmp = Zones[zone];
            Zones.RemoveAt(zone);
            Zones.Add(tmp);            
        }

        public Image ProfileImage(bool screenNames, bool zoneNames, bool highLight = false)
        {
            UpdateDisplays();
            foreach (Zone zone in Zones)
            {
                if (zone.Area.X < TotalArea.X)
                {
                    TotalArea.Width += TotalArea.X - zone.Area.X;
                    TotalArea.X = zone.Area.X;
                }
                if (zone.Area.Y < TotalArea.Y)
                {
                    TotalArea.Height += TotalArea.Y - zone.Area.Y;
                    TotalArea.Y = zone.Area.Y;
                }
                if (zone.Area.Right() > TotalArea.Right())
                {
                    TotalArea.Width += zone.Area.Right() - TotalArea.Right();
                }
                if (zone.Area.Bottom() > TotalArea.Bottom())
                {
                    TotalArea.Height += zone.Area.Bottom() - TotalArea.Bottom();
                }
            }

            Image img = (Image)(new Bitmap(TotalArea.Width, TotalArea.Height));

            using (Graphics g = Graphics.FromImage(img))
            {
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;               

                foreach (Display display in Displays)
                {
                    Area taskbar = Difference(display.Bounds, display.WorkingArea);
                    if (taskbar.Width > 0 && taskbar.Height > 0)
                    {
                        g.FillRectangle(new LinearGradientBrush(
                            new Point(taskbar.X - TotalArea.X, taskbar.Y - TotalArea.Y),
                            new Point(taskbar.Right() - TotalArea.X, taskbar.Bottom() - TotalArea.Y),
                            Settings.TaskBarColor1, Settings.TaskBarColor2), new Rectangle(
                                taskbar.X - TotalArea.X,
                                taskbar.Y - TotalArea.Y,
                                taskbar.Width,
                                taskbar.Height));
                    }

                    g.FillRectangle(new LinearGradientBrush(
                        new Point(display.WorkingArea.X - TotalArea.X, display.WorkingArea.Y - TotalArea.Y),
                        new Point(display.WorkingArea.Right() - TotalArea.X, display.WorkingArea.Bottom() - TotalArea.Y),
                        Settings.ScreenColor1, Settings.ScreenColor2), new Rectangle(
                        display.WorkingArea.X - TotalArea.X,
                        display.WorkingArea.Y - TotalArea.Y,
                        display.WorkingArea.Width,
                        display.WorkingArea.Height));
                }

                for (int i = 0; i < Zones.Count; i++)
                {
                    Zone zone = Zones[i];

                    if (i == Zones.Count - 1 && highLight)
                    {
                        g.FillRectangle(new LinearGradientBrush(
                            new Point(zone.Area.X - TotalArea.X, zone.Area.Y - TotalArea.Y),
                            new Point(zone.Area.Right() - TotalArea.X, zone.Area.Bottom() - TotalArea.Y),
                            Settings.SelectedZoneColor1, Settings.SelectedZoneColor2), new Rectangle(
                            zone.Area.X - TotalArea.X,
                            zone.Area.Y - TotalArea.Y,
                            zone.Area.Width,
                            zone.Area.Height));
                        DrawBorder(zone.Area, g, TotalArea.X, TotalArea.Y);
                    }
                    else
                    {
                        g.FillRectangle(new LinearGradientBrush(
                            new Point(zone.Area.X - TotalArea.X, zone.Area.Y - TotalArea.Y),
                            new Point(zone.Area.Right() - TotalArea.X, zone.Area.Bottom() - TotalArea.Y),
                            Settings.ZoneColor1, Settings.ZoneColor2), new Rectangle(
                            zone.Area.X - TotalArea.X,
                            zone.Area.Y - TotalArea.Y,
                            zone.Area.Width,
                            zone.Area.Height));
                        DrawBorder(zone.Area, g, TotalArea.X, TotalArea.Y);
                    }

                    if (zoneNames)
                    {
                        var stringSize1 = g.MeasureString(zone.Name, new Font("Segoe UI", Settings.ProfileImageZoneTextSize));
                        var stringSize2 = g.MeasureString(zone.Hotkey.ToString(), new Font("Segoe UI", Settings.ProfileImageZoneTextSize));                        
                        var totalSize = new Size((int)Math.Max(stringSize1.Width, stringSize2.Width), (int)(stringSize1.Height + stringSize2.Height));

                        if (zone.Hotkey.ToString() == "(none)" || stringSize2.Width > zone.Area.Width - 10 || totalSize.Height > zone.Area.Height - 10)
                        {                            
                            if (stringSize1.Width < zone.Area.Width - 10 && stringSize1.Height < zone.Area.Height - 10)
                            {
                                sf.LineAlignment = StringAlignment.Center;
                                g.DrawString(zone.Name, new Font("Segoe UI", Settings.ProfileImageZoneTextSize), new SolidBrush(Color.Black), new PointF(
                                    zone.Area.X - TotalArea.X + (zone.Area.Width / 2),
                                    zone.Area.Y - TotalArea.Y + (zone.Area.Height / 2)), sf);
                            }
                        }
                        else
                        {
                            if (totalSize.Width < zone.Area.Width - 10 && totalSize.Height < zone.Area.Height - 10)
                            {
                                sf.LineAlignment = StringAlignment.Far;
                                g.DrawString(zone.Name, new Font("Segoe UI", Settings.ProfileImageZoneTextSize), new SolidBrush(Color.Black), new PointF(
                                    zone.Area.X - TotalArea.X + (zone.Area.Width / 2),
                                    zone.Area.Y - TotalArea.Y + (zone.Area.Height / 2)), sf);

                                sf.LineAlignment = StringAlignment.Near;
                                g.DrawString(zone.Hotkey.ToString(), new Font("Segoe UI", Settings.ProfileImageZoneTextSize), new SolidBrush(Color.Black), new PointF(
                                    zone.Area.X - TotalArea.X + (zone.Area.Width / 2),
                                    zone.Area.Y - TotalArea.Y + (zone.Area.Height / 2)), sf);
                            }

                        }
                    }
                }

                if (screenNames)
                {
                    sf.LineAlignment = StringAlignment.Center;
                    foreach (Display display in Displays)
                    {
                        var stringSize = g.MeasureString(display.Name, new Font("Segoe UI", Settings.ProfileImageScreenTextSize));
                        if (stringSize.Width < display.Bounds.Width - 10 && stringSize.Height < display.Bounds.Height - 10)
                        {
                            g.DrawString(display.Name, new Font("Segoe UI", Settings.ProfileImageScreenTextSize), new SolidBrush(Color.FromArgb(128, 0, 0, 0)), new PointF(
                              display.Bounds.X - TotalArea.X + (display.Bounds.Width / 2),
                              display.Bounds.Y - TotalArea.Y + (display.Bounds.Height / 2)), sf);
                        }
                    }
                }

            }
            return img;
        }

        public string FreeZoneName()
        {
            int nr = 0;
            foreach (var v in Zones)
            {
                var split = v.Name.Split(' ');
                try
                {
                    if (Convert.ToInt16(split[1]) >= nr)
                    {
                        nr = Convert.ToInt16(split[1]) + 1;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return "Zone " + Convert.ToString(nr);
        }

        private void DrawBorder(Area border, Graphics g, int minX, int minY)
        {
            for (int i = 0; i < 5; i++)
            {
                int c = Math.Min(255, Math.Max(0, (Math.Abs(i - 2) * Settings.BorderColorMultiplier) + Settings.BorderColorConstant));
                g.DrawRectangle(new Pen(Color.FromArgb(c, c, c)), new Rectangle(
                    border.X - minX + i,
                    border.Y - minY + i,
                    (border.Width - 2 * i) - 1,
                    (border.Height - 2 * i) - 1));
            }
        }

        private Area Difference(Area r1, Area r2)
        {
            Area rect = new Area();
            if (r1.Width != r2.Width)
            {
                rect.X = Math.Min(r1.Width, r2.Width);
                rect.Y = Math.Min(r1.Y, r2.Y);
                rect.Width = Math.Abs(r1.Width - r2.Width);
                rect.Height = r1.Height;
            }
            else if (r1.Height != r2.Height)
            {
                rect.X = Math.Min(r1.X, r2.X);
                rect.Y = Math.Min(r1.Height, r2.Height);
                rect.Width = r1.Width;
                rect.Height = Math.Abs(r1.Height - r2.Height);                
            }            
            return rect;
        }

        public Display PrimaryDisplay()
        {
            Display display = Displays[0];
            for (int i = 0; i < Displays.Count; i++)
            {
                if (Displays[i].Primary)
                {
                    display = Displays[i];
                }
            }
            return display;
        }

    }
}
