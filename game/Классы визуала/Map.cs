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
        static List<Bitmap> chunk_images = new List<Bitmap>();

        // Списки под объекты
        static List<Grass> grass_list = new List<Grass>();
        static List<Sand> sand_list = new List<Sand>();
        static List<Water> water_list = new List<Water>();
        static List<Ore> ore_list = new List<Ore>();
        static bool chek1 = false;
        static private Bitmap bitmap = new Bitmap(1980, 1080);

        static int Map_Size = 16;

        static public void GenerateMap()
        {
            for (int i = 0; i < Map_Size;)
            {
                for (int j = 0; j < Map_Size; j++)
                {
                    Map.chunk_images.Add(ChunkGenerator.GenerateChunk(i, j));
                }
            }
        }
        // Добавление всех типов в соответствующие списки
        static public void Add(Water obj)
        {
            water_list.Add(obj);
        }

        static public void Add(Sand obj)
        {
            sand_list.Add(obj);
        }

        static public void Add(Grass obj)
        {
            grass_list.Add(obj);
        }

        static public void Add(Ore obj)
        {
            ore_list.Add(obj);
        }



        // Отрисовка всех объектов из всех списков
        static public void draw_map(PaintEventArgs e)
        {
            if (!chek1)
            {
                chek1 = true;
                Graphics g = Graphics.FromImage(bitmap);
                foreach (Water obj in water_list)
                {
                    obj.Draw_block(g);
                }

                foreach (Sand obj in sand_list)
                {
                    obj.Draw_block(g);
                }

                foreach (Grass obj in grass_list)
                {
                    obj.Draw_block(g);
                }

                foreach (Ore obj in ore_list)
                {
                    obj.Draw_block(g);
                }
                
            }
            else
            {
                e.Graphics.DrawImage(bitmap, 0, 0);
            }

        }
    }
}
