using System;
using System.Collections.Generic;
using System.Drawing;

namespace game.Классы_визуала
{
    public class Sprites
    {
        private static Random rand = new Random();
        private static int Size = 28; // Значение должно быть кратно корню из pixel_count.
        static private int MaxSpriteSize;
        static private int MinSpriteSize;

        protected int x, y;
        static private int PixelCount = 49; // Значение должно быть равно некоторому числу в квадрате.
        static private int PixelSize = Convert.ToInt32(Math.Sqrt(PixelCount));

        public void SetSpritesMinSize(int MinSize)
        {
            MinSpriteSize = MinSize;
        }

        public int GetSpritesMinSize()
        {
            return MinSpriteSize;
        }

        public void SetSpritesMaxSize(int MaxSize)
        {
            MaxSpriteSize = MaxSize;
        }

        public int GetSpritesMaxSize()
        {
            return MaxSpriteSize;
        }


        public int GetPixelCount()
        {
            return PixelCount;
        }

        public int GetSpritesSize()
        {
            return Size;
        }

        public void IncrizeSize(int Value)
        {
            if (Size + Value <= MaxSpriteSize)
            {
                Size += Value;
            }
        }

        public void DecrizeSize(int Value)
        {
            if (Size - Value >= MinSpriteSize)
            {
                Size -= Value;
            }
        }

        public Point GetCoord()
        {
            return new Point(x, y);
        }
        static protected void Draw_sprite(int x, int y, List<SolidBrush> texture, Graphics g) // Отрисовка
        {
            

            for (int i = 0; i < PixelCount; i++)
            {
                g.FillRectangle(texture[i],
                    x * Sprites.Size + i / PixelSize * Sprites.Size / PixelSize,
                    y * Sprites.Size + i % PixelSize * Sprites.Size / PixelSize,
                    Sprites.Size / PixelSize,
                    Sprites.Size / PixelSize);
            }
        }

        static protected List<SolidBrush> Generate_texture(List<SolidBrush> brush_list)
        {
            List<SolidBrush> texture = new List<SolidBrush>();
            int n = brush_list.Count - 1;

            for (int i = 0; i < PixelCount; i++)
            {
                texture.Add(brush_list[rand.Next(0, n)]);
            }
            return texture;
        }
    }
}
