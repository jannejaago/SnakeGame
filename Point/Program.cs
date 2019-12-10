using System;
using System.Threading;

namespace Point
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(110, 25);
            Console.SetBufferSize(110, 25);
            
            string username = GetUsername();
            Console.Clear();

            Walls walls = new Walls(80, 25);
            walls.DrawWalls();

            MyPoint tail = new MyPoint(6, 20, '*');
            Snake snake = new Snake(tail, 4, Direction.RIGHT);
            snake.DrawFigure();

            FoodCatering foodCatered = new FoodCatering(80, 25, '$');
            MyPoint goodFood = foodCatered.CaterFood();
            goodFood.Draw();
            MyPoint badFood = foodCatered.CaterFood();
            Console.ForegroundColor = ConsoleColor.Red;
            badFood.Draw();
            Console.ForegroundColor = ConsoleColor.White;
            int playerScore = 0;
            int snakeSpeed = 300;
            while (true)
            {
                Thread.Sleep(snakeSpeed);

                ShowMessage($"{username}'s score: {playerScore}", 82, 0);

                if (walls.IsHitByFigure(snake))
                {
                    break;
                }

                if (snake.Eat(goodFood))
                {
                    goodFood = foodCatered.CaterFood();
                    playerScore++;
                    ShowMessage($"{username}'s score: {playerScore}", 82, 0);
                    ShowMessage($"You ate some good food", 82, 1);
                    ShowMessage($"+1 score", 82, 2);
                    goodFood.Draw();
                    if (snakeSpeed > 140)
                    {
                        snakeSpeed -= 20;
                        Thread.Sleep(snakeSpeed);
                    }
                }
                else if (snake.Eat(badFood))
                {
                    badFood = foodCatered.CaterFood();
                    playerScore--;
                    ShowMessage($"{username}'s score: {playerScore}", 82, 0);
                    ShowMessage($"You ate some bad food ", 82, 1);
                    ShowMessage($"-1 score", 82, 2);
                    Console.ForegroundColor = ConsoleColor.Red;
                    badFood.Draw();
                    Console.ForegroundColor = ConsoleColor.White;
                    if (snakeSpeed > 140)
                    {
                        snakeSpeed -= 20;
                        Thread.Sleep(snakeSpeed);
                    }
                }
                else
                {
                    snake.MoveSnake();
                }
                
                if (Console.KeyAvailable)
                { 
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.ReadUserKey(key.Key);
                }                
            }

            WriteGameOver(username, playerScore);

            Console.ReadLine();
        }

        public static string GetUsername()
        {
            
            Console.WriteLine("Insert your username");
            string username = Console.ReadLine();
            return username;
        }
        public static void WriteGameOver(string _username, int _playerScore)
        {
            string username = _username;
            int playerScore = _playerScore;
            Console.Clear();
            int xOffset = 35;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(xOffset, yOffset++);
            ShowMessage("=========", xOffset, yOffset++);
            ShowMessage("GAME OVER", xOffset, yOffset++);
            ShowMessage("=========", xOffset, yOffset++);
            ShowMessage("", xOffset, yOffset);
            ShowMessage($"{username}'s score: {playerScore}", xOffset, yOffset++);
        }

        public static void ShowMessage(string text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
    }
}
