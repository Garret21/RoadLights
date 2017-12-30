using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoadLights
{
    public partial class Game : Form
    {
        public Game()
        {
            InitializeComponent();
            this.Width = 155 * 8 + 100; // 16;
            this.Height = 155 * 5 + 39;
            StartStopBtn.Location = new Point(this.Width - 100, 0);
            BackBtn.Location = new Point(this.Width - 100, StartStopBtn.Height + 10);
        }

        private void Game_Load(object sender, EventArgs e)
        {
            manager = new Rules();
        }

        private void Game_Paint(object sender, PaintEventArgs e)
        {
            manager.DrawMap(e.Graphics);
            manager.DrawCars(e.Graphics);
        }

        private void StartStopBtn_Click(object sender, EventArgs e)
        {
            if (StartStopBtn.Text == "Start")
                StartStopBtn.Text = "Pause";
            else StartStopBtn.Text = "Start";
            TimerCreator.Enabled = !TimerCreator.Enabled;
            TurnTimer.Enabled = !TurnTimer.Enabled;
            Invalidate();
        }

        private void TurnTimer_Tick(object sender, EventArgs e)
        {
            manager.Turn();
            Invalidate();
        }

        private void TimerCreator_Tick(object sender, EventArgs e)
        {
            if (!manager.CreateMachine(new Point(0, 1), (int)directionVector.west, ImageResourses.Car))
            {
                TimerCreator.Enabled = false;
                TurnTimer.Enabled = false;
                MessageBox.Show("GAME OVER");
            }
            Invalidate();
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }

        private void Game_MouseClick(object sender, MouseEventArgs e)
        {
            manager.FindTile(e.Location).ChangeLight();
            Invalidate();
        }

        Rules manager;
    }
}
