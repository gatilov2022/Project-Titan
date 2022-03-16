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

        static readonly SolidBrush first_ore_brush = new SolidBrush(Color.FromArgb(255, 128, 128, 128));
        static readonly SolidBrush second_ore_brush = new SolidBrush(Color.FromArgb(255, 189, 154, 129));
        static readonly SolidBrush third_ore_brush = new SolidBrush(Color.FromArgb(255, 128, 128, 128));
        static readonly SolidBrush fourth_ore_brush = new SolidBrush(Color.FromArgb(255, 116, 116, 128));
        static readonly SolidBrush fifth_ore_brush = new SolidBrush(Color.FromArgb(255, 142, 142, 128));

        static public List<SolidBrush> ore_brush_list = new List<SolidBrush>() { first_ore_brush, second_ore_brush, third_ore_brush, fourth_ore_brush, fifth_ore_brush };
        readonly List<SolidBrush> part_color = new List<SolidBrush>();

        public Ore(int in_x, int in_y)
        {
            part_color = Sprites.Generate_texture(ore_brush_list);

            this.x = in_x; this.y = in_y;
        }

        public void Draw_block(Graphics g)
        {
            Sprites.Draw_sprite(x, y, part_color, g);
        }
    }
}
