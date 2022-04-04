using System.Drawing;
using System.Windows.Forms;

namespace game.Классы_визуала
{
    public class Building : Sprites
    {
        Bitmap[] bitmaps = new Bitmap[] {
            global::game.Properties.Resources.Factory_1lvl, global::game.Properties.Resources.Pump_1lvl,
            global::game.Properties.Resources.Drill_Burner_1lvl, global::game.Properties.Resources.Base,
            global::game.Properties.Resources.Warehouse, global::game.Properties.Resources.Home_Defult,
            global::game.Properties.Resources.Steam_Eng_1lvl
        };

        public Building(int X, int Y)
        {
            x = X; y = Y;
        }
        public void Draw_building(PaintEventArgs e, Button[] buts, Point DragDelta)
        {
            int SpritesSize = new Sprites().GetSpritesSize();

            Graphics g = e.Graphics;
            Rectangle rec = new Rectangle(DragDelta.X % SpritesSize + x, DragDelta.Y % SpritesSize + y, SpritesSize + 1, SpritesSize + 1);

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