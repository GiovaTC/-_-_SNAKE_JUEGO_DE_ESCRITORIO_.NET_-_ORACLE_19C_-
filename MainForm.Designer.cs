namespace snake_game
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Panel gamePanel;
        private System.Windows.Forms.Label lblScore;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            gameTimer = new System.Windows.Forms.Timer(components);
            gamePanel = new System.Windows.Forms.Panel();
            lblScore = new System.Windows.Forms.Label();

            SuspendLayout();

            // 
            // gameTimer
            // 
            gameTimer.Interval = 300;
            gameTimer.Tick += gameTimer_Tick;

            // 
            // gamePanel
            // 
            gamePanel.BackColor = System.Drawing.Color.Black;
            gamePanel.Location = new System.Drawing.Point(12, 40);
            gamePanel.Name = "gamePanel";
            gamePanel.Size = new System.Drawing.Size(500, 350);
            gamePanel.TabIndex = 0;

            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point);
            lblScore.Location = new System.Drawing.Point(12, 12);
            lblScore.Name = "lblScore";
            lblScore.Size = new System.Drawing.Size(70, 19);
            lblScore.TabIndex = 1;
            lblScore.Text = "Score: 0";

            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(524, 411);
            Controls.Add(lblScore);
            Controls.Add(gamePanel);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "🐍 Snake Game";
            Load += MainForm_Load;
            KeyDown += MainForm_KeyDown;

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}