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
        static List<Chunk> Chunks = new List<Chunk>();


        
        static bool chek1 = false;
        static private Bitmap bitmap = new Bitmap(1980, 1080);
        static bool chek2 = false;
        static int Map_Size = 16;

        static public void GenerateMap()
        {
            for (int i = 0; i < Map_Size; i++)
            {
                for (int j = 0; j < Map_Size; j++)
                {
                    Chunk NewChunk = new Chunk(i, j);
                    Chunks.Add(NewChunk);
                }
            }
        }
        // Добавление всех типов в соответствующие списки
        
        static public Point GetChunk()
        {
            int loc_x = 17 % 16 * Sprites.size * Chunk.ChunkSize;
            int loc_y = 17 / 16 * Sprites.size * Chunk.ChunkSize;
            Point point = new Point(loc_x, loc_y);
            return point;
        }

        

        // Отрисовка всех объектов из всех списков
        static public void draw_map(PaintEventArgs e, Point DragDelta)
        {
            //if (!chek1)
            //{
            //    chek1 = true;
            //    Graphics g = Graphics.FromImage(bitmap);
            //    foreach (Water obj in water_list)
            //    {
            //        obj.Draw_block(g);
            //    }

            //    foreach (Sand obj in sand_list)
            //    {
            //        obj.Draw_block(g);
            //    }

            //    foreach (Grass obj in grass_list)
            //    {
            //        obj.Draw_block(g);
            //    }

            //    foreach (Ore obj in ore_list)
            //    {
            //        obj.Draw_block(g);
            //    }

            //}
            //else
            //{
            //    e.Graphics.DrawImage(bitmap, 0, 0);
            //}
            int loc_x, loc_y;

            Graphics g = e.Graphics;
            Bitmap ReadyToDrawImage;
            Graphics g2 = e.Graphics;
            Bitmap mini_map = null;

            if (!chek2)
            {
                mini_map = new Bitmap(16 * Sprites.size * Chunk.ChunkSize, 16 * Sprites.size * Chunk.ChunkSize);
                g2 = Graphics.FromImage(mini_map);
            }
            

            for (int i = 0; i < Chunks.Count; i++)
            {
                loc_x = i % 16 * Sprites.size * Chunk.ChunkSize;
                loc_y = i / 16 * Sprites.size * Chunk.ChunkSize;

                ReadyToDrawImage = Chunks[i].GetImage();

                g.DrawImage(ReadyToDrawImage, DragDelta.X + loc_x, DragDelta.Y + loc_y, Sprites.size * Chunk.ChunkSize, Sprites.size * Chunk.ChunkSize);
                if (!chek2)
                {
                    g2.DrawImage(ReadyToDrawImage, DragDelta.X + loc_x, DragDelta.Y + loc_y, Sprites.size * Chunk.ChunkSize, Sprites.size * Chunk.ChunkSize);
                }
                //g.DrawRectangle(new Pen(Color.Red), loc_x, loc_y, Sprites.size * Chunk.ChunkSize, Sprites.size * Chunk.ChunkSize);
            }
            if (!chek2)
            {
                chek2 = true;
                mini_map.Save("mini_map.png");
            }
        }
    }
}
