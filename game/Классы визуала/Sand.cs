using System.Collections.Generic;
using System.Drawing;

namespace game
{
    internal class Sand : Sprites
    {
        static SolidBrush first_yellow_brush = new SolidBrush(Color.FromArgb(255, 210, 203, 149));
        static SolidBrush second_yellow_brush = new SolidBrush(Color.FromArgb(255, 175, 168, 114));
        static SolidBrush third_yellow_brush = new SolidBrush(Color.FromArgb(255, 220, 207, 164));
        static SolidBrush fourth_yellow_brush = new SolidBrush(Color.FromArgb(255, 254, 254, 211));
        static public List<SolidBrush> yellow_brush_list = new List<SolidBrush>() { first_yellow_brush, second_yellow_brush, third_yellow_brush, fourth_yellow_brush };

        List<SolidBrush> part_color = new List<SolidBrush>();
        
        public Sand(int in_x, int in_y)
        {
            part_color = Sprites.Generate_texture(yellow_brush_list);
            this.x = in_x; this.y = in_y;
        }

        public void Draw_block(Graphics g)
        {
            Sprites.Draw_sprite(x, y, part_color, g);
        }
    }
}
