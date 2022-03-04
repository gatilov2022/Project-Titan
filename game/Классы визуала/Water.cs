using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace game
{
    internal class Water : Sprites
    {
        static SolidBrush first_blue_brush = new SolidBrush(Color.FromArgb(255, 20, 20, 180));
        static SolidBrush second_blue_brush = new SolidBrush(Color.FromArgb(255, 30, 30, 180));
        static SolidBrush third_blue_brush = new SolidBrush(Color.FromArgb(255, 25, 25, 180));

        static List<SolidBrush> blue_brush_list = new List<SolidBrush>() { first_blue_brush, second_blue_brush, third_blue_brush };
        private readonly List<SolidBrush> part_color;

        public Water(int in_x, int in_y)
        {

            part_color = Sprites.Generate_texture(blue_brush_list);
            this.x = in_x; this.y = in_y;
        }
        public void Draw_block(PaintEventArgs e)
        {

            Sprites.draw_sprite(x, y, part_color, e);

        }
    }
}
