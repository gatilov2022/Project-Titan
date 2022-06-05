using System;
using System.Collections.Generic;
using System.Drawing;

namespace game.World_map
{
    /*!
     * \brief Класс Sprites хранит в себе параметры изображения.
     * Он задаёт размер блоков, зданий, кол-во пикселей в блоке.
     */
    [Serializable]
    public class Sprites
    {
        private static readonly Random Rand = new Random();
        private static int _size = 28; // Значение должно быть кратно корню из pixel_count.
        private static int _maxSpriteSize;
        private static int _minSpriteSize;

        private static readonly int PixelCount = 49; // Значение должно быть равно некоторому числу в квадрате.
        private static readonly int PixelSize = Convert.ToInt32(Math.Sqrt(PixelCount));

        /*!
         * \param minSize Минимальный размер спрайта.
         */
        public static void SetSpritesMinSize(int minSize)
        {
            _minSpriteSize = minSize;
        }

        /*!
         * \return _minSpriteSize Минимальный размер спрайта.
         */
        public static int GetSpritesMinSize()
        {
            return _minSpriteSize;
        }

        /*!
         * \param maxSize Максимальный размер спрайта.
         */
        public static void SetSpritesMaxSize(int maxSize)
        {
            _maxSpriteSize = maxSize;
        }

        /*!
         * \return _maxSpriteSize Максимальный размер спрайта.
         */
        public static int GetSpritesMaxSize()
        {
            return _maxSpriteSize;
        }

        /*!
         * \return PixelCount Кол-во пискелей в спрайте.
         */
        public static int GetPixelCount()
        {
            return PixelCount;
        }

        /*!
         * \return _size Размер спрайта
         */
        public static int GetSpritesSize()
        {
            return _size;
        }

        /*!
         * \brief Меняет размер спрайта(увеличивает).
         * Если увеличить спрайт получится, то размер спрайта увеличивается.
         */
        public static void IncreaseSize(int value)
        {
            if (_size + value <= _maxSpriteSize)
            {
                _size += value;
            }
        }

        /*!
         * \brief Меняет размер спрайта(уменьшает).
         * Если уменьшит спрайт получится, то размер спрайта увеличивается.
         */
        public static void DecreaseSize(int value)
        {
            if (_size - value >= _minSpriteSize)
            {
                _size -= value;
            }
        }

        /*!
         * \brief Создаёт блоки карты.
         * Генерирует цвета блока и отрисовывает блок на чанке.
         * \param inX Координата Х у блока
         * \param inY Координата Y у блока
         * \param brushList Массив цветов блока.
         * \param chunkGraphics Графика чанка на которой отрисовываются блоки.
         */
        protected Sprites(Point chunkPoint, List<SolidBrush> brushList, Graphics chunkGraphics)
        {
            Draw_sprite(chunkPoint, Generate_texture(brushList), chunkGraphics);
        }

        /*!
         * \brief Отрисовывет блок на карте.
         * \param x Координата Х у блока
         * \param y Координата Y у блока
         * \param texture Массив цветов каждого пикселя блока.
         * \param chunkGraphics Графика чанка на которой отрисовываются блоки.
         */
        protected static void Draw_sprite(Point chunkPoint, List<SolidBrush> texture, Graphics chunkGraphics) // Отрисовка
        {
            for (var pixel = 0; pixel < PixelCount; pixel++)
            {
                chunkGraphics.FillRectangle(texture[pixel],
                    chunkPoint.X * Sprites._size + pixel / PixelSize * Sprites._size / PixelSize,
                    chunkPoint.Y * Sprites._size + pixel % PixelSize * Sprites._size / PixelSize,
                    Sprites._size / PixelSize,
                    Sprites._size / PixelSize);
            }

            chunkGraphics.DrawRectangle(new Pen(Color.Gray),
                    chunkPoint.X * Sprites._size ,
                    chunkPoint.Y * Sprites._size ,
                    Sprites._size,
                    Sprites._size);
        }

        /*!
         * \brief Генерируемые цвета блоков.
         * \param brush_list Цвета из которых будет сгенерирован новый массив.
         * \return textureBlock Новый массив из цветов блока.
         */
        protected static List<SolidBrush> Generate_texture(List<SolidBrush> brush_list)
        {
            var textureBlock = new List<SolidBrush>();

            for (var pixel = 0; pixel < PixelCount; pixel++)
            {
                textureBlock.Add(brush_list[Rand.Next(brush_list.Count)]);
            }

            return textureBlock;
        }
    }
}
