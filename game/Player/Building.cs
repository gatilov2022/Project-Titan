using System.Drawing;
using System.Windows.Forms;
using game.World_map;

namespace game.Player
{
    public class Building : Sprites
    {
        Bitmap[] bitmaps = new Bitmap[] {
            Properties.Resources.Factory_1lvl, Properties.Resources.Pump_1lvl,
            Properties.Resources.Drill_Burner_1lvl, Properties.Resources.Base,
            Properties.Resources.Warehouse, Properties.Resources.Home_Defult,
            Properties.Resources.Steam_Eng_1lvl
        };

        public Building(int X, int Y)
        {
            base.X = X; base.Y = Y;
        }
        public void Draw_building(PaintEventArgs e, Button[] buts, Point DragDelta)
        {
            var SpritesSize = new Sprites().GetSpritesSize();

            var g = e.Graphics;
            var rec = new Rectangle(DragDelta.X % SpritesSize + X, DragDelta.Y % SpritesSize + Y, SpritesSize + 1, SpritesSize + 1);

            for (int m = 0; m < buts.Length; m++)
            {
                if (buts[m].FlatAppearance.BorderColor == Color.Blue)
                {
                    g.DrawImage(bitmaps[m], rec);
                    
                    g.FillRectangle(new SolidBrush(Color.FromArgb(60, Color.Green)), rec);
                    break;
                }
            }
        }
    }
}