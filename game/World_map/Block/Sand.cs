using System;
using System.Collections.Generic;
using System.Drawing;

namespace game.World_map.Block
{
    /*!
     * \brief Класс Sand
     * Пресдавляет собой шаблон для создания блока типа Sand, с соответсвующими цветами.
     */
    [Serializable]
    internal class Sand : Sprites
    {
        private static readonly List<SolidBrush> YellowBrushList = new List<SolidBrush>() 
        {
            new SolidBrush(Color.FromArgb(255, 210, 203, 149)),
            new SolidBrush(Color.FromArgb(255, 175, 168, 114)),
            new SolidBrush(Color.FromArgb(255, 220, 207, 164)),
            new SolidBrush(Color.FromArgb(255, 254, 254, 211))
        };

        /*!
         * \param chunkPoint - Координаты X и Y в чанке. 
         * \param chunkGraphics Графика(область) на которой будет отрисован блок, по заданным координатам и подготовленным цветам блока.
         */
        public Sand(Point chunkPoint, Graphics chunkGraphics) : base(chunkPoint, YellowBrushList, chunkGraphics)
        {
        }
    }
}