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
            x = X - 1; y = Y - 1;
        }
        public void Draw_building(PaintEventArgs e, Button[] buts, Point DragDelta)
        {
            int SpritesSize = new Sprites().GetSpritesSize();

            Graphics g = e.Graphics;
            Rectangle rec = new Rectangle(DragDelta.X % SpritesSize + x - SpritesSize / 2, DragDelta.Y % SpritesSize + y - SpritesSize / 2, SpritesSize, SpritesSize);

            for(int m = 0; m < buts.Length; m++)
            {
                if(buts[m].FlatAppearance.BorderColor == Color.Blue)
                {
                    g.DrawImage(bitmaps[m], rec);
                    g.FillRectangle(new SolidBrush(Color.FromArgb(60, Color.Green)), rec);
                    break;
                }
            }
        }
    }
}
