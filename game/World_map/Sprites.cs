using System;
using System.Collections.Generic;
using System.Drawing;

namespace game.World_map
{
    [Serializable]
    public class Sprites
    {
        private static readonly Random Rand = new Random();
        private static int _size = 28; // Значение должно быть кратно корню из pixel_count.
        private static int _maxSpriteSize;
        private static int _minSpriteSize;

        private static readonly int PixelCount = 49; // Значение должно быть равно некоторому числу в квадрате.
        private static readonly int PixelSize = Convert.ToInt32(Math.Sqrt(PixelCount));

        public static void SetSpritesMinSize(int minSize)
        {
            _minSpriteSize = minSize;
        }

        public static int GetSpritesMinSize()
        {
            return _minSpriteSize;
        }

        public static void SetSpritesMaxSize(int maxSize)
        {
            _maxSpriteSize = maxSize;
        }

        public static int GetSpritesMaxSize()
        {
            return _maxSpriteSize;
        }

        public static int GetPixelCount()
        {
            return PixelCount;
        }

        public static int GetSpritesSize()
        {
            return _size;
        }

        public static void IncreaseSize(int value)
        {
            if (_size + value <= _maxSpriteSize)
                _size += value;
        }

        public static void DecreaseSize(int value)
        {
            if (_size - value >= _minSpriteSize)
                _size -= value;
        }
        protected Sprites(int inX, int inY, List<SolidBrush> brushList, Graphics chunkGraphics)
        {
            Draw_sprite(inX, inY, Generate_texture(brushList), chunkGraphics);
        }
        protected static void Draw_sprite(int x, int y, List<SolidBrush> texture, Graphics g) // Отрисовка
        {
            for (var i = 0; i < PixelCount; i++)
                g.FillRectangle(texture[i],
                    x * Sprites._size + i / PixelSize * Sprites._size / PixelSize,
                    y * Sprites._size + i % PixelSize * Sprites._size / PixelSize,
                    Sprites._size / PixelSize,
                    Sprites._size / PixelSize);
            g.DrawRectangle(new Pen(new SolidBrush(Color.Gray)),new Rectangle(
                    x * Sprites._size ,
                    y * Sprites._size ,
                    Sprites._size,
                    Sprites._size));
        }

        protected static List<SolidBrush> Generate_texture(List<SolidBrush> brush_list)
        {
            var texture = new List<SolidBrush>();

            for (var i = 0; i < PixelCount; i++)
                texture.Add(brush_list[Rand.Next(brush_list.Count)]);

            return texture;
        }
    }
}
