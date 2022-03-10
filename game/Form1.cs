using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace game
{
    public partial class Form1 : Form
    {
        private Random rand = new Random();
        private int mouse_X, mouse_Y,lastX = 0, lastY =0;
        private Button[] buttons;
        private Sprites sprites = new Sprites();

        public Form1()
        {
            Graphics g = this.CreateGraphics();
            InitializeComponent();
            timer1.Start();
            timer1.Tick += Timer1_Tick;

            buttons = new Button[] {factory_but ,pump_but ,drill_but ,base_but ,wareh_but ,house_but ,steam_but};

            Map.GenerateMap();    
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            int i = sprites.what_siz();

            if(e.X / i != lastX/i || e.Y / i != lastY / i)
            {
                lastY = e.Y; lastX = e.X;
                mouse_X = lastX - lastX % i + i/2;
                mouse_Y = lastY - lastY % i + i/2;
                Invalidate();
            }
            
        }

        private void but_MouseMove(object sender, MouseEventArgs e)
        {
            Button but = sender as Button;
            if (but.FlatAppearance.BorderColor != Color.Blue)
            {
                but.FlatAppearance.BorderColor = Color.Yellow;
            }
        }

        private void but_MouseLeave(object sender, EventArgs e)
        {
            Button but = sender as Button;
            if (but.FlatAppearance.BorderColor != Color.Blue)
            {
                but.FlatAppearance.BorderColor = Color.Red;
            }
        }
        
        private void but_MouseClick(object sender, EventArgs e)
        {
            //События для кнопок, при нажатии которых, рамка Flat будет синей(Blue). При повторном клике, рамка меняет цвет на жёлтый(Yellow).
            Button but = sender as Button;
            if (but.FlatAppearance.BorderColor != Color.Blue)
            {
                foreach (Button b in buttons) { b.FlatAppearance.BorderColor = Color.Red; }
                but.FlatAppearance.BorderColor = Color.Blue;
            }
            else but.FlatAppearance.BorderColor = Color.Yellow;
            Invalidate();
        }

        private void paint_vis(object sender, PaintEventArgs e)
        {
            Map.draw_map(e);

            Building a = new Building(mouse_X, mouse_Y);
            this.Font = new Font("Times New Roman", 30,
            FontStyle.Bold, GraphicsUnit.Pixel);

            a.Draw_building(e,buttons);
        }
    }
}