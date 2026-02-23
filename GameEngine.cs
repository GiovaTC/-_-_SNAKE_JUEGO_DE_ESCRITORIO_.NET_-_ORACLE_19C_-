using System.Drawing;

namespace snake_game
{
    public class GameEngine
    {
        public int Score { get; private set; } = 0;
        public bool GameOver { get; private set; }

        public void EatFood()
        {
            Score += 10;
        }

        public void EndGame()
        {
            GameOver = true;
        }   
    }
}
