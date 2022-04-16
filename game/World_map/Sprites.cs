﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace game.World_map
{
    public class Sprites
    {
        private static readonly Random Rand = new Random();
        private static int _size = 28; // Значение должно быть кратно корню из pixel_count.
        private static int _maxSpriteSize;
        private static int _minSpriteSize;

        protected int X, Y;
        private static readonly int PixelCount = 49; // Значение должно быть равно некоторому числу в квадрате.
        private static readonly int PixelSize = Convert.ToInt32(Math.Sqrt(PixelCount));

        public void SetSpritesMinSize(int minSize)
        {
            _minSpriteSize = minSize;
        }

        public int GetSpritesMinSize()
        {
            return _minSpriteSize;
        }

        public void SetSpritesMaxSize(int maxSize)
        {
            _maxSpriteSize = maxSize;
        }

        public int GetSpritesMaxSize()
        {
            return _maxSpriteSize;
        }


        public int GetPixelCount()
        {
            return PixelCount;
        }

        public int GetSpritesSize()
        {
            return _size;
        }

        public void IncreaseSize(int value)
        {
            if (_size + value <= _maxSpriteSize)
                _size += value;
        }

        public void DecreaseSize(int value)
        {
            if (_size - value >= _minSpriteSize)
                _size -= value;
        }

        public Point GetCoordinates()
        {
            return new Point(X, Y);
        }

        protected static void Draw_sprite(int x, int y, List<SolidBrush> texture, Graphics g) // Отрисовка
        {
            for (var i = 0; i < PixelCount; i++)
                g.FillRectangle(texture[i],
                    x * Sprites._size + i / PixelSize * Sprites._size / PixelSize,
                    y * Sprites._size + i % PixelSize * Sprites._size / PixelSize,
                    Sprites._size / PixelSize,
                    Sprites._size / PixelSize);
        }

        protected static List<SolidBrush> Generate_texture(List<SolidBrush> brush_list)
        {
            var texture = new List<SolidBrush>();
            var n = brush_list.Count - 1;

            for (var i = 0; i < PixelCount; i++)
                texture.Add(brush_list[Rand.Next(0, n)]);

            return texture;
        }
    }
}