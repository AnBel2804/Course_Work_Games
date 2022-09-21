using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Snake
    {
        private readonly ConsoleColor head_Color;
        private readonly ConsoleColor body_Color;

        public Snake(int X, int Y, ConsoleColor Head_color, ConsoleColor Body_color, int Body_length = 3)
        {
            head_Color = Head_color;
            body_Color = Body_color;
            Head = new Block(X, Y, head_Color);
            for (int i = Body_length; i > 0; i--)
            {
                Body.Enqueue(new Block(Head.X - i, Y, body_Color));
            }
            Draw();
        }

        public Block Head { get; private set; }
        public Queue<Block> Body { get; } = new Queue<Block>();

        public void Move(Direction direction, bool eat_food = false)
        {
            Clean();
            Body.Enqueue(new Block(Head.X, Head.Y, body_Color));
            if (!eat_food)
                Body.Dequeue();
            Head = direction switch
            {
                Direction.Right => new Block(Head.X + 1, Head.Y, head_Color),
                Direction.Left => new Block(Head.X - 1, Head.Y, head_Color),
                Direction.Up => new Block(Head.X, Head.Y - 1, head_Color),
                Direction.Down => new Block(Head.X, Head.Y + 1, head_Color),
                _ => Head
            };
            Draw();
        }

        public void Draw()
        {
            Head.Draw();
            foreach (Block block in Body)
                block.Draw();
        }

        public void Clean()
        {
            Head.Clear();
            foreach (Block block in Body)
                block.Clear();
        }
    }
}