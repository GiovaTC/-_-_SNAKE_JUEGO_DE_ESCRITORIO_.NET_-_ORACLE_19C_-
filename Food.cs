using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake_game
{
    public class Food
    {
        private static readonly Random rnd = new();
        public Point Position { get; private set; }

        public void Respawn(Size bounds)
        {
            Position = new Point(
                rnd.Next(0, bounds.Width / 20) * 20,
                rnd.Next(0, bounds.Height / 20) * 20
            );
        }
    }
}
