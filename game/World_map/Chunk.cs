using System;
using System.Collections.Generic;
using System.Drawing;
using game.World_map.Block;

namespace game.World_map
{
    /*!
     * \brief Класс, хранящий в себе изображение блоков.
     * Так же хранит в себе типы блоков.
     */
    [Serializable]
    internal class Chunk
    {
        private const int ChunkSize = 16;
        private static readonly int SpritesSize = Sprites.GetSpritesSize();
        private static readonly int ImageXSize = SpritesSize * ChunkSize;
        private static readonly int ImageYSize = SpritesSize * ChunkSize;

        private readonly Bitmap _chunkImage = new Bitmap(ImageXSize, ImageYSize);
        private readonly List<object> _blocksInChunk = new List<object>();

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
                    var randNum = Rand.Next(101);
                    Point chunkPoint = new Point(coordinateX, coordinateY);

                    if (randNum <= oreChance)
                    {
                        _blocksInChunk.Add(new Ore(chunkPoint, chunkImageGraphics));
                    } 
                    else
                    {
                        overallChances += oreChance;

                        if (randNum <= overallChances + waterChance)
                        {
                            _blocksInChunk.Add(new Water(chunkPoint, chunkImageGraphics));
                        }
                        else
                        {
                            overallChances += waterChance;

                            if (randNum <= overallChances + sandChance)
                            {
                                _blocksInChunk.Add(new Sand(chunkPoint, chunkImageGraphics));
                            }
                            else
                            {
                                _blocksInChunk.Add(new Grass(chunkPoint, chunkImageGraphics));
                            }
                        }
                    }
                }
            }
            return _chunkImage;
        }
        /*!
         * \return _chunkImage Изображение одного чанка.
         */
        public Bitmap GetImage()
        {
            return _chunkImage;
        }

        /*!
         * \return ChunkSize Размер чанка.
         */
        public static int GetChunkSize()
        {
            return ChunkSize;
        }

        /*!
         * \param number Номер блока в чанке.
         * \return _blocksInChunk[number] Тип блока.
         */
        public object GetBlockByNumber(int number)
        {
            return _blocksInChunk[number];
        }
    }
}
