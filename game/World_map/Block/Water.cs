using System.Collections.Generic;
using System.Drawing;

namespace game.World_map.Block
{
    internal class Water : Sprites
    {
        static readonly List<SolidBrush> BlueBrushList = new List<SolidBrush>() 
        {
            new SolidBrush(Color.FromArgb(255, 20, 20, 180)),
            new SolidBrush(Color.FromArgb(255, 30, 30, 180)),
            new SolidBrush(Color.FromArgb(255, 25, 25, 180))
        };
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