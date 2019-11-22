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

            Console.ReadLine();
        }
    }
}
