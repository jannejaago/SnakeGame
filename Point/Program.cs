using System;
using System.Threading;

namespace Point
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(100, 55);
            Console.SetBufferSize(100, 55);

            Walls walls = new Walls(80, 25);
            walls.DrawWalls();

            MyPoint tail = new MyPoint(6, 5, '*');
            Snake snake = new Snake(tail, 4, Direction.RIGHT);
            snake.DrawFigure();

            FoodCatering foodCatered = new FoodCatering(80, 25, '$');
            MyPoint food = foodCatered.CaterFood();
            food.Draw();

            while (true)
            {
                if (walls.IsHitByFigure(snake))
                {
                    break;
                }

                if (snake.Eat(food))
                {
                    food = foodCatered.CaterFood();
                    food.Draw();
                }else
                {
                    snake.MoveSnake();
                }
                Thread.Sleep(300);
                
                if (Console.KeyAvailable)
                { 
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.ReadUserKey(key.Key);
                }                
            }

            WriteGameOver();

            Console.ReadLine();
        }

        public static void WriteGameOver()
        {
            Console.Clear();
            int xOffset = 35;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(xOffset, yOffset++);
            ShowMessage("=========", xOffset, yOffset++);
            ShowMessage("GAME OVER", xOffset, yOffset++);
            ShowMessage("=========", xOffset, yOffset++);
        }

        public static void ShowMessage(string text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
    }
}
