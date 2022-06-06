using System;
using System.Collections.Generic;
using System.Drawing;

namespace game.World_map.Block
{
    /*!
     * \brief Класс Ore
     * Пресдавляет собой шаблон для создания блока типа Ore, с соответсвующими цветами.
     */
    [Serializable]
    public class Ore : Sprites
    {
        private static readonly List<SolidBrush> OreBrushList = new List<SolidBrush>() 
        { 
            new SolidBrush(Color.FromArgb(255, 128, 128, 128)),
            new SolidBrush(Color.FromArgb(255, 189, 154, 129)),
            new SolidBrush(Color.FromArgb(255, 128, 128, 128)),
            new SolidBrush(Color.FromArgb(255, 116, 116, 128)),
            new SolidBrush(Color.FromArgb(255, 142, 142, 128))
        };

        /*!
         * \param chunkPoint - Координаты X и Y в чанке. 
         * \param chunkGraphics Графика(область) на которой будет отрисован блок, по заданным координатам и подготовленным цветам блока.
         */
        public Ore(Point chunkPoint, Graphics chunkGraphics) : base(chunkPoint, OreBrushList, chunkGraphics)
        {
        }
    }
}