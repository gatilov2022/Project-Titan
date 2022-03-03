using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace game
{
    internal class Ore : Sprites
    {

        static SolidBrush first_ore_brush = new SolidBrush(Color.FromArgb(255, 128, 128, 128));
        static SolidBrush second_ore_brush = new SolidBrush(Color.FromArgb(255, 189, 154, 129));
        static SolidBrush third_ore_brush = new SolidBrush(Color.FromArgb(255, 128, 128, 128));
        static SolidBrush fourth_ore_brush = new SolidBrush(Color.FromArgb(255, 128, 128, 128));
        static SolidBrush fifth_ore_brush = new SolidBrush(Color.FromArgb(255, 128, 128, 128));

        static public List<SolidBrush> ore_brush_list = new List<SolidBrush>() { first_ore_brush, second_ore_brush, third_ore_brush, fourth_ore_brush, fifth_ore_brush };

        List<SolidBrush> part_color = new List<SolidBrush>();

        public Ore(int in_x, int in_y)
        {
            part_color = Sprites.generate_texture(ore_brush_list);

            this.x = in_x; this.y = in_y;
        }

        public new void draw_block(PaintEventArgs e)
        {

            Sprites.draw_sprite(x, y, part_color, e);

        }
    }
}
