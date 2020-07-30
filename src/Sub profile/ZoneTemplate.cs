using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace DesktopManager
{
    public class ZoneTemplate
    {
        public List<RelativeArea> RelativeAreaList = new List<RelativeArea>();
        public Image Image;

        public ZoneTemplate()
        {
        }

        public ZoneTemplate(List<RelativeArea> relativeAreaList)
        {
            RelativeAreaList = relativeAreaList;
            CreateImage();
        }

        public void CreateImage()
        {
            int w = 96;
            int h = 54;
            Image = (Image)(new Bitmap(w, h));
            foreach (var relArea in RelativeAreaList)
            {
                var area = relArea.ToArea(w, h);
                using (Graphics g = Graphics.FromImage(Image))
                {
                    g.FillRectangle(new LinearGradientBrush(
                        new Point(area.X, area.Y), new Point(area.Right(), area.Bottom()),
                        Settings.ZoneColor1, Settings.ZoneColor2), area.Rectangle());
                    for (int i = 0; i < 5; i++)
                    {
                        int c = Math.Min(255, Math.Max(0, (Math.Abs(i - 2) * Settings.BorderColorMultiplier) + Settings.BorderColorConstant));
                        g.DrawRectangle(new Pen(Color.FromArgb(c, c, c)), new Rectangle(area.X + i, area.Y + i, (area.Width - 2 * i) - 1, (area.Height - 2 * i) - 1));
                    }
                }
            }            
        }

        public static List<ZoneTemplate> CreateZoneTemplates()
        {
            var l = new List<ZoneTemplate>();

            l.Add(new ZoneTemplate(
                new List<RelativeArea>(new RelativeArea[] {
                    new RelativeArea(0, 0, .5, 1),
                    new RelativeArea(.5, 0, .5, .5),
                    new RelativeArea(.5, .5, .5, .5)
                })));

            l.Add(new ZoneTemplate(
                new List<RelativeArea>(new RelativeArea[] {
                    new RelativeArea(0, 0, .5, .5),
                    new RelativeArea(0, .5, .5, .5),
                    new RelativeArea(.5, 0, .5, 1)
                })));

            l.Add(new ZoneTemplate(
                new List<RelativeArea>(new RelativeArea[] {
                    new RelativeArea(0, 0, 1, .5),
                    new RelativeArea(0, .5, .5, .5),
                    new RelativeArea(.5, .5, .5, .5)
                })));

            l.Add(new ZoneTemplate(
                new List<RelativeArea>(new RelativeArea[] {
                    new RelativeArea(0, 0, .5, .5),
                    new RelativeArea(.5, 0, .5, .5),
                    new RelativeArea(0, .5, 1, .5)
                })));

            l.Add(new ZoneTemplate(
                new List<RelativeArea>(new RelativeArea[] {
                    new RelativeArea(0, 0, .5, 1),
                    new RelativeArea(.5, 0, .5, 1/3f),
                    new RelativeArea(.5, 1/3f, .5, 1/3f),
                    new RelativeArea(.5, 2/3f, .5, 1/3f)
                })));

            l.Add(new ZoneTemplate(
                new List<RelativeArea>(new RelativeArea[] {
                    new RelativeArea(0, 0, .5, 1/3f),
                    new RelativeArea(0, 1/3f, .5, 1/3f),
                    new RelativeArea(0, 2/3f, .5, 1/3f),
                    new RelativeArea(.5, 0, .5, 1)
                })));

            l.Add(new ZoneTemplate(
                new List<RelativeArea>(new RelativeArea[] {
                    new RelativeArea(0, 0, 1, .5),
                    new RelativeArea(0, .5, 1/3f, .5),
                    new RelativeArea(1/3f, .5, 1/3f, .5),
                    new RelativeArea(2/3f, .5, 1/3f, .5)
                })));

            l.Add(new ZoneTemplate(
                new List<RelativeArea>(new RelativeArea[] {
                    new RelativeArea(0, 0, 1/3f, .5),
                    new RelativeArea(1/3f, 0, 1/3f, .5),
                    new RelativeArea(2/3f, 0, 1/3f, .5),
                    new RelativeArea(0, .5, 1, .5)
                })));

            l.Add(new ZoneTemplate(
                new List<RelativeArea>(new RelativeArea[] {
                    new RelativeArea(0, 0, .5, .5),
                    new RelativeArea(0, .5, .5, .5),
                    new RelativeArea(.5, 0, .5, 1/3f),
                    new RelativeArea(.5, 1/3f, .5, 1/3f),
                    new RelativeArea(.5, 2/3f, .5, 1/3f)
                })));

            l.Add(new ZoneTemplate(
                new List<RelativeArea>(new RelativeArea[] {
                    new RelativeArea(0, 0, .5, 1/3f),
                    new RelativeArea(0, 1/3f, .5, 1/3f),
                    new RelativeArea(0, 2/3f, .5, 1/3f),
                    new RelativeArea(.5, 0, .5, .5),
                    new RelativeArea(.5, .5, .5, .5)
                })));

            l.Add(new ZoneTemplate(
                new List<RelativeArea>(new RelativeArea[] {
                    new RelativeArea(0, 0, .5, .5),
                    new RelativeArea(.5, 0, .5, .5),
                    new RelativeArea(0, .5, 1/3f, .5),
                    new RelativeArea(1/3f, .5, 1/3f, .5),
                    new RelativeArea(2/3f, .5, 1/3f, .5)
                })));

            l.Add(new ZoneTemplate(
                new List<RelativeArea>(new RelativeArea[] {
                    new RelativeArea(0, 0, 1/3f, .5),
                    new RelativeArea(1/3f, 0, 1/3f, .5),
                    new RelativeArea(2/3f, 0, 1/3f, .5),
                    new RelativeArea(0, .5, .5, .5),
                    new RelativeArea(.5, .5, .5, .5)
                })));

            return l;
        }

    }
}