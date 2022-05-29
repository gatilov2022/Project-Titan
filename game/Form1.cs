﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using game.Player;
using game.World_map;

namespace game
{
    public partial class Form1 : Form
    {
        private int mouseX, mouseY,lastX = 0, lastY =0, spritesSize, scrlToX, scrlToY;
        private const int sizeChange = 14;
        private Button[] _buttons;
        private readonly Sprites Sprites = new Sprites();
        private Point _dragStartCoordinates, _dragDeltaCoordinates = new Point(0,0);

        private const double MaxMultiplier = 4, MinMultiplier = 0.5;
        private bool dragStarted = false, scrlDown = false, scrlUp = false;
        private readonly StartMenu _startMenu;

        private const int resourceInfoY = 4;
        private const int resourceShiftX = 60;

        public Form1(StartMenu startMenu)
        {
            InitializeComponent();
            timer1.Start();

            _startMenu = startMenu;
            _buttons = new Button[] {factory_but ,pump_but ,drill_but ,base_but ,wareh_but ,house_but ,steam_but};

            spritesSize = Sprites.GetSpritesSize();
            
            this.MouseWheel += new MouseEventHandler(From1_MouseWheel);

            
            Sprites.SetSpritesMinSize((int)(Convert.ToInt32(Math.Sqrt(Sprites.GetPixelCount())) * MinMultiplier * 2));
            Sprites.SetSpritesMaxSize((int)(Convert.ToInt32(Math.Sqrt(Sprites.GetPixelCount())) * MaxMultiplier * 2));

            Map.GenerateMap();    
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Zoom();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Player.Player.SetShiftToZero();
            Building.UpdateResources();
            Invalidate();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _startMenu.Show();
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            if (Building.HasBuildingOnTheBlock(new Point(mouseX, mouseY), _dragDeltaCoordinates))
            {
                Building someBuilding= Building.GetBuilding(new Point(mouseX, mouseY), _dragDeltaCoordinates) as Building;

                //if (MessageBox.Show("Улучшить здание?", "UpBuild", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
                    someBuilding.UpgradeBuilding();
                
            }
        }

        private void From1_MouseWheel(object sender, MouseEventArgs e)
        {
            scrlToX = e.X;
            scrlToY = e.Y;

            spritesSize = Sprites.GetSpritesSize();

            if (e.Delta < 0 && spritesSize - 14 >= Sprites.GetSpritesMinSize())
                scrlDown = true;
            else if (e.Delta > 0 && spritesSize + 14 <= Sprites.GetSpritesMaxSize())
                scrlUp = true;

            Invalidate();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragStarted)
            {
                var xDelta = _dragStartCoordinates.X - e.X;
                var yDelta = _dragStartCoordinates.Y - e.Y;

                var mapSizeInPixels = Map.GetMapSize() * Chunk.GetChunkSize() * spritesSize;

                if (-_dragDeltaCoordinates.X + xDelta >= 1 && -_dragDeltaCoordinates.X + xDelta + this.Width <= mapSizeInPixels - 1)
                {
                    _dragDeltaCoordinates.X -= (_dragStartCoordinates.X - e.X);
                   
                } 
                else if (-_dragDeltaCoordinates.X + this.Width + xDelta > mapSizeInPixels)
                    _dragDeltaCoordinates.X = -mapSizeInPixels + this.Width + 1;

                else if (-_dragDeltaCoordinates.X + xDelta < 0) 
                    _dragDeltaCoordinates.X = 0;




                if (-_dragDeltaCoordinates.Y + yDelta >= 1 && -_dragDeltaCoordinates.Y + yDelta + this.Height <= mapSizeInPixels - 1) 
                {
                    _dragDeltaCoordinates.Y -= (_dragStartCoordinates.Y - e.Y);
                    
                }
                else if (-_dragDeltaCoordinates.Y + this.Height + yDelta > mapSizeInPixels)
                    _dragDeltaCoordinates.Y = -mapSizeInPixels + this.Height + 1;

                else if (-_dragDeltaCoordinates.Y + yDelta < 0)
                    _dragDeltaCoordinates.Y = 0;


                _dragStartCoordinates.X = e.X;
                _dragStartCoordinates.Y = e.Y;

                Invalidate();
            }

            var blockSize = Sprites.GetSpritesSize();

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
                    if (!Building.Checking_The_Building(new Point(mouseX, mouseY), _dragDeltaCoordinates, _buttons))
                        return;
                    new Building().PlaceBuilding(new Point(mouseX, mouseY), _buttons, _dragDeltaCoordinates);
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
            spritesSize = Sprites.GetSpritesSize();

            if (scrlDown)
            {
                Sprites.DecreaseSize(sizeChange);

                _dragDeltaCoordinates.X = (_dragDeltaCoordinates.X - scrlToX) / spritesSize * (spritesSize - sizeChange) + scrlToX;
                _dragDeltaCoordinates.Y = (_dragDeltaCoordinates.Y - scrlToY) / spritesSize * (spritesSize - sizeChange) + scrlToY;
                
                scrlDown = false;
            }

            else if (scrlUp)
            {
                _dragDeltaCoordinates.X = ((_dragDeltaCoordinates.X - scrlToX) / spritesSize) * (spritesSize + sizeChange) + scrlToX;
                _dragDeltaCoordinates.Y = ((_dragDeltaCoordinates.Y - scrlToY) / spritesSize) * (spritesSize + sizeChange) + scrlToY;

                Sprites.IncreaseSize(sizeChange);

                scrlUp = false;
            }

            spritesSize = Sprites.GetSpritesSize();
            var mapSizeInPixels = Map.GetMapSize() * Chunk.GetChunkSize() * spritesSize;

            if (-_dragDeltaCoordinates.X + this.Width > mapSizeInPixels)

                _dragDeltaCoordinates.X = -(mapSizeInPixels - this.Width);

            else if (-_dragDeltaCoordinates.X < 0) 

                _dragDeltaCoordinates.X = 0;


            if (-_dragDeltaCoordinates.Y + this.Height > mapSizeInPixels)

                _dragDeltaCoordinates.Y = -(mapSizeInPixels - this.Height);

            else if (-_dragDeltaCoordinates.Y < 0)

                _dragDeltaCoordinates.Y = 0;

        }
        private void paint_vis(object sender, PaintEventArgs e)
        {
            if (scrlDown || scrlUp)
                Zoom();
            Graphics graphicsForm = e.Graphics;
            Font f = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point);

            var chunkNumber = (-_dragDeltaCoordinates.Y + mouseY) / (Chunk.GetChunkSize() * Sprites.GetSpritesSize()) * Map.GetMapSize() +
                              (-_dragDeltaCoordinates.X + mouseX) / (Sprites.GetSpritesSize() * Chunk.GetChunkSize());

            var blockNumber = (-_dragDeltaCoordinates.Y + mouseY) / Sprites.GetSpritesSize() % Chunk.GetChunkSize() * Chunk.GetChunkSize()+
                              (-_dragDeltaCoordinates.X + mouseX) / Sprites.GetSpritesSize() % Chunk.GetChunkSize();

            var block = Map.GetBlockType(new Point(-_dragDeltaCoordinates.X + mouseX, -_dragDeltaCoordinates.Y + mouseY));
            bool checkBlock =
                Building.Checking_The_Building(new Point(mouseX, mouseY), _dragDeltaCoordinates, _buttons);

            Map.Draw_map(graphicsForm, _dragDeltaCoordinates,this.Size);
            e.Graphics.DrawString("spritesSize: " + Sprites.GetSpritesSize() + "\n Sprites max/min sizes: " + Sprites.GetSpritesMaxSize() + " ," + Sprites.GetSpritesMinSize() + "\nDrags: X - "
                + _dragDeltaCoordinates.X + ", Y - " + _dragDeltaCoordinates.Y + $"\n ChunkNumber: {chunkNumber}\nBlockNumber: {blockNumber}"
                + $"\nBlocktype {block}\nCorrectBlock for build:{checkBlock}", f, new SolidBrush(Color.Wheat), 200, 200);
            Building.DrawCreatedBuildings(graphicsForm, _dragDeltaCoordinates);
            foreach (var someButton in _buttons)
            {
                if (someButton.FlatAppearance.BorderColor == Color.Blue)
                {

                    bool chekBuild =
                        Building.Checking_The_Building(new Point(mouseX, mouseY), _dragDeltaCoordinates, _buttons);
                    
                    Building.DrawBuilding(graphicsForm, _buttons, _dragDeltaCoordinates, mouseX, mouseY, chekBuild);
                }
            }


            Create_Top(graphicsForm, this.Size);
            Create_Bottom(graphicsForm, this.Size);
        }

        private void Create_Top(Graphics graphicsForm, Size sizeForm)
        {
            Font font = new Font("Arial", 11, FontStyle.Bold);
            SolidBrush brushWhite = new SolidBrush(Color.White);
            SolidBrush brushRed = new SolidBrush(Color.Red);
            SolidBrush brushGreen = new SolidBrush(Color.Green);
            var Start_Top_X = sizeForm.Width / 2 - Properties.Resources.Top_Interface.Width / 2;
            graphicsForm.DrawImage(Properties.Resources.Top_Interface, new Point(Start_Top_X, 0));

            //Отображение ресурсов
            graphicsForm.DrawString(Player.Player.GetAmountOfResources("Water").ToString(), font, brushWhite, Start_Top_X + 90, resourceInfoY + 24);
            graphicsForm.DrawString(Player.Player.GetAmountOfResources("Iron").ToString(), font, brushWhite, Start_Top_X + 90, resourceInfoY);
            graphicsForm.DrawString(Player.Player.GetAmountOfResources("Sand").ToString(), font, brushWhite, Start_Top_X + 215, resourceInfoY + 24) ;
            graphicsForm.DrawString(Player.Player.GetAmountOfResources("Energy").ToString(), font, brushWhite, Start_Top_X + 215, resourceInfoY);

            graphicsForm.DrawString(Player.Player.GetShiftRes("Water").ToString(), font, Player.Player.GetShiftRes("Water") < 0 ? brushRed : brushGreen,
                Start_Top_X + 90 + resourceShiftX, resourceInfoY + 24);
            graphicsForm.DrawString(Player.Player.GetShiftRes("Iron").ToString(), font, Player.Player.GetShiftRes("Iron") < 0 ? brushRed : brushGreen, Start_Top_X + 90 + resourceShiftX, resourceInfoY);
            graphicsForm.DrawString(Player.Player.GetShiftRes("Sand").ToString(), font, Player.Player.GetShiftRes("Sand") < 0 ? brushRed : brushGreen, Start_Top_X + 215 + resourceShiftX, resourceInfoY + 24);
            graphicsForm.DrawString(Player.Player.GetShiftRes("Energy").ToString(), font, Player.Player.GetShiftRes("Energy") < 0 ? brushRed : brushGreen, Start_Top_X + 215 + resourceShiftX, resourceInfoY);


            graphicsForm.DrawString(Player.Player.GetAmountOfResources("ComponentsT1").ToString(), font, brushWhite, Start_Top_X + 328, resourceInfoY);
            graphicsForm.DrawString(Player.Player.GetAmountOfResources("ComponentsT2").ToString(), font, brushWhite, Start_Top_X + 328, resourceInfoY + 14);
            graphicsForm.DrawString(Player.Player.GetAmountOfResources("ComponentsT3").ToString(), font, brushWhite, Start_Top_X + 328, resourceInfoY + 28);

            graphicsForm.DrawString(Player.Player.GetShiftRes("ComponentsT1").ToString(), font, Player.Player.GetShiftRes("ComponentsT1") < 0 ? brushRed : brushGreen,
                Start_Top_X + 328 + 30 , resourceInfoY);
            graphicsForm.DrawString(Player.Player.GetShiftRes("ComponentsT2").ToString(), font, Player.Player.GetShiftRes("ComponentsT2") < 0 ? brushRed : brushGreen, Start_Top_X + 328 + 30, resourceInfoY + 14);
            graphicsForm.DrawString(Player.Player.GetShiftRes("ComponentsT3").ToString(), font, Player.Player.GetShiftRes("ComponentsT3") < 0 ? brushRed : brushGreen, Start_Top_X + 328 + 30, resourceInfoY + 28);
        }

        private void Create_Bottom(Graphics graphicsForm, Size sizeForm)
        {
            var Start_bottom_X = sizeForm.Width / 2 - 420 / 2;
            graphicsForm.DrawImage(Properties.Resources.botton_button, Start_bottom_X, sizeForm.Height - 90, 420, 60);
        }
    }
}