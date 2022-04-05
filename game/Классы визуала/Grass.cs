﻿using System.Collections.Generic;
using System.Drawing;

namespace game.Классы_визуала
{
    internal class Grass : Sprites
    {
        private static readonly List<SolidBrush> GreenBrushList = new List<SolidBrush>() { new SolidBrush(Color.ForestGreen), new SolidBrush(Color.Green), new SolidBrush(Color.DarkGreen), new SolidBrush(Color.DarkOliveGreen) };

        private readonly List<SolidBrush> _partColor;

        public Grass(int inX, int inY)
        {
            _partColor = Sprites.Generate_texture(GreenBrushList);
            this.X = inX; this.Y = inY;
        }

        public void Draw_block(Graphics g)
        {
            Sprites.Draw_sprite(X, Y, _partColor, g);
        }
    }
}
