using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace game
{
    internal class Grass : Sprites
    {

        static SolidBrush ForestGreenBrush = new SolidBrush(Color.ForestGreen);
        static SolidBrush GreenBrush = new SolidBrush(Color.Green);
        static SolidBrush DarkBrush = new SolidBrush(Color.DarkGreen);
        static SolidBrush DarkOliveBrush = new SolidBrush(Color.DarkOliveGreen);

        static public List<SolidBrush> green_brush_list = new List<SolidBrush>() { ForestGreenBrush, GreenBrush, DarkBrush, DarkOliveBrush };

        List<SolidBrush> part_color = new List<SolidBrush>();
          
            public Grass(int in_x, int in_y)
            {
                part_color = Sprites.generate_texture(green_brush_list);
                this.x = in_x; this.y = in_y;
            }
        public new void draw_block(PaintEventArgs e)
        {

            Sprites.draw_sprite(x, y, part_color, e);

        }
    }
}
