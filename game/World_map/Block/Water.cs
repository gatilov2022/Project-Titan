using System;
using System.Collections.Generic;
using System.Drawing;

namespace game.World_map.Block
{
    /*!
     * \brief Класс Water
     * Пресдавляет собой шаблон для создания блока типа Water, с соответсвующими цветами.
     */
    [Serializable]
    public class Water : Sprites
    {
        private static readonly List<SolidBrush> BlueBrushList = new List<SolidBrush>() 
        {
            new SolidBrush(Color.FromArgb(255, 20, 20, 180)),
            new SolidBrush(Color.FromArgb(255, 30, 30, 180)),
            new SolidBrush(Color.FromArgb(255, 25, 25, 180))
        };

        /*!
         * \param inX Координата X для блока.
         * \param inY Координата Y для блока.
         * \param chunkGraphics Графика(область) на которой будет отрисован блок, по заданным координатам и подготовленным цветам блока.
         */
        public Water(Point chunkPoint, Graphics chunkGraphics) : base(chunkPoint, BlueBrushList, chunkGraphics)
        {
        }
    }
}