using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace game
{
     
    internal class Chunk
    {

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
        static int ImageXSize = Sprites.size * ChunkSize; 
        static int ImageYSize = Sprites.size * ChunkSize;

        // Создаёт пустое изображение
        Bitmap chunk_image = new Bitmap(ImageXSize, ImageYSize);

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
            // Присваивает графику для рисования на изображении, присовенного данному чанку
            Graphics g = Graphics.FromImage(chunk_image);

            // Случайное число, для создания случайного блока в чанке
            int rand_num;

            // Координаты x и y для блоков на этом чанке
            int coordinate_x, coordinate_y;

            // Циклы генерации блоков рамерностью ChunkSize на ChunkSize
            for (int i = 0; i < ChunkSize; i++)
            {
                for (int j = 0; j < ChunkSize; j++)
                {
                    // Переопределение координат x и y для блока
                    coordinate_x = i;
                    coordinate_y = j;

                    // Выбор слуачйного числа из генератора
                    rand_num = rand.Next(0, 100);

                    // Определение блока исходя из сгенерированного числа
                    // Руда - 6%
                    // Вода - 2%
                    // Песок - 4%
                    // Земля - 88%
                    if (rand_num <= 6)
                    {
                        // Создание объекта типа руда с координатами x и y в чанке
                        Ore block = new Ore(coordinate_x, coordinate_y);

                        //Отрисовка этого блока в ранее созданной картинке
                        block.Draw_block(g);
                        

                        // Сохранение объекта
                        this.Add(block);
                    }
                    else if (rand_num <= 8)
                    {
                        Water block = new Water(coordinate_x, coordinate_y);
                        block.Draw_block(g);
                        this.Add(block);
                    }
                    else if (rand_num <= 12)
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
            return chunk_image;
        }

        public Bitmap GetImage()
        {
            return chunk_image;
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
