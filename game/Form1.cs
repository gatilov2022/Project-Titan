using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using game.Классы_визуала;

namespace game
{
    public partial class Form1 : Form
    {
        private Random rand = new Random();
        private int mouseX, mouseY,
            lastX = 0, lastY =0;

        private Button[] buttons;
        private Sprites sprites = new Sprites();
        private Point dragStartCoord, dragDeltaCoord = new Point(0,0);

        private int MaxMultipler = 10, MinMultipler = 4;

        private int spritesSize;

        private bool dragStarted = false;

        Map_Build buildingClass;

        public Form1()
        {
            Graphics g = this.CreateGraphics();
            InitializeComponent();
            timer1.Start();
            timer1.Tick += Timer1_Tick;
            buttons = new Button[] {factory_but ,pump_but ,drill_but ,base_but ,wareh_but ,house_but ,steam_but};

            spritesSize = sprites.GetSpritesSize();

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
            
        }
        
        private int scrlToX, scrlToY;
        bool scrlDown = false, scrlUp = false;
        private int PixelsDelta;
        private List<int> ScrlList = new List<int> () {};

        private void From1_MouseWheel(object sender, MouseEventArgs e)
        {

            scrlToX = e.X;
            scrlToY = e.Y;

            if (e.Delta < 0 && spritesSize > 8)
            {
                scrlDown = true;

            }
            else if (e.Delta > 0 && spritesSize < 119)
            {
                scrlUp = true;

            }
            Invalidate();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragStarted)
            {   
                //if  (dragDeltaCoord.X <= 0 & (dragDeltaCoord.X >= this.Width - Map.GetMapSize() * Sprites.size * Chunk.ChunkSize) )
                dragDeltaCoord.X -= (dragStartCoord.X - e.X);
            
                //if (dragDeltaCoord.Y <= -1 && dragDeltaCoord.Y <= Map.GetMapSize() * Sprites.size * Chunk.ChunkSize)
                dragDeltaCoord.Y -= (dragStartCoord.Y - e.Y);
                    
                dragStartCoord.Y = e.Y;
                dragStartCoord.X = e.X;
                Invalidate();
            }

            //Graphics DrawMouse = this.CreateGraphics();
            //DrawMouse.FillRectangle(new SolidBrush(Color.Black), e.X, e.Y + 20, 80, 25);
            //DrawMouse.DrawString((e.X).ToString() + " " + (e.Y).ToString(), new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point), Brushes.Red, e.X, e.Y + 20);

            var blockSize = sprites.GetSpritesSize();

            var currentXBlock = (e.X - dragDeltaCoord.X % blockSize) / blockSize;
            var currentYBlock = (e.Y - dragDeltaCoord.Y % blockSize) / blockSize;

            if (currentXBlock != lastX || currentYBlock != lastY)
            {
                lastY = currentYBlock; lastX = currentXBlock;
                mouseX = currentXBlock * blockSize;
                mouseY = currentYBlock * blockSize;
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
            else if (e.Button == MouseButtons.Right)
            {
                buildingClass.Add_build(new Point(mouseX, mouseY), buttons, dragDeltaCoord);
                Invalidate();
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragStarted = true;
                dragStartCoord.X = e.X;
                dragStartCoord.Y = e.Y;
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

        private void Zoom()
        {
            const int sizeChange = 14;
            spritesSize = sprites.GetSpritesSize();

            if (scrlDown)
            {
                dragDeltaCoord.X = ((dragDeltaCoord.X - scrlToX) / spritesSize) * (spritesSize - sizeChange) + scrlToX;
                dragDeltaCoord.Y = ((dragDeltaCoord.Y - scrlToY) / spritesSize) * (spritesSize - sizeChange) + scrlToY;
                sprites.DecrizeSize(sizeChange);
                scrlDown = false;
            }

            else if (scrlUp)
            {
                dragDeltaCoord.X = ((dragDeltaCoord.X - scrlToX) / spritesSize) * (spritesSize + sizeChange) + scrlToX;
                dragDeltaCoord.Y = ((dragDeltaCoord.Y - scrlToY) / spritesSize) * (spritesSize + sizeChange) + scrlToY;
                sprites.IncrizeSize(sizeChange);
                scrlUp = false;
            }
            //else if (scrlUp) scrlUp = false;
            //else if (scrlDown) scrlDown = false;
        }

        private void paint_vis(object sender, PaintEventArgs e)
        {
           
            if (scrlDown || scrlUp)
            {
                Zoom();
            }
            Font f = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point);
            

            Map.draw_map(e, dragDeltaCoord);
            e.Graphics.DrawString("spritesSize: " + sprites.GetSpritesSize().ToString() + "\n Sprites max/min sizes: " + sprites.GetSpritesMaxSize().ToString() + " ," + sprites.GetSpritesMinSize().ToString(), f, new SolidBrush(Color.Red), 200, 200);
            Building a = new Building(mouseX, mouseY);

            a.Draw_building(e,buttons, dragDeltaCoord);

            buildingClass.Grah_build(e, dragDeltaCoord);
        }
    }
}