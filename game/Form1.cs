using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using game.Player;
using game.World_map;
using game.Town;

namespace game
{
    public partial class Form1 : Form
    {
        private int mouseX, mouseY,lastX = 0, lastY =0, spritesSize, scrlToX, scrlToY;
        private const int sizeChange = 14;
        Random random = new Random();
        SoundPlayer sp;
        private readonly Button[] _buttons;
        private readonly Sprites _sprites = new Sprites();
        private Point _dragStartCoordinates, _dragDeltaCoordinates = new Point(0,0);

        private const double MaxMultiplier = 4, MinMultiplier = 0.5;
        private bool dragStarted = false, scrlDown = false, scrlUp = false;
        private readonly Map_Build _buildingClass;
        private readonly Buildings _buildings;
        private readonly Status _status;


        public Form1()
        {
            InitializeComponent();
            timer1.Start();

            _status = new Status();
            _buttons = new Button[] {factory_but ,pump_but ,drill_but ,base_but ,wareh_but ,house_but ,steam_but};
            _buildings = new Buildings();

            spritesSize = _sprites.GetSpritesSize();

            _buildingClass = new Map_Build();
            this.MouseWheel += new MouseEventHandler(From1_MouseWheel);

            
            _sprites.SetSpritesMinSize((int)(Convert.ToInt32(Math.Sqrt(_sprites.GetPixelCount())) * MinMultiplier * 2));
            _sprites.SetSpritesMaxSize((int)(Convert.ToInt32(Math.Sqrt(_sprites.GetPixelCount())) * MaxMultiplier * 2));

            Map.GenerateMap();    
        }
        
        private void Timer1_Tick(object sender, EventArgs e)
        {
            _buildings.Tick_Add(_status);
        }
        

        private void From1_MouseWheel(object sender, MouseEventArgs e)
        {
            scrlToX = e.X;
            scrlToY = e.Y;
            spritesSize = _sprites.GetSpritesSize();

            if (e.Delta < 0 && spritesSize - 14 >= _sprites.GetSpritesMinSize())
                scrlDown = true;
            else if (e.Delta > 0 && spritesSize + 14 <= _sprites.GetSpritesMaxSize())
                scrlUp = true;

            Invalidate();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragStarted)
            {
                var xDelta = _dragStartCoordinates.X - e.X;
                var yDelta = _dragStartCoordinates.Y - e.Y;
                if (-_dragDeltaCoordinates.X + xDelta >= 1 && -_dragDeltaCoordinates.X + xDelta + Form1.ActiveForm.Width <= Map.GetMapSize() * Chunk.GetChunkSize() * spritesSize - 1)
                {
                    _dragDeltaCoordinates.X -= (_dragStartCoordinates.X - e.X);
                    _dragStartCoordinates.X = e.X;
                }
                if (-_dragDeltaCoordinates.Y + yDelta >= 1 && -_dragDeltaCoordinates.Y + yDelta + Form1.ActiveForm.Height <= Map.GetMapSize() * Chunk.GetChunkSize() * spritesSize - 1) 
                {
                    _dragDeltaCoordinates.Y -= (_dragStartCoordinates.Y - e.Y);
                    _dragStartCoordinates.Y = e.Y;
                }
                Invalidate();
            }

            var blockSize = _sprites.GetSpritesSize();

            var currentXBlock = (e.X - _dragDeltaCoordinates.X % blockSize) / blockSize;
            var currentYBlock = (e.Y - _dragDeltaCoordinates.Y % blockSize) / blockSize;

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
            var but = sender as Button;
            if (but.FlatAppearance.BorderColor != Color.Blue)
                but.FlatAppearance.BorderColor = Color.Yellow;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    dragStarted = false;
                    break;
                case MouseButtons.Right:
                    _buildingClass.Add_build(new Point(mouseX, mouseY), _buttons, _dragDeltaCoordinates);
                    _buildings.Add_Resources(_buttons);
                    if(random.Next(2) ==0)
                        sp = new SoundPlayer(Properties.Resources.build);
                    else
                        sp = new SoundPlayer(Properties.Resources.build_hummer);
                    sp.Play();
                    Invalidate();
                    break;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragStarted = true;
                _dragStartCoordinates.X = e.X;
                _dragStartCoordinates.Y = e.Y;
            }
        }

        private void but_MouseLeave(object sender, EventArgs e)
        {
            var but = sender as Button;
            if (but.FlatAppearance.BorderColor != Color.Blue)
                but.FlatAppearance.BorderColor = Color.Red;
        }
        
        private void but_MouseClick(object sender, EventArgs e)
        {
            //События для кнопок, при нажатии которых, рамка Flat будет синей(Blue). При повторном клике, рамка меняет цвет на жёлтый(Yellow).
            var but = sender as Button;
            if (but.FlatAppearance.BorderColor != Color.Blue)
            {
                foreach (Button b in _buttons) { b.FlatAppearance.BorderColor = Color.Red; }
                but.FlatAppearance.BorderColor = Color.Blue;
            }
            else but.FlatAppearance.BorderColor = Color.Yellow;
            Invalidate();
        }

        private void Zoom()
        {
            spritesSize = _sprites.GetSpritesSize();

            if (scrlDown)
            {
                _dragDeltaCoordinates.X = (_dragDeltaCoordinates.X - scrlToX) / spritesSize * (spritesSize - sizeChange) + scrlToX;
                _dragDeltaCoordinates.Y = (_dragDeltaCoordinates.Y - scrlToY) / spritesSize * (spritesSize - sizeChange) + scrlToY;
                _sprites.DecreaseSize(sizeChange);
                scrlDown = false;
            }

            else if (scrlUp)
            {
                _dragDeltaCoordinates.X = ((_dragDeltaCoordinates.X - scrlToX) / spritesSize) * (spritesSize + sizeChange) + scrlToX;
                _dragDeltaCoordinates.Y = ((_dragDeltaCoordinates.Y - scrlToY) / spritesSize) * (spritesSize + sizeChange) + scrlToY;
                _sprites.IncreaseSize(sizeChange);
                scrlUp = false;
            }
        }

        private void paint_vis(object sender, PaintEventArgs e)
        {
            if (scrlDown || scrlUp)
                Zoom();

            Font f = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point);
            
            Map.Draw_map(e, _dragDeltaCoordinates);
            //e.Graphics.DrawString("spritesSize: " + _sprites.GetSpritesSize() + "\n Sprites max/min sizes: " + _sprites.GetSpritesMaxSize() + " ," + _sprites.GetSpritesMinSize(), f, new SolidBrush(Color.Red), 200, 200);
            Building a = new Building(mouseX, mouseY);

            a.Draw_building(e,_buttons, _dragDeltaCoordinates);

            _buildingClass.Grah_build(e, _dragDeltaCoordinates);
        }
    }
}