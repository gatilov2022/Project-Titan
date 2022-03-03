using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace game
{
    public class Factory : Building
    {
            static List<RectangleF> rectangleF = new List<RectangleF>();
            public Factory(int x, int y) : base(x, y)
            {

                rect_size.Add(new RectangleF(x, y, size, size));
                rect_color.Add(new SolidBrush(Color.DarkGoldenrod));


                rect_size.Add(new RectangleF(x + size / 12, y + size / 12, size - size / 6, size - size / 6));
                this.rect_color.Add(new SolidBrush(Color.DarkBlue));

                rect_size.Add(new RectangleF(x + size / 8, y + size / 8, size - size / 4, size - size / 4));
                rect_color.Add(new SolidBrush(Color.DarkGoldenrod));

                rect_size.Add(new RectangleF(x + 5, y - 4, size / 8, size / 2));
                rect_color.Add(new SolidBrush(Color.FromArgb(189, 183, 107)));

                //rect_size.Add(new RectangleF(x + 5, y - 4, size / 8, size / 2));
                //rect_color.Add(new SolidBrush(Color.DarkBlue));

            }
    }
}
