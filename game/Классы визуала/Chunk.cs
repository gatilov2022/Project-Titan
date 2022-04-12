using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace game.Классы_визуала
{
    // Класс, хранящий в себе блоки. 
    internal class Chunk
    {
        // Создаёт пустое изображение
        private readonly Bitmap _chunkImage = new Bitmap(ImageXSize, ImageYSize);

        // Списки под объекты
        private readonly Dictionary<string, List<object>> blocksInChunk = new Dictionary<string, List<object>>();

        //private readonly List<Grass> _grassList = new List<Grass>();
        //private readonly List<Sand> _sandList = new List<Sand>();
        //private readonly List<Water> _waterList = new List<Water>();
        //private readonly List<Ore> _oreList = new List<Ore>();

        

        // Задаёт размер чанка в блоках
        private const int ChunkSize = 16;

        // Задаёт размер изображения чанка
        private static readonly int SpritesSize = new Sprites().GetSpritesSize();

        private static readonly int ImageXSize = SpritesSize * ChunkSize; 
        private static readonly int ImageYSize = SpritesSize * ChunkSize;

        // Генератор случайных чисел для генерации блоков в чанке
        private static readonly Random Rand = new Random(); 


        public Chunk()
        {
            GenerateChunk();
        }

        // Генератор чанка
        private Bitmap GenerateChunk()  
        {
            // Присваивает графику для рисования на изображении, присовенном данному чанку
            Graphics g = Graphics.FromImage(_chunkImage);

            // Случайное число, для создания случайного блока в чанке
            const int oreChance = 6, waterChance = 2, sandChance = 4;

            // Циклы генерации блоков рамерностью ChunkSize на ChunkSize
            for (var coordinateY = 0; coordinateY < ChunkSize; coordinateY++)
            { 
                for (var  coordinateX = 0;  coordinateX < ChunkSize;  coordinateX++)
                {
                    var overallChances = 0;
                    // Выбор слуачйного числа из генератора
                    var randNum = Rand.Next(0, 100);

                    // Определение блока исходя из сгенерированного числа
                    // Руда - 6%
                    // Вода - 2%
                    // Песок - 4%
                    // Земля - 88%
                    
                    if (randNum <= oreChance)
                    {
                        // Создание объекта типа руда с координатами x и y в чанке
                        Ore block = new Ore(coordinateX, coordinateY);

                        //Отрисовка этого блока в ранее созданной картинке
                        block.Draw_block(g);
                        

                        // Сохранение объекта
                        this.Add(block);
                    } 
                    else 
                    {
                        overallChances += oreChance;

                        if (randNum <= overallChances + waterChance)
                        {
                            Water block = new Water(coordinateX, coordinateY);
                            block.Draw_block(g);
                            this.Add(block);
                        }
                        else 
                        {
                            overallChances += waterChance;
                            if (randNum <= overallChances + sandChance)
                            { 
                            Sand block = new Sand(coordinateX, coordinateY);
                            block.Draw_block(g);
                            this.Add(block);
                            }
                            else
                            {

                                Grass block = new Grass(coordinateX, coordinateY);
                                block.Draw_block(g);
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

        private void Add(Object obj)
        {
            if (!blocksInChunk.ContainsKey(obj.GetType().ToString()))
                blocksInChunk.Add(obj.GetType().ToString(), new List<object>() {obj});
            else
            {
                blocksInChunk[obj.GetType().ToString()].Add(obj);
            }
        }

        //private void Add(Sand obj)
        //{
        //    _sandList.Add(obj);
        //}

        //private void Add(Grass obj)
        //{
        //    _grassList.Add(obj);
        //}

        //private void Add(Ore obj)
        //{
        //    _oreList.Add(obj);
        //}

    }
}
