// практика наследования классов в C#

using System;
using static System.Console;

namespace std
{
    class DemoPoint
    {
        protected int x;
        protected int y;
        public DemoPoint()
        {
            x = 0;
            y = 0;
        }
        public DemoPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void Show()
        {
            WriteLine("Coordinates: ({0}; {1})", x, y);
        }
    }

    class DemoLine : DemoPoint
    {
        new private int x;
        new private int y;
        public DemoLine()
            : base()
        {
            x = 1;
            y = 1;
        }
        public DemoLine(int x1, int y1, int x2, int y2)
            : base(x1, y1)
        {
            x = x2;
            y = y2;
        }
        new public void Show()
        {
            Write("Beginning ");
            base.Show();
            WriteLine("Ending Coordinates: ({0}; {1})", x, y);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DemoLine a = new DemoLine(4, 6, 8, 6);
            DemoLine b = new DemoLine();
            WriteLine("Line a");
            a.Show();
            WriteLine("Line b");
            b.Show();
            ReadKey();            
        }
    }
}
