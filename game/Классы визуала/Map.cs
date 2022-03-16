using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace game
{
    internal class Map
    {
        // Класс карта. Хранит в себе все объекты на карте, а так же отвечает за их отрисовку

        // Список чанков
        static List<Chunk> Chunks = new List<Chunk>();

        
        static bool chek1 = false;
        static private Bitmap bitmap = new Bitmap(1980, 1080);

        static int Map_Size = 16;

        static public void GenerateMap()
        {
            for (int i = 0; i < Map_Size; i++)
            {
                for (int j = 0; j < Map_Size; j++)
                {
                    Chunk NewChunk = new Chunk(i, j);
                    Chunks.Add(NewChunk);
                }
            }
        }
        // Добавление всех типов в соответствующие списки
        
        static public Point GetChunk()
        {
            int loc_x = 255 % 16 * Sprites.size * Chunk.ChunkSize;
            int loc_y = 255 / 16 * Sprites.size * Chunk.ChunkSize;
            Point point = new Point(loc_x, loc_y);
            return point;
        }

        public static int GetMapSize()
        {
            return Map_Size;
        }

        // Отрисовка всех объектов из всех списков
        static public void draw_map(PaintEventArgs e, Point DragDelta)
        {
            int loc_x, loc_y;

            Graphics g = e.Graphics;
            Bitmap ReadyToDrawImage;

            

            for (int i = 0; i < Chunks.Count; i++)
            {
                loc_x = i % 16 * Sprites.size * Chunk.ChunkSize;
                loc_y = i / 16 * Sprites.size * Chunk.ChunkSize;

                ReadyToDrawImage = Chunks[i].GetImage();

                g.DrawImage(ReadyToDrawImage, DragDelta.X + loc_x, DragDelta.Y + loc_y, Sprites.size * Chunk.ChunkSize, Sprites.size * Chunk.ChunkSize);
                g.DrawRectangle(new Pen(Color.Gray , 4), DragDelta.X + loc_x - 2 , DragDelta.Y + loc_y - 2, Sprites.size * Chunk.ChunkSize + 4, Sprites.size * Chunk.ChunkSize + 4);
                //g.DrawRectangle(new Pen(Color.Red), loc_x, loc_y, Sprites.size * Chunk.ChunkSize, Sprites.size * Chunk.ChunkSize);
            }

        }
    }
}
