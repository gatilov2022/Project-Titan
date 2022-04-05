using System.Collections.Generic;
using System.Drawing;

namespace game.Классы_визуала
{
    internal class Sand : Sprites
    {
        private static readonly SolidBrush FirstYellowBrush = new SolidBrush(Color.FromArgb(255, 210, 203, 149));
        private static readonly SolidBrush SecondYellowBrush = new SolidBrush(Color.FromArgb(255, 175, 168, 114));
        private static readonly SolidBrush ThirdYellowBrush = new SolidBrush(Color.FromArgb(255, 220, 207, 164));
        private static readonly SolidBrush FourthYellowBrush = new SolidBrush(Color.FromArgb(255, 254, 254, 211));

        public static List<SolidBrush> YellowBrushList = new List<SolidBrush>() { FirstYellowBrush, SecondYellowBrush, ThirdYellowBrush, FourthYellowBrush };
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
