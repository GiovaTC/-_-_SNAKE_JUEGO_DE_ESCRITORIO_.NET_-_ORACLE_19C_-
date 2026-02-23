using System;
using System.Drawing;
using System.Windows.Forms;
using snake_game.Db;
using snake_game.Models;

namespace snake_game
{
    public partial class MainForm : Form
    {
        private GameEngine game = new GameEngine();

        public MainForm()
        {
            InitializeComponent();
        }

        // 🔹 Carga inicial
        private void MainForm_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            lblScore.Text = "Score: 0";

            game.Start(gamePanel.Size);   // 🔹 Inicializa comida
            gameTimer.Start();            // 🔹 Inicia loop
        }

        // 🔹 Loop real del juego
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            game.Update(gamePanel.Size);

            if (game.GameOver)
            {
                gameTimer.Stop();
                GameOver();
                return;
            }

            lblScore.Text = $"Score: {game.Score}";
            gamePanel.Invalidate();   // 🔹 Repintar
        }

        // 🔹 Control del Snake
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            game.Snake.ChangeDirection(e.KeyCode);
        }

        // 🔹 Renderizado real
        private void gamePanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Snake
            foreach (var p in game.Snake.Body)
            {
                g.FillRectangle(
                    Brushes.LimeGreen,
                    p.X, p.Y,
                    18, 18
                );
            }

            // Food
            g.FillEllipse(
                Brushes.Red,
                game.Food.Position.X,
                game.Food.Position.Y,
                18, 18
            );
        }

        // 🔹 Fin del juego + Oracle
        private void GameOver()
        {
            game.EndGame();

            string player = Microsoft.VisualBasic.Interaction.InputBox(
                "Nombre del jugador:",
                "Game Over",
                "Jugador");

            if (string.IsNullOrWhiteSpace(player))
                player = "ANONYMOUS";

            var repo = new ScoreRepository();
            repo.SaveScore(new GameScore
            {
                PlayerName = player,
                Score = game.Score
            });

            MessageBox.Show(
                "Puntaje guardado en Oracle 19c",
                "Snake Game",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            Close();
        }
    }
}