using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System.Drawing;
using System.Diagnostics;

namespace DesktopManager
{
    public static class Pdf
    {
      
        public static PdfDocument Create(Profile profile)
        {
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Hotkey map for Desktop Manager";
            PdfPage page = document.AddPage();
            page.Orientation = PageOrientation.Landscape;
            XGraphics gfx = XGraphics.FromPdfPage(page);

            int l = 46;
            int t = 48;            
            int w = 750;
            int h = 500;

            foreach (var display in profile.Displays)
            {
                gfx.DrawRectangle(new XPen(XColor.FromArgb(0, 0, 0), .5f), ResizedF(
                    display.Bounds.Rectangle(), profile.TotalArea.Rectangle(), new Rectangle(l, t, w, h)));
            }

            foreach (var zone in profile.Zones)
            {
                var resizedF = ResizedF(zone.Area.Rectangle(), profile.TotalArea.Rectangle(), new Rectangle(l, t, w, h));
                gfx.DrawRectangle(new XSolidBrush(Color.White), resizedF);
                gfx.DrawRectangle(new XPen(XColor.FromArgb(0, 0, 0), .5f), resizedF);
                if (!zone.Hotkey.Empty)
                {
                    int insideBorder = 2;
                    int inbetween = 1;
                    var ellipseSize = new XSize(2, 2);
                    XFont f = new XFont("Segoe UI", Settings.PdFTextSize);

                    double totalLength1 = 0;
                    double totalLength2 = gfx.MeasureString(zone.Hotkey.KeyCode.ToString(), f).Width + (2 * insideBorder);
                    double hg = gfx.MeasureString("AltCtrlShift" + zone.Hotkey.KeyCode.ToString(), f).Height + (2 * insideBorder);
                    if (zone.Hotkey.Alt)
                    {
                        totalLength1 += gfx.MeasureString("Alt", f).Width + (2 * insideBorder) + inbetween;
                    }
                    if (zone.Hotkey.Control)
                    {
                        totalLength1 += gfx.MeasureString("Ctrl", f).Width + (2 * insideBorder) + inbetween;
                    }
                    if (zone.Hotkey.Shift)
                    {
                        totalLength1 += gfx.MeasureString("Shift", f).Width + (2 * insideBorder) + inbetween;
                    }
                    if (zone.Hotkey.Windows)
                    {
                        totalLength2 += hg + inbetween; // Square key
                    }

                    double start = resizedF.X + (resizedF.Width / 2) - (Math.Max(totalLength1, totalLength2) / 2);                    
                    var borderPen = new XPen(XColor.FromArgb(80, 80, 80), .5f);
                    var stringBrush = new XSolidBrush(XColor.FromArgb(80, 80, 80));
                    if (zone.Hotkey.Alt)
                    {
                        gfx.DrawRoundedRectangle(borderPen, new RectangleF(
                            (float)start, (float)(resizedF.Top + (resizedF.Height / 2) - hg),
                            (float)gfx.MeasureString("Alt", f).Width + (2 * insideBorder), (float)hg), ellipseSize);
                        gfx.DrawString("Alt", f, stringBrush, new PointF(
                            (float)(start + insideBorder + (gfx.MeasureString("Alt", f).Width / 2) - 1),
                            (float)(resizedF.Top + ((resizedF.Height - hg) / 2))), XStringFormats.Center);
                        start += gfx.MeasureString("Alt", f).Width + (2 * insideBorder) + inbetween;
                    }
                    if (zone.Hotkey.Control)
                    {
                        gfx.DrawRoundedRectangle(borderPen, new RectangleF(
                            (float)start, (float)(resizedF.Top + (resizedF.Height / 2) - hg),
                            (float)gfx.MeasureString("Ctrl", f).Width + (2 * insideBorder), (float)hg), ellipseSize);
                        gfx.DrawString("Ctrl", f, stringBrush, new PointF(
                            (float)(start + insideBorder + (gfx.MeasureString("Ctrl", f).Width / 2) - 1),
                            (float)(resizedF.Top + ((resizedF.Height - hg) / 2))), XStringFormats.Center);
                        start += gfx.MeasureString("Ctrl", f).Width + (2 * insideBorder) + inbetween;
                    }
                    if (zone.Hotkey.Shift)
                    {
                        gfx.DrawRoundedRectangle(borderPen, new RectangleF(
                            (float)start, (float)(resizedF.Top + (resizedF.Height / 2) - hg),
                            (float)gfx.MeasureString("Shift", f).Width + (2 * insideBorder), (float)hg), ellipseSize);
                        gfx.DrawString("Shift", f, stringBrush, new PointF(
                            (float)(start + insideBorder + (gfx.MeasureString("Shift", f).Width / 2) - 1),
                            (float)(resizedF.Top + ((resizedF.Height - hg) / 2))), XStringFormats.Center);                        
                    }
                    start = resizedF.X + (resizedF.Width / 2) - (Math.Max(totalLength1, totalLength2) / 2);   
                    if (zone.Hotkey.Windows)
                    {
                        var winPen = new XPen(XColor.FromArgb(80, 80, 80), (Settings.PdFTextSize / 8) * .5f);
                        gfx.DrawRoundedRectangle(borderPen, new RectangleF(
                            (float)start, (float)(inbetween + resizedF.Top + (resizedF.Height / 2)),
                            (float)hg, (float)hg), ellipseSize);
                        var x = new float[,] {
                            {(float)(start + .4 * hg), (float)(start + .7 * hg),(float)(start + hg)},
                            {(float)(start + .3 * hg), (float)(start + .6 * hg), (float)(start + .9 * hg)},
                            {(float)(start + .2 * hg), (float)(start + .5 * hg), (float)(start + .8 * hg)}
                        };
                        var y = new float[] {(float)(resizedF.Top + (resizedF.Height / 2) +.3 * hg), (float)(resizedF.Top + (resizedF.Height / 2) + .6 * hg), (float)(resizedF.Top + (resizedF.Height / 2) + .9 * hg)};
                        for (int i = 0; i < 3; i++)
                        {
                            gfx.DrawLine(winPen, x[0, i] - 1, y[0], x[2, i] - 1, y[2]);
                            gfx.DrawCurve(winPen, new PointF[] {
                                new PointF(x[i, 0] - 1, y[i]),
                                new PointF((x[i, 0] + x[i, 1]) / 2 - 1, (float)(y[i] - .06 * hg)),
                                new PointF(x[i, 1] - 1, y[i]),
                                new PointF((x[i, 1] + x[i, 2]) / 2 - 1, (float)(y[i] + .06 * hg)),
                                new PointF(x[i, 2] - 1, y[i])
                            });
                        }
                        start += hg + inbetween;
                    }

                    gfx.DrawRoundedRectangle(borderPen, new RectangleF(
                            (float)start, (float)(inbetween + resizedF.Top + (resizedF.Height / 2)),
                            (float)gfx.MeasureString(zone.Hotkey.KeyCode.ToString(), f).Width + (2 * insideBorder), (float)hg), ellipseSize);
                    gfx.DrawString(zone.Hotkey.KeyCode.ToString(), f, stringBrush, new PointF(
                            (float)(start + insideBorder + (gfx.MeasureString(zone.Hotkey.KeyCode.ToString(), f).Width / 2) - 1),
                            (float)(inbetween + resizedF.Top + ((resizedF.Height + hg) / 2))), XStringFormats.Center);
                    
                }
            }

            return document;
        }        

        private static RectangleF ResizedF(Rectangle rectangle, Rectangle profileRectangle, Rectangle rectangleToPlaceIn)
        {
            double scale = Math.Min((double)rectangleToPlaceIn.Width / (double)profileRectangle.Width,
                (double)rectangleToPlaceIn.Height / (double)profileRectangle.Height);
            return new RectangleF(
                (float)(rectangleToPlaceIn.X + ((rectangle.X - profileRectangle.X) * scale)),
                (float)(rectangleToPlaceIn.Y + ((rectangle.Y - profileRectangle.Y) * scale)),
                (float)(rectangle.Width * scale), (float)(rectangle.Height * scale));
        }
    }
}
