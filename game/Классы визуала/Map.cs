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

        // Отрисовка всех объектов из всех списков
        static public void Draw_map(PaintEventArgs e, Point DragDelta)
        {
            int loc_x, loc_y;
            Graphics g = e.Graphics;

            for (int i = 0; i < Chunks.Count; i++)
            {
                loc_x = i % 16 * Sprites.size * Chunk.ChunkSize;
                loc_y = i / 16 * Sprites.size * Chunk.ChunkSize;

                g.DrawImage(Chunks[i].GetImage(), DragDelta.X + loc_x, DragDelta.Y + loc_y, Sprites.size * Chunk.ChunkSize, Sprites.size * Chunk.ChunkSize);
            }
        }
    }
}
