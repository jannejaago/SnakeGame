using System;
using System.Threading;

namespace Point
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);

            HorizontalLine topLine = new HorizontalLine(0, 78, 0, '*');
            topLine.DrawFigure();
            HorizontalLine bottomLine = new HorizontalLine(0, 78, 24, '*');
            bottomLine.DrawFigure();
            VerticalLine leftLine = new VerticalLine(0, 24, 0, '*');
            leftLine.DrawFigure();
            VerticalLine rightLine = new VerticalLine(0, 24, 78, '*');
            rightLine.DrawFigure();

            MyPoint tail = new MyPoint(6, 5, '*');
            Snake snake = new Snake(tail, 4, Direction.RIGHT);
            snake.DrawFigure();
            snake.MoveSnake();
            Thread.Sleep(100);
            snake.MoveSnake();
            Thread.Sleep(100);
            snake.MoveSnake();
            Thread.Sleep(100);
            snake.MoveSnake();

            Console.ReadLine();
        }
    }
}
