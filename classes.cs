// одна из первых программ с классами, самое начало ООП

using System;
namespace std
{
    class CubicRect
    {
        private float h;
        private float sh;
        private float g;
        private float x, y;
        public CubicRect()
        {
            h = 5;
            sh = 6;
            g = 7;
            x = 0;
            y = 0;
        }
        public CubicRect(float h, float sh, float g, float x, float y)
        {
            this.h = h;
            this.sh = sh;
            this.g = g;
            this.x = x;
            this.y = y;
        }
        public void PrintLengths()
        {
            Console.Write("\nHeight = {0}\n", h);
            Console.Write("Width = {0}\n", sh);
            Console.Write("Depth = {0}\n", g);
        }
        public float S()
        {
            return 2 * (h * sh + h * g + sh * g);
        }
        public float V()
        {
            return h * sh * g;
        }
        public float GetSide(int side)
        {
            switch (side)
            {
                case 1: return h;
                case 2: return sh;
                case 3: return g;
                default: return 0;
            }
        }
        public float GetCoord(int coord)
        {
            switch (coord)
            {
                case 1: return x;
                default: return y;
            }
        }
        public void MoveXY(float x, float y)
        {
            this.x += x;
            this.y += y;
        }
        public void ChangeSize(float sh, float g)
        {
            this.sh = sh;
            this.g = g;
        }
        public float GetCrossSide(CubicRect rct, int side)
        {
            float xcr, ycr;
            float min, max;
            if (x > rct.GetCoord(1)) max = x;
            else max = rct.GetCoord(1);
            if (g + x < rct.GetSide(3) + rct.GetCoord(1)) min = g + x;
            else min = rct.GetSide(3) + rct.GetCoord(1);
            if (min - max < 0) xcr = 0;
            else xcr = min - max;
            if (y > rct.GetCoord(2)) max = y;
            else max = rct.GetCoord(2);
            if (sh + y < rct.GetSide(2) + rct.GetCoord(2)) min = sh + y;
            else min = rct.GetSide(2) + rct.GetCoord(2);
            if (min - max < 0) ycr = 0;
            else ycr = min - max;
            switch (side)
            {
                case 1: if (xcr != 0 && ycr != 0) return xcr; else return 0;
                case 2: if (xcr != 0 && ycr != 0) return ycr; else return 0;
                default: return -1;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CubicRect p, p1;
            Console.Write("Default (1) or enter values (2): ");
            if (Console.ReadLine() == "1")
                p = new CubicRect();
            else
            {
                Console.Write("Enter heigth, width, depth, x, y:\n");
                p = new CubicRect(float.Parse(Console.ReadLine()), float.Parse(Console.ReadLine()), float.Parse(Console.ReadLine()), float.Parse(Console.ReadLine()), float.Parse(Console.ReadLine()));
            }
            p.PrintLengths();
            Console.Write("\nS = {0}", p.S());
            Console.Write("\nV = {0}", p.V());
            Console.Write("\nh = {0}, sh = {1}, g = {2}", p.GetSide(1), p.GetSide(2), p.GetSide(3));
            Console.Write("\n\nEnter x, y to move:\n");
            p.MoveXY(float.Parse(Console.ReadLine()), float.Parse(Console.ReadLine()));
            Console.Write("\nEnter new sh and g:\n");
            p.ChangeSize(float.Parse(Console.ReadLine()), float.Parse(Console.ReadLine()));
            Console.Write("\nsh = {0}, g = {1}", p.GetSide(2), p.GetSide(3));
            Console.Write("\n\nDefault (1) or enter values (2): ");
            if (Console.ReadLine() == "1")
                p1 = new CubicRect();
            else
            {
                Console.Write("Enter heigth, width, depth, x, y:\n");
                p1 = new CubicRect(float.Parse(Console.ReadLine()), float.Parse(Console.ReadLine()), float.Parse(Console.ReadLine()), float.Parse(Console.ReadLine()), float.Parse(Console.ReadLine()));
            }
            Console.Write("\nCrossing sides = {0} and {1}", p.GetCrossSide(p1, 1), p.GetCrossSide(p1, 2));
            Console.ReadKey();
        }
    }
}