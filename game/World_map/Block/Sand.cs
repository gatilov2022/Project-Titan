using System.Collections.Generic;
using System.Drawing;

namespace game.World_map.Block
{
    internal class Sand : Sprites
    {
        public static List<SolidBrush> YellowBrushList = new List<SolidBrush>() 
        {
            new SolidBrush(Color.FromArgb(255, 210, 203, 149)),
            new SolidBrush(Color.FromArgb(255, 175, 168, 114)),
            new SolidBrush(Color.FromArgb(255, 220, 207, 164)),
            new SolidBrush(Color.FromArgb(255, 254, 254, 211))
        };

        private readonly List<SolidBrush> _partColor;
        
        public Sand(int inX, int inY)
        {
            _partColor = Sprites.Generate_texture(YellowBrushList);
            this.X = inX; this.Y = inY;
        }
        public void Draw_block(Graphics g)
        {
            Sprites.Draw_sprite(X, Y, _partColor, g);
        }
    }
}