namespace snake_game
{
    public class GameEngine
    {
        public int Score { get; private set; } = 0;
        public bool GameOver { get; private set; }

        public Snake Snake { get; } = new();
        public Food Food { get; } = new();

        public void Start(Size boardSize)
        {
            GameOver = false;
            Score = 0;
            Food.Respawn(boardSize);
        }

        public void Update(Size boardSize)
        {
            Snake.Move();

            // Comer comida
            if (Snake.Body[0] == Food.Position)
            {
                Snake.Grow();
                Score += 10;
                Food.Respawn(boardSize);
            }

            // Colisión con paredes
            if (Snake.Body[0].X < 0 || Snake.Body[0].Y < 0 ||
                Snake.Body[0].X >= boardSize.Width ||
                Snake.Body[0].Y >= boardSize.Height)
            {
                EndGame(); // 🔹 ahora sí existe
            }
        }

        // ✅ MÉTODO QUE FALTABA
        public void EndGame()
        {
            GameOver = true;
        }
    }
}