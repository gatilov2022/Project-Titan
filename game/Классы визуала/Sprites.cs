using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace game
{
    public class Sprites
    {
        static Random rand = new Random();
        protected const int size = 119; // Значение должно быть кратно корню из pixel_count.

        public int x, y;
        static int pixel_count = 49; // Значение должно быть равно некоторому числу в квадрате.
        static int pixel_size = Convert.ToInt32(Math.Sqrt(pixel_count));

        static protected void Draw_sprite(int x, int y, List<SolidBrush> texture, Graphics g) // Отрисовка
        {

            for (int i = 0; i < pixel_count; i++)
            {
                g.FillRectangle(texture[i],
                    x * Sprites.size + i / pixel_size * Sprites.size / pixel_size,
                    y * Sprites.size + i % pixel_size * Sprites.size / pixel_size,
                    Sprites.size / pixel_size,
                    Sprites.size / pixel_size);
            }
        }

        public int what_siz()
        {
            return size;
        }


        static protected List<SolidBrush> Generate_texture(List<SolidBrush> brush_list)
        {
            List<SolidBrush> texture = new List<SolidBrush>();
            int n = brush_list.Count - 1;

            for (int i = 0; i < pixel_count; i++)
            {
                texture.Add(brush_list[rand.Next(0, n)]);
            }
            return texture;
        }

    }
}
