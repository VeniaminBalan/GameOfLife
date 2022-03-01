using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_of_Life
{
    public partial class Form1 : Form
    {

        private Graphics graphis;
        private int resolution;
        private GameEngine gameEengine;
       
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DrawNextGeneration();
        }

        private void bStart(object sender, EventArgs e)
        {
            StartGame();
        }

        private void bStops(object sender, EventArgs e)
        {
            if (gameEengine == null) return;
            StopGame();
        }
        private void ContinueButton(object sender, EventArgs e)
        {
            if (gameEengine == null) return;
            ContinueGame();
        }

        private void bClear(object sender, EventArgs e)
        {
            if (gameEengine == null) return;
            ClearButton();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (gameEengine == null) return;

            if (e.Button == MouseButtons.Left)
            {
                var x = e.Location.X / resolution;
                var y = e.Location.Y / resolution;
                gameEengine.AddCell(x, y);
            }
            if (e.Button == MouseButtons.Right)
            {
                var x = e.Location.X / resolution;
                var y = e.Location.Y / resolution;
                gameEengine.RemoveCell(x, y);
            }
        }

        private void StartGame()
        {
            nudDensity.Enabled = false;
            nudResolution.Enabled = false;
            resolution = (int)nudResolution.Value;

            gameEengine = new GameEngine
            (
                rows: pictureBox1.Height / resolution,
                cols: pictureBox1.Width / resolution,
                density: (int)(nudDensity.Minimum) + (int)(nudDensity.Maximum) - (int)nudDensity.Value
            );

            Text = $"Generation : {gameEengine.currentGeneration}";

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphis = Graphics.FromImage(pictureBox1.Image);
            timer1.Start();
        }

        private void DrawNextGeneration()
        {
            graphis.Clear(Color.Black);

            var field = gameEengine.GetCurrentGeneration();

            for (int x = 0; x < field.GetLength(0) ; x++)
            {
                for (int y = 0; y < field.GetLength(1); y++)
                {
                    if (field[x, y]) 
                    {
                        graphis.FillRectangle(Brushes.Crimson, x * resolution, y * resolution, resolution - 1, resolution - 1);
                    }
                }
            }

            pictureBox1.Refresh();
            Text = $"Generation : {gameEengine.currentGeneration}";
            gameEengine.NextGeneration();
        }

        private void StopGame()
        {
            if (!timer1.Enabled)
                return;
            timer1.Stop();
            nudDensity.Enabled = true;
            nudResolution.Enabled = true;
        }

        

        private void ContinueGame()
        {
            if (timer1.Enabled)
                return;
            timer1.Start();
            nudDensity.Enabled = false;
            nudResolution.Enabled = false;
        }



        private void ClearButton()
        {
            nudDensity.Enabled = false;
            nudResolution.Enabled = false;
            resolution = (int)nudResolution.Value;

            gameEengine.Clear
            (
                rows: pictureBox1.Height / resolution,
                cols: pictureBox1.Width / resolution
            );
            timer1.Start();
        }
    }
}
