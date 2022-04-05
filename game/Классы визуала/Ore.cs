using System.Collections.Generic;
using System.Drawing;

namespace game.Классы_визуала
{
    internal class Ore : Sprites
    {
        private static readonly SolidBrush FirstOreBrush = new SolidBrush(Color.FromArgb(255, 128, 128, 128));
        private static readonly SolidBrush SecondOreBrush = new SolidBrush(Color.FromArgb(255, 189, 154, 129));
        private static readonly SolidBrush ThirdOreBrush = new SolidBrush(Color.FromArgb(255, 128, 128, 128));
        private static readonly SolidBrush FourthOreBrush = new SolidBrush(Color.FromArgb(255, 116, 116, 128));
        private static readonly SolidBrush FifthOreBrush = new SolidBrush(Color.FromArgb(255, 142, 142, 128));

        public static List<SolidBrush> OreBrushList = new List<SolidBrush>() { FirstOreBrush, SecondOreBrush, ThirdOreBrush, FourthOreBrush, FifthOreBrush };
        private readonly List<SolidBrush> _partColor;

        public Ore(int inX, int inY)
        {
            _partColor = Sprites.Generate_texture(OreBrushList);
            this.X = inX; this.Y = inY;
        }

        public void Draw_block(Graphics g)
        {
            Sprites.Draw_sprite(X, Y, _partColor, g);
        }
    }
}
