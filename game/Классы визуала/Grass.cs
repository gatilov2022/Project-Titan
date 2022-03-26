using System.Collections.Generic;
using System.Drawing;

namespace game.Классы_визуала
{
    internal class Grass : Sprites
    {

        static public List<SolidBrush> green_brush_list = new List<SolidBrush>() { new SolidBrush(Color.ForestGreen), new SolidBrush(Color.Green), new SolidBrush(Color.DarkGreen), new SolidBrush(Color.DarkOliveGreen) };

        readonly List<SolidBrush> part_color = new List<SolidBrush>();

        public Grass(int in_x, int in_y)
        {
            part_color = Sprites.Generate_texture(green_brush_list);
            this.x = in_x; this.y = in_y;
        }

        public void Draw_block(Graphics g)
        {

            Sprites.Draw_sprite(x, y, part_color, g);

        }
    }
}
