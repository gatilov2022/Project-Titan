using game.World_map.Block;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace game.World_map
{
    internal class Map
    {
        // Класс карта. Хранит в себе все объекты на карте, а так же отвечает за их отрисовку

        // Список чанков
        private static List<Chunk> chunks = new List<Chunk>();

        private static int mapSize = 12;

        public static void GenerateMap()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    Chunk NewChunk = new Chunk();
                    chunks.Add(NewChunk);
                }
            }
        }
        public static int GetMapSize()
        {
            return mapSize;
        }

        // Отрисовка всех объектов из всех списков
        static public void draw_map(PaintEventArgs e, Point DragDelta)
        {
            int loc_x, loc_y;

            Graphics g = e.Graphics;
            Bitmap ReadyToDrawImage;
            int SpritesSize = new Sprites().GetSpritesSize();

            for (int i = 0; i < chunks.Count; i++)
            {
                loc_x = i % mapSize * SpritesSize * Chunk.GetChunkSize();
                loc_y = i / mapSize * SpritesSize * Chunk.GetChunkSize();

                ReadyToDrawImage = chunks[i].GetImage();

                g.DrawImage(ReadyToDrawImage, DragDelta.X + loc_x, DragDelta.Y + loc_y, SpritesSize * Chunk.GetChunkSize(), SpritesSize * Chunk.GetChunkSize());
                g.DrawRectangle(new Pen(Color.Gray , 4), DragDelta.X + loc_x - 2 , DragDelta.Y + loc_y - 2, SpritesSize * Chunk.GetChunkSize() + 4, SpritesSize * Chunk.GetChunkSize() + 4);
                //g.DrawRectangle(new Pen(Color.Red), loc_x, loc_y, SpritesSize * Chunk.ChunkSize, SpritesSize * Chunk.ChunkSize);
            }

        }
    }
}
