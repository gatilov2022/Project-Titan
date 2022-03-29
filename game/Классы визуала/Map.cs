using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace game.Классы_визуала
{
    internal class Map
    {
        // Класс карта. Хранит в себе все объекты на карте, а так же отвечает за их отрисовку

        // Список чанков
        static List<Chunk> Chunks = new List<Chunk>();

        static int Map_Size = 8;

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
            int SpritesSize = new Sprites().GetSpritesSize();

            for (int i = 0; i < Chunks.Count; i++)
            {
                loc_x = i % Map_Size * SpritesSize * Chunk.ChunkSize;
                loc_y = i / Map_Size * SpritesSize * Chunk.ChunkSize;

                ReadyToDrawImage = Chunks[i].GetImage();

                g.DrawImage(ReadyToDrawImage, DragDelta.X + loc_x, DragDelta.Y + loc_y, SpritesSize * Chunk.ChunkSize, SpritesSize * Chunk.ChunkSize);
                g.DrawRectangle(new Pen(Color.Gray , 4), DragDelta.X + loc_x - 2 , DragDelta.Y + loc_y - 2, SpritesSize * Chunk.ChunkSize + 4, SpritesSize * Chunk.ChunkSize + 4);
                //g.DrawRectangle(new Pen(Color.Red), loc_x, loc_y, SpritesSize * Chunk.ChunkSize, SpritesSize * Chunk.ChunkSize);
            }

        }
    }
}
