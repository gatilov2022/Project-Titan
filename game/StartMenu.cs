using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game
{
    public partial class StartMenu : Form
    {
        Form1 form1;
        public StartMenu()
        {
            InitializeComponent();
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            var but = sender as Button;
            _ = but == button1 ? but.BackgroundImage = Properties.Resources.start_active : but.BackgroundImage = Properties.Resources.exit_active;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            var but = sender as Button;
            _ = but == button1 ? but.BackgroundImage = Properties.Resources.start_no_active : but.BackgroundImage = Properties.Resources.exit_no_active;
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            var but = sender as Button;
            _ = but == button1 ? but.BackgroundImage = Properties.Resources.start_Down : but.BackgroundImage = Properties.Resources.exit_Down;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form1 = new Form1();
            form1.Show();
            this.Hide();
        }

    }
}
