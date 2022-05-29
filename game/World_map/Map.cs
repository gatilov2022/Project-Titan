using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace game.World_map
{
    [Serializable]
    internal class Map
    {
        // Класс карта. Хранит в себе все объекты на карте, а так же отвечает за их отрисовку

        // Список чанков
        private static List<Chunk> chunks = new List<Chunk>();

        public static void AddChunk(Chunk chunk)
        {
            chunks.Add(chunk);
        }

        public static void LoadChunks(List<Chunk> deserealizedChunks)
        {
            chunks = deserealizedChunks;
        }
        public static List<Chunk> GetChunks()
        {
            return chunks;
        }
        public static string GetBlockType(Point coordinates)
        {
            var chunkNumber = (coordinates.Y) / (Chunk.GetChunkSize() * Sprites.GetSpritesSize()) * Map.GetMapSize() +
                              (coordinates.X) / (Sprites.GetSpritesSize() * Chunk.GetChunkSize());
            
            var blockNumber = (coordinates.Y) / Sprites.GetSpritesSize() % Chunk.GetChunkSize() * Chunk.GetChunkSize() +
                              (coordinates.X) / Sprites.GetSpritesSize() % Chunk.GetChunkSize();
            var a = chunks[chunkNumber].GetBlockByNumber(blockNumber);
            return a.GetType().ToString();
        }

        private static int mapSize = 12;

        public static void GenerateMap()
        {
            for (int i = 0; i < mapSize; i++)
                for (int j = 0; j < mapSize; j++)
                    chunks.Add(new Chunk());
        }
        public static int GetMapSize()
        {
            return mapSize;
        }
        // Отрисовка всех объектов из всех списков
        static public void Draw_map(Graphics graphicsForm, Point DragDelta, Size sizeForm, Player.Status _status)
        {
            int loc_x, loc_y;
            var SpritesSize = Sprites.GetSpritesSize();
            for (int i = 0; i < chunks.Count; i++)
            {
                loc_x = i % mapSize * SpritesSize * Chunk.GetChunkSize();
                loc_y = i / mapSize * SpritesSize * Chunk.GetChunkSize();
                graphicsForm.DrawImage(chunks[i].GetImage(), DragDelta.X + loc_x, DragDelta.Y + loc_y, SpritesSize * Chunk.GetChunkSize() + 1, SpritesSize * Chunk.GetChunkSize() + 1);
                //g.DrawRectangle(new Pen(Color.Gray , 4), DragDelta.X + loc_x - 2 , DragDelta.Y + loc_y - 2, SpritesSize * Chunk.GetChunkSize() + 4, SpritesSize * Chunk.GetChunkSize() + 4);                
            }
        }
    }
}
