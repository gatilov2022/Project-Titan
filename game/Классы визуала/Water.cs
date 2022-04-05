﻿using System.Collections.Generic;
using System.Drawing;

namespace game.Классы_визуала
{
    internal class Water : Sprites
    {
        private static readonly SolidBrush FirstBlueBrush = new SolidBrush(Color.FromArgb(255, 20, 20, 180));
        private static readonly SolidBrush SecondBlueBrush = new SolidBrush(Color.FromArgb(255, 30, 30, 180));
        private static readonly SolidBrush ThirdBlueBrush = new SolidBrush(Color.FromArgb(255, 25, 25, 180));

        static readonly List<SolidBrush> BlueBrushList = new List<SolidBrush>() { FirstBlueBrush, SecondBlueBrush, ThirdBlueBrush };
        private readonly List<SolidBrush> _partColor;

        public Water(int inX, int inY)
        {

            _partColor = Sprites.Generate_texture(BlueBrushList);
            this.X = inX; this.Y = inY;
        }
        public void Draw_block(Graphics g)
        {
            Sprites.Draw_sprite(X, Y, _partColor, g);

        }
    }
}
