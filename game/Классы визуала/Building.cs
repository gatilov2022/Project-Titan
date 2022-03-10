using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace game
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
            Graphics g = e.Graphics;
            Rectangle rec = new Rectangle(DragDelta.X + x - Sprites.size / 2, DragDelta.Y + y - Sprites.size / 2, Sprites.size, Sprites.size);

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
