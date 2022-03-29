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

        private readonly List<Bitmap> tiles = new List<Bitmap>();
        private readonly List<Point> onMapCoord = new List<Point>();

        public void Add_build(Point p, Button[] buts, Point Drag)
        {
            var blockSize = new Sprites().GetSpritesSize();
            var chunkSize = Chunk.GetChunkSize();


            for (var m = 0; m < buts.Length; m++)
            {
                if (buts[m].FlatAppearance.BorderColor != Color.Blue) continue;
                //whatChunk.Add(new Point((p.X - Drag.X) / (size * Chunk.ChunkSize), (p.Y - Drag.Y) / (size * Chunk.ChunkSize)));
                //whatBlock.Add(new Point((p.X - Drag.X) % (size * Chunk.ChunkSize) / size, (p.Y - Drag.Y) % (size * Chunk.ChunkSize) / size));
                
                onMapCoord.Add(new Point((p.X - Drag.X) / blockSize, (p.Y - Drag.Y) / blockSize));

                tiles.Add(bitmaps[m]);
                break;
            }
        }


        //Font fontSample = new Font("Arial", 12);
        //SolidBrush brushSample = new SolidBrush(Color.DarkBlue);
        public void Grah_build(PaintEventArgs e, Point Drag)
        {
            var blockSize = new Sprites().GetSpritesSize(); 
            var chunkSize = Chunk.GetChunkSize();
            var mapSize = Map.GetMapSize();

            var g = e.Graphics;
            for (var i = 0; i < tiles.Count; i++)
            {
                int actualX = onMapCoord[i].X * blockSize + Drag.X, actualY = onMapCoord[i].Y * blockSize + Drag.Y;
                Rectangle rec = new Rectangle(actualX, actualY, blockSize, blockSize);
                g.DrawImage(tiles[i], rec);

                //g.DrawString("X: " + xWithDrag + " Y: " + yWithDrag + "\n X: " + points[i].X + " Y: " + points[i].Y, fontSample, brushSample, xWithDrag + size, yWithDrag + size);
            }
        }
    }
}
