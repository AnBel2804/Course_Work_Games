using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace Snake
{
    class Program
    {
        private const int MapWidth = 30;
        private const int MapHeight = 20;
        private const ConsoleColor Border_Color = ConsoleColor.DarkGray;
        private const ConsoleColor Head_Color = ConsoleColor.DarkBlue;
        private const ConsoleColor Body_Color = ConsoleColor.Blue;
        private const ConsoleColor Food_Color = ConsoleColor.Red;
        private const int Sleap = 200;
        int Score = 0;
        private static Random random = new Random();
        static void Main()
        {
            SetWindowSize(MapWidth, MapHeight);
            SetBufferSize(MapWidth, MapHeight);
            CursorVisible = false;
            Start();
            ReadKey(); ReadKey();
        }

        static void Start()
        {
            SetCursorPosition(MapWidth / 6, MapHeight / 2);
            WriteLine("Press any key to start");
            Console.ReadKey();
            int Score = 0;
            Clear();
            DrawBorder();
            var snake = new Snake(15, 10, Head_Color, Body_Color);
            Block food = Generate_food(snake);
            food.Draw();
            Direction direction = Direction.Right;
            Stopwatch timer = new Stopwatch();
            while (true)
            {
                timer.Restart();
                while (timer.ElapsedMilliseconds <= Sleap)
                {
                    direction = Select_direction(direction);
                }
                if (snake.Head.X == food.X && snake.Head.Y == food.Y)
                {
                    snake.Move(direction, true);
                    food = Generate_food(snake);
                    food.Draw();
                    Score++;
                }
                else
                    snake.Move(direction);
                if (snake.Head.X == MapWidth - 1 || snake.Head.X == 0 ||
                   snake.Head.Y == MapHeight - 1 || snake.Head.Y == 0 ||
                   snake.Body.Any(i => i.X == snake.Head.X && i.Y == snake.Head.Y))
                    break;
            }
            snake.Clean();
            food.Clear();
            SetCursorPosition(MapWidth / 3, MapHeight / 2);
            WriteLine("Game over\n\tScore: {0}", Score);
        }

        static Direction Select_direction(Direction direction)
        {
            if (!KeyAvailable)
                return direction;
            ConsoleKey key = ReadKey(true).Key;
            direction = key switch
            {
                ConsoleKey.UpArrow when direction != Direction.Down => Direction.Up,
                ConsoleKey.DownArrow when direction != Direction.Up => Direction.Down,
                ConsoleKey.RightArrow when direction != Direction.Left => Direction.Right,
                ConsoleKey.LeftArrow when direction != Direction.Right => Direction.Left,
                _ => direction
            };
            return direction;
        }

        static Block Generate_food(Snake snake)
        {
            Block Food;
            do
            {
                Food = new Block(random.Next(1, MapWidth - 2), random.Next(1, MapHeight - 2), Food_Color);
            } while (snake.Head.X == Food.X && snake.Head.Y == Food.Y ||
                     snake.Body.Any(i => i.X == Food.X && i.Y == Food.Y));
            return Food;
        }

        static void DrawBorder()
        {
            for (int i = 0; i < MapWidth; i++)
            {
                new Block(i, 0, Border_Color).Draw();
                new Block(i, MapHeight - 1, Border_Color).Draw();
            }
            for (int i = 0; i < MapHeight; i++)
            {
                new Block(0, i, Border_Color).Draw();
                new Block(MapWidth - 1, i, Border_Color).Draw();
            }
        }
    }
}
