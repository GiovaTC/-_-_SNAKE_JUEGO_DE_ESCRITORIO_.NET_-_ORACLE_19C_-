using System.Collections.Generic;
using System.Drawing;

namespace snake_game
{
    public class Snake
    {
        public List<Point> Body { get; } = new();
        public Point Direction { get; private set; } = new Point(20, 0);

        public Snake()
        {
            Body.Add(new Point(60, 20));
            Body.Add(new Point(40, 20));
            Body.Add(new Point(20, 20));
        }

        public void Move()
        {
            for (int i = Body.Count - 1; i > 0; i--)
                Body[i] = Body[i - 1];

            Body[0] = new Point(
                Body[0].X + Direction.X,
                Body[0].Y + Direction.Y
            );
        }

        public void Grow()
        {
            Body.Add(Body[^1]);
        }

        public void ChangeDirection(Keys key)
        {
            Direction = key switch
            {
                Keys.Up => new Point(0, -20),
                Keys.Down => new Point(0, 20),
                Keys.Left => new Point(-20, 0),
                Keys.Right => new Point(20, 0),
                _ => Direction
            };
        }
    }
}