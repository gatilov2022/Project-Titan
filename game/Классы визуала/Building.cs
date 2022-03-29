using System.Drawing;
using System.Windows.Forms;

namespace game.Классы_визуала
{
    public class Building : Sprites
    {
        Bitmap[] bitmaps = new Bitmap[] {
            global::game.Properties.Resources.Factory_1lvl, global::game.Properties.Resources.Pump_1lvl,
            global::game.Properties.Resources.Drill_Burner_1lvl, global::game.Properties.Resources.Base,
            global::game.Properties.Resources.Warehouse, global::game.Properties.Resources.Home_Defult,
            global::game.Properties.Resources.Steam_Eng_1lvl
        };
        int fromWhatChunkX, fromWhatBlockX;
        int fromWhatChunkY, fromWhatBlockY;

        public Building(int X, int Y)
        {
            x = X ; y = Y;
        }
        public void Draw_building(PaintEventArgs e, Button[] buts, Point DragDelta)
        {
            int size = new Sprites().GetSpritesSize();
            //Исправить?
            fromWhatChunkX = (x - DragDelta.X) / (size * Chunk.ChunkSize);
            fromWhatChunkY = (y - DragDelta.Y) / (size * Chunk.ChunkSize);

            fromWhatBlockX = ((x - DragDelta.X) % (size * Chunk.ChunkSize)) / size;
            fromWhatBlockY = ((y - DragDelta.Y) % (size * Chunk.ChunkSize)) / size;

            int xWithDrag = (fromWhatBlockX + fromWhatChunkX * Chunk.ChunkSize) * size + DragDelta.X,
            yWithDrag = (fromWhatBlockY + fromWhatChunkY * Chunk.ChunkSize) * size + DragDelta.Y;

            Graphics g = e.Graphics;
            Rectangle rec = new Rectangle(xWithDrag, yWithDrag, size, size);

            for (int m = 0; m < buts.Length; m++)
            {
                if(buts[m].FlatAppearance.BorderColor == Color.Blue)
                {
                    g.DrawImage(bitmaps[m], rec);
                    g.FillRectangle(new SolidBrush(Color.FromArgb(60, Color.Green)), rec);
                    break;
                }
            }
        }
    }
}
