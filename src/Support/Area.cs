using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;

namespace DesktopManager
{
    public class Area
    {
        public int X;
        public int Y;
        public int Width;
        public int Height;

        public Area()
        {
            X = 0;
            Y = 0;
            Width = 0;
            Height = 0;
        }

        public Area(Rectangle rectangle)
        {
            X = rectangle.X;
            Y = rectangle.Y;
            Width = rectangle.Width;
            Height = rectangle.Height;
        }

        public Area(Point p1, Point p2)
        {
            X = Math.Min(p1.X, p2.X);
            Y = Math.Min(p1.Y, p2.Y);
            Width = Math.Abs(p1.X - p2.X);
            Height = Math.Abs(p1.Y - p2.Y);
        }

        public Area(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public int Right()
        {
            return X + Width;
        }

        public int Bottom()
        {
            return Y + Height;
        }

        public override string ToString()
        {
            return "{ X = " + X + ", Y = " + Y + ", Width = " + Width + ", Height = " + Height + "}";
        }

        public Rectangle Rectangle()
        {
            return new Rectangle(X, Y, Width, Height);
        }
        
        public bool Contains(Point p)
        {
            if (p.X > X && p.X < Right() && p.Y > Y && p.Y < Bottom())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
