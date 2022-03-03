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
        
            // Списки под объекты
            static List<Grass> grass_list = new List<Grass>();
            static List<Sand> sand_list = new List<Sand>();
            static List<Water> water_list = new List<Water>();
            static List<Ore> ore_list = new List<Ore>();


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
                foreach (Water obj in water_list)
                {
                    obj.Draw_block(e);
                }

                foreach (Sand obj in sand_list)
                {
                    obj.Draw_block(e);
                }

                foreach (Grass obj in grass_list)
                {
                    obj.draw_block(e);
                }

                foreach (Ore obj in ore_list)
                {
                    obj.draw_block(e);
                }
            
        }
    }
}
