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
using game.Классы_визуала;

namespace game
{
    public partial class Form1 : Form
    {
        private Random rand = new Random();
        private int mouse_X, mouse_Y,lastX = 0, lastY =0;
        private Button[] buttons;
        private Sprites sprites = new Sprites();
        private Point DragStartCoord, DragDeltaCoord = new Point(0,0);

        private int MaxMultipler = 10, MinMultipler = 4;

        private int SpritesSize;

        private bool dragStarted = false;

        Map_Build buildingClass;

        public Form1()
        {
            Graphics g = this.CreateGraphics();
            InitializeComponent();
            timer1.Start();
            timer1.Tick += Timer1_Tick;
            buttons = new Button[] {factory_but ,pump_but ,drill_but ,base_but ,wareh_but ,house_but ,steam_but};

            SpritesSize = sprites.GetSpritesSize();

            buildingClass = new Map_Build();
            this.MouseWheel += new MouseEventHandler(From1_MouseWheel);

            FillScrollList();

            sprites.SetSpritesMinSize(Convert.ToInt32(Math.Sqrt(sprites.GetPixelCount())) * MinMultipler);
            sprites.SetSpritesMaxSize(Convert.ToInt32(Math.Sqrt(sprites.GetPixelCount())) * MaxMultipler);

            Map.GenerateMap();    
        }

        private void FillScrollList()
        {
            PixelsDelta = Convert.ToInt32(Math.Sqrt(sprites.GetPixelCount())) * 2;
            int i = 1;
            while (PixelsDelta > 0)
            {
                if (PixelsDelta - i < 1)
                {
                    ScrlList.Add(PixelsDelta);
                    ScrlList.Sort();
                    PixelsDelta -= i;
                }
                else
                {
                    ScrlList.Add(i);
                    PixelsDelta -= i;
                }
                i++;
            }
        }
        

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (ScrlDown || ScrlUp) Invalidate();
        }
        
        private bool ScrlDown = false, ScrlUp = false;
        private int ScrlIterator;
        private int ScrlToX, ScrlToY;

        private int PixelsDelta;

        private List<int> ScrlList = new List<int> () {};

        private void From1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!ScrlDown && !ScrlUp) {
                ScrlToX = e.X; ScrlToY = e.Y;
                
                if (e.Delta < 0 && SpritesSize > 8)
                {
                    ScrlIterator = ScrlList.Count() - 1;
                    ScrlDown = true;
                }
                else if (e.Delta > 0 && SpritesSize < 119)
                {
                    ScrlUp = true;
                    ScrlIterator = 0;
                }
            }
            Invalidate();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragStarted)
            {   
                //if  (DragDeltaCoord.X <= 0 & (DragDeltaCoord.X >= this.Width - Map.GetMapSize() * Sprites.size * Chunk.ChunkSize) )
                DragDeltaCoord.X -= (DragStartCoord.X - e.X);
            
                //if (DragDeltaCoord.Y <= -1 && DragDeltaCoord.Y <= Map.GetMapSize() * Sprites.size * Chunk.ChunkSize)
                DragDeltaCoord.Y -= (DragStartCoord.Y - e.Y);
                    
                DragStartCoord.Y = e.Y;
                DragStartCoord.X = e.X;
                Invalidate();
            }

            Graphics DrawMouse = this.CreateGraphics();
            //DrawMouse.FillRectangle(new SolidBrush(Color.Black), e.X, e.Y + 20, 80, 25);
            //DrawMouse.DrawString((e.X).ToString() + " " + (e.Y).ToString(), new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point), Brushes.Red, e.X, e.Y + 20);

            int i = sprites.GetSpritesSize();

            if(e.X / i != lastX/i || e.Y / i != lastY / i)
            {
                lastY = e.Y; lastX = e.X;
                mouse_X = lastX - lastX % i;
                mouse_Y = lastY - lastY % i;
                Invalidate();
            }
            
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                buildingClass.Add_build(new Point(mouse_X, mouse_Y), buttons, DragDeltaCoord);
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

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            dragStarted = false;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragStarted = true;
                DragStartCoord.X = e.X;
                DragStartCoord.Y = e.Y;
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

        private void SmoothZoom()
        {
            int SizeChange = ScrlList[ScrlIterator];
            SpritesSize = sprites.GetSpritesSize();

            if (ScrlDown && ScrlIterator != 0)
            {
                DragDeltaCoord.X = ((DragDeltaCoord.X - ScrlToX) / SpritesSize) * (SpritesSize - SizeChange) + ScrlToX;
                DragDeltaCoord.Y = ((DragDeltaCoord.Y - ScrlToY) / SpritesSize) * (SpritesSize - SizeChange) + ScrlToY;
                ScrlIterator--;
                sprites.DecrizeSize(SizeChange);
            }

            else if (ScrlUp && ScrlIterator != ScrlList.Count() - 1)
            {
                DragDeltaCoord.X = ((DragDeltaCoord.X - ScrlToX) / SpritesSize) * (SpritesSize + SizeChange) + ScrlToX;
                DragDeltaCoord.Y = ((DragDeltaCoord.Y - ScrlToY) / SpritesSize) * (SpritesSize + SizeChange) + ScrlToY;
                sprites.IncrizeSize(SizeChange);
                ScrlIterator++;
            }
            else if (ScrlUp) ScrlUp = false;
            else if (ScrlDown) ScrlDown = false;
        }

        private void paint_vis(object sender, PaintEventArgs e)
        {
           
            if (ScrlDown || ScrlUp)
            {
                SmoothZoom();
            }
            Font f = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point);
            

            Map.draw_map(e, DragDeltaCoord);
            e.Graphics.DrawString("SpritesSize: " + sprites.GetSpritesSize().ToString() + "\n Sprites max/min sizes: " + sprites.GetSpritesMaxSize().ToString() + " ," + sprites.GetSpritesMinSize().ToString(), f, new SolidBrush(Color.Red), 200, 200);
            Building a = new Building(mouse_X, mouse_Y);

            a.Draw_building(e,buttons, DragDeltaCoord);

            buildingClass.Grah_build(e, DragDeltaCoord);
        }
    }
}