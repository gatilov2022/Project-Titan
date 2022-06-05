using System;
using System.Collections.Generic;
using System.Drawing;

namespace game.World_map.Block
{
    [Serializable]
    internal class Ore : Sprites
    {
        private const string blockType = "Ore";
        [NonSerialized()]
        public static List<SolidBrush> OreBrushList = new List<SolidBrush>() 
        { 
            new SolidBrush(Color.FromArgb(255, 128, 128, 128)),
            new SolidBrush(Color.FromArgb(255, 189, 154, 129)),
            new SolidBrush(Color.FromArgb(255, 128, 128, 128)),
            new SolidBrush(Color.FromArgb(255, 116, 116, 128)),
            new SolidBrush(Color.FromArgb(255, 142, 142, 128))
        }; 
        [NonSerialized()]
        private readonly List<SolidBrush> _partColor;

        public Ore(int inX, int inY)
        {
            _partColor = Sprites.Generate_texture(OreBrushList);
            this.X = inX; this.Y = inY;
        }

        public void DrawBlock(Graphics g)
        {
            Sprites.Draw_sprite(X, Y, _partColor, g);
        }
    }
}