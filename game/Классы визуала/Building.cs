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
        protected List<RectangleF> rect_size = new List<RectangleF>();
        protected List<SolidBrush> rect_color = new List<SolidBrush>();

        public Building(int X, int Y)
        {
            x = X; y = Y;
        }
        public void Draw_building(PaintEventArgs e)
        {

            Graphics g = e.Graphics;
            for (int i = 0; i < rect_size.Count; i++)
            {
                g.FillRectangle(rect_color[i], rect_size[i]);
            }
        }
    }
}
