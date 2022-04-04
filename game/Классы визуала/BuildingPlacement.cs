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
        //Исправить
        //
        private List<Point> fr1 = new List<Point>();
        private List<Point> fr2 = new List<Point>();

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

                    fr2.Add(new Point(fromWhatBlockX, fromWhatBlockY));
                    fr1.Add(new Point(fromWhatChunkX, fromWhatChunkY));

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
                int xWithDrag = (fr2[i].X + fr1[i].X * Chunk.ChunkSize) * size + Drag.X,
                yWithDrag = (fr2[i].Y + fr1[i].Y * Chunk.ChunkSize) * size + Drag.Y;

                Rectangle rec = new Rectangle(xWithDrag, yWithDrag, size, size);
                g.DrawImage(tiles[i], rec);
            }
        }
    }
}
