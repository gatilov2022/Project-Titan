using System;
using System.Collections.Generic;
using System.Drawing;

namespace game.Классы_визуала
{
    // Класс, хранящий в себе блоки. 
    internal class Chunk
    {
        // Создаёт пустое изображение
        Bitmap chunk_image = new Bitmap(ImageXSize, ImageYSize);

        // Координаты x и y чанка
        int chunk_x, chunk_y;

        // Списки под объекты
        List<Grass> grass_list = new List<Grass>();
        List<Sand> sand_list = new List<Sand>();
        List<Water> water_list = new List<Water>();
        List<Ore> ore_list = new List<Ore>();

        

        // Задаёт размер чанка в блоках
        public static int ChunkSize = 16;

        // Задаёт размер изображения чанка
        static private int SpritesSize = new Sprites().GetSpritesSize();

        static private int ImageXSize = SpritesSize * ChunkSize; 
        static private int ImageYSize = SpritesSize * ChunkSize;

        // Генератор случайных чисел для генерации блоков в чанке
        static Random rand = new Random(); 


        public Chunk(int in_x, int in_y)
        {
            chunk_x = in_x;
            chunk_y = in_y;
            GenerateChunk();
        }

        // Генератор чанка
        Bitmap GenerateChunk()  
        {
            // Присваивает графику для рисования на изображении, присовенном данному чанку
            Graphics g = Graphics.FromImage(chunk_image);

            // Случайное число, для создания случайного блока в чанке
            int rand_num;
            int OverallChances;
            int OreChance = 6, WaterChance = 2, SandChance = 4;

            // Циклы генерации блоков рамерностью ChunkSize на ChunkSize
            for (int coordinate_y = 0; coordinate_y < ChunkSize; coordinate_y++)
            { 
                for (int  coordinate_x = 0;  coordinate_x < ChunkSize;  coordinate_x++)
                {
                    OverallChances = 0;
                    // Выбор слуачйного числа из генератора
                    rand_num = rand.Next(0, 100);

                    // Определение блока исходя из сгенерированного числа
                    // Руда - 6%
                    // Вода - 2%
                    // Песок - 4%
                    // Земля - 88%
                    
                    if (rand_num <= OreChance)
                    {
                        // Создание объекта типа руда с координатами x и y в чанке
                        Ore block = new Ore(coordinate_x, coordinate_y);

                        //Отрисовка этого блока в ранее созданной картинке
                        block.Draw_block(g);
                        

                        // Сохранение объекта
                        this.Add(block);
                    } 
                    else 
                    {
                        OverallChances += OreChance;

                        if (rand_num <= OverallChances + WaterChance)
                        {
                            Water block = new Water(coordinate_x, coordinate_y);
                            block.Draw_block(g);
                            this.Add(block);
                        }
                        else 
                        {
                            OverallChances += WaterChance;
                            if (rand_num <= OverallChances + SandChance)
                            { 
                            Sand block = new Sand(coordinate_x, coordinate_y);
                            block.Draw_block(g);
                            this.Add(block);
                            }
                            else
                            {

                                Grass block = new Grass(coordinate_x, coordinate_y);
                                block.Draw_block(g);
                                this.Add(block);
                            }
                        }
                    }
                }
            }
            return chunk_image;
        }

        public Bitmap GetImage()
        {
            return chunk_image;
        }

        public Point GetCoordinates()
        {
            return new Point(chunk_x, chunk_y);
        }


        void Add(Water obj)
        {
            water_list.Add(obj);
        }

        void Add(Sand obj)
        {
            sand_list.Add(obj);
        }

        void Add(Grass obj)
        {
            grass_list.Add(obj);
        }

        void Add(Ore obj)
        {
            ore_list.Add(obj);
        }

    }
}
