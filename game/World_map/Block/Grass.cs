using System;
using System.Collections.Generic;
using System.Drawing;

namespace game.World_map.Block
{
    /*!
     * \brief Класс Grass 
     * Пресдавляет собой шаблон для создания блока типа Grass, с соответсвующими цветами.
     */
    [Serializable]
    internal class Grass : Sprites
    {
        [NonSerialized()]
        private static readonly List<SolidBrush> GreenBrushList = new List<SolidBrush>() { 
            new SolidBrush(Color.ForestGreen),
            new SolidBrush(Color.Green),
            new SolidBrush(Color.DarkGreen), 
            new SolidBrush(Color.DarkOliveGreen) 
        };

        /*!
         * \param inX Координата X для блока.
         * \param inY Координата Y для блока.
         * \param chunkGraphics Графика(область) на которой будет отрисован блок, по заданным координатам и подготовленным цветам блока.
         */
        public Grass(int inX, int inY, Graphics chunkGraphics) : base (inX, inY, GreenBrushList, chunkGraphics)
        {
        }
    }
}