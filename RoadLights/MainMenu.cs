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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void GameBtn_Click(object sender, EventArgs e)
        {
            Game game = new Game();
            game.Owner = this;
            this.Hide();
            game.Show();
        }

        private void EditorBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("It`s not ready. Yet.");
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
