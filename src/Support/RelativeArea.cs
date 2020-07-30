using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesktopManager
{
    public class RelativeArea
    {
        public double X;
        public double Y;
        public double Width;
        public double Height;

        public RelativeArea()
        {
        }

        public RelativeArea(double x, double y, double width, double height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public Area ToArea(int horizontalResolution, int verticalResolution)
        {
            return new Area(
                (int)(X  * horizontalResolution + .5),
                (int)(Y * verticalResolution + .5),
                (int)(Width * horizontalResolution + .5),
                (int)(Height * verticalResolution + .5));
        }

        public override string ToString()
        {
            return "{ X = " + X + ", Y = " + Y + ", Width = " + Width + ", Height = " + Height + "}";
        }

    }
}
