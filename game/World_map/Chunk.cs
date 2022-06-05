using System;
using System.Collections.Generic;
using System.Drawing;
using game.World_map.Block;

namespace game.World_map
{
    // Класс, хранящий в себе блоки. 
    [Serializable]
    internal class Chunk
    {
        private const int ChunkSize = 16;

        private readonly Bitmap _chunkImage = new Bitmap(ImageXSize, ImageYSize);
        private readonly List<object> _blocksInChunk = new List<object>();
        
        private static readonly int SpritesSize = Sprites.GetSpritesSize();

        private static readonly int ImageXSize = SpritesSize * ChunkSize; 
        private static readonly int ImageYSize = SpritesSize * ChunkSize;

        private static readonly Random Rand = new Random(); 

        public Chunk()
        {
            GenerateChunk();
        }
        private Bitmap GenerateChunk()  
        {
            var chunkImageGraphics = Graphics.FromImage(_chunkImage);
            const int oreChance = 6, waterChance = 2, sandChance = 4;

            for (var coordinateY = 0; coordinateY < ChunkSize; coordinateY++)
            { 
                for (var  coordinateX = 0;  coordinateX < ChunkSize;  coordinateX++)
                {
                    var overallChances = 0;
                    var randNum = Rand.Next(0, 100);
                    
                    if (randNum <= oreChance)
                    {
                        var block = new Ore(coordinateX, coordinateY);
                        block.DrawBlock(chunkImageGraphics);
                        this.Add(block);
                    } 
                    else 
                    {
                        overallChances += oreChance;
                        if (randNum <= overallChances + waterChance)
                        {
                            var block = new Water(coordinateX, coordinateY);
                            block.DrawBlock(chunkImageGraphics);
                            this.Add(block);
                        }
                        else 
                        {
                            overallChances += waterChance;
                            if (randNum <= overallChances + sandChance)
                            {
                                var block = new Sand(coordinateX, coordinateY);
                                block.DrawBlock(chunkImageGraphics);
                                this.Add(block);
                            }
                            else
                            {
                                var block = new Grass(coordinateX, coordinateY);
                                block.DrawBlock(chunkImageGraphics);
                                this.Add(block);
                            }
                        }
                    }
                }
            }
            return _chunkImage;
        }

        public Bitmap GetImage()
        {
            return _chunkImage;
        }

        public static int GetChunkSize()
        {
            return ChunkSize;
        }

        public object GetBlockByNumber(int number)
        {
            return _blocksInChunk[number];
        }
        private void Add(object inputObject)
        {
            _blocksInChunk.Add(inputObject);
        }
    }
}
