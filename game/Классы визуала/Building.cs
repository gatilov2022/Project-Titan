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
        Random random = new Random();

        public Building(int X, int Y)
        {
            x = X; y = Y;
        }
        public void Draw_building(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Bitmap bit;
            Rectangle rec = new Rectangle(x - Sprites.size / 2, y - Sprites.size / 2, Sprites.size, Sprites.size);

            bit = global::game.Properties.Resources.Factory_1lvl;
           // bit = global::game.Properties.Resources.Base;
           // bit = global::game.Properties.Resources.Drill_Burner_1lvl;
           // bit = global::game.Properties.Resources.Home_Defult;
           // bit = global::game.Properties.Resources.Pump_1lvl;
           // bit = global::game.Properties.Resources.Steam_Eng_1lvl;
           // bit = global::game.Properties.Resources.Warehouse;

            g.DrawImage(bit,rec);
        }
    }
}
