using System;

namespace Point
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);

            HorizontalLine topLine = new HorizontalLine(0, 78, 0, '*');
            topLine.DrawHorizontalLine();
            HorizontalLine bottomLine = new HorizontalLine(0, 78, 24, '*');
            bottomLine.DrawHorizontalLine();
            VerticalLine leftLine = new VerticalLine(0, 24, 0, '*');
            leftLine.DrawVerticalLine();
            VerticalLine rightLine = new VerticalLine(0, 24, 78, '*');
            rightLine.DrawVerticalLine();


            /*HorizontalLine hrLine = new HorizontalLine(5, 10, 10, '*');
            hrLine.DrawHorizontalLine();

            VerticalLine vrLine = new VerticalLine(11, 20, 5, '*');
            vrLine.DrawVerticalLine();*/

            /*for(int i = 5; i <10; i++)
            {
                MyPoint newPoint = new MyPoint(i, 5, '*');
                newPoint.Draw();
                MyPoint newPoint2 = new MyPoint(5, i, '#');
                newPoint2.Draw();
            }*/

            Console.ReadLine();
        }
    }
}
