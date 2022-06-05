using System;
using System.Collections.Generic;
using System.Drawing;

namespace game.World_map
{
    [Serializable]
    internal class Map
    {
        private static List<Chunk> _chunks = new List<Chunk>();
        private static int _mapSize = 12;
        public static void AddChunk(Chunk chunk)
        {
            _chunks.Add(chunk);
        }

        public static void LoadChunks(List<Chunk> deserealizedChunks)
        {
            _chunks = deserealizedChunks;
        }
        public static List<Chunk> GetChunks()
        {
            return _chunks;
        }
        public static string GetBlockType(Point coordinates)
        {
            var chunkNumber = coordinates.Y / (Chunk.GetChunkSize() * Sprites.GetSpritesSize()) * Map.GetMapSize() + 
                                    coordinates.X / (Sprites.GetSpritesSize() * Chunk.GetChunkSize());
            var blockNumber = coordinates.Y / Sprites.GetSpritesSize() % Chunk.GetChunkSize() * Chunk.GetChunkSize() +
                              coordinates.X / Sprites.GetSpritesSize() % Chunk.GetChunkSize();
            return _chunks[chunkNumber].GetBlockByNumber(blockNumber).ToString();
        }
        
        public static void GenerateMap()
        {
            for (var i = 0; i < _mapSize; i++)
                for (var j = 0; j < _mapSize; j++)
                    _chunks.Add(new Chunk());
        }
        public static int GetMapSize()
        {
            return _mapSize;
        }
        // Отрисовка всех объектов из всех списков
        public static void DrawMap(Graphics graphicsForm, Point dragDelta, Size sizeForm)
        {
            var spritesSize = Sprites.GetSpritesSize();
            for (var i = 0; i < _chunks.Count; i++)
            {
                var localCoordinateX = i % _mapSize * spritesSize * Chunk.GetChunkSize();
                var localCoordinateY = i / _mapSize * spritesSize * Chunk.GetChunkSize();
                graphicsForm.DrawImage(_chunks[i].GetImage(),
                    dragDelta.X + localCoordinateX, dragDelta.Y + localCoordinateY, 
                    spritesSize * Chunk.GetChunkSize() + 1, spritesSize * Chunk.GetChunkSize() + 1);
                             
            }
        }
    }
}
