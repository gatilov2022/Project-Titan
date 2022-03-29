using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace game.Классы_визуала
{
    internal class Map_Build
    {
        readonly Bitmap[] bitmaps = new Bitmap[] {
            Properties.Resources.Factory_1lvl, Properties.Resources.Pump_1lvl,
            Properties.Resources.Drill_Burner_1lvl, Properties.Resources.Base,
            Properties.Resources.Warehouse, Properties.Resources.Home_Defult,
            Properties.Resources.Steam_Eng_1lvl
        };

        int fromWhatChunkX, fromWhatBlockX;
        int fromWhatChunkY, fromWhatBlockY;

        private List<Bitmap> tiles = new List<Bitmap>();
        private List<Point> points = new List<Point>();

        public void Add_build(Point p, Button[] buts, Point Drag)
        {
            int size = new Sprites().GetSpritesSize();

            for (int m = 0; m < buts.Length; m++)
            {
                if (buts[m].FlatAppearance.BorderColor == Color.Blue)
                {
                    fromWhatChunkX = (p.X - Drag.X) / (size * Chunk.ChunkSize);
                    fromWhatChunkY = (p.Y - Drag.Y) / (size * Chunk.ChunkSize);

                    fromWhatBlockX = ((p.X - Drag.X ) % (size * Chunk.ChunkSize)) / size;
                    fromWhatBlockY = ((p.Y - Drag.Y ) % (size * Chunk.ChunkSize)) / size;

                    points.Add(p);
                    tiles.Add(bitmaps[m]);
                    break;
                }
            }
        }


        Font fontSample = new Font("Arial", 12);
        SolidBrush brushSample = new SolidBrush(Color.DarkBlue);
        public void Grah_build(PaintEventArgs e, Point Drag)
        {
            int size = new Sprites().GetSpritesSize();

            Graphics g = e.Graphics;
            for (int i = 0; i < tiles.Count; i++)
            {
                int xWithDrag = (fromWhatBlockX + fromWhatChunkX * Chunk.ChunkSize) * size + Drag.X,
                yWithDrag = (fromWhatBlockY + fromWhatChunkY * Chunk.ChunkSize) * size + Drag.Y;

                Rectangle rec = new Rectangle(xWithDrag, yWithDrag, size, size);
                g.DrawImage(tiles[i], rec);

                g.DrawString("X: " + xWithDrag + " Y: " + yWithDrag + "\n X: " + points[i].X + " Y: " + points[i].Y, fontSample, brushSample, xWithDrag + size, yWithDrag + size);
            }
        }
    }
}
