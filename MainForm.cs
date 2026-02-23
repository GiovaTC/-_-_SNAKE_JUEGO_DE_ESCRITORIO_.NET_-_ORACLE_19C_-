using snake_game;
using snake_game.Db;
using snake_game.Models;
using snake_game.Db;
using snake_game.Models;
using System;
using System.Windows.Forms;

namespace snake_game
{
    public partial class MainForm : Form
    {
        private GameEngine game = new GameEngine();

        public MainForm()
        {
            InitializeComponent();
        }

        // Carga inicial del formulario
        private void MainForm_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            lblScore.Text = "Score: 0";
        }

        // Simulación del juego (luego se conecta a Snake / Food)
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            // Simulación simple: el jugador "come"
            game.EatFood();

            lblScore.Text = $"Score: {game.Score}";

            // Condición de Game Over (ejemplo)
            if (game.Score >= 100)
            {
                gameTimer.Stop();
                GameOver();
            }
        }

        // Control por teclado (base para el Snake real)
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gameTimer.Start();
            }
        }

        // Fin del juego + guardado en Oracle
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