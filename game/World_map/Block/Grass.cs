﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace game.World_map.Block
{
    /*!
     * \brief Класс Grass 
     * Пресдавляет собой шаблон для создания блока типа Grass, с соответсвующими цветами.
     */
    [Serializable]
    public class Grass : Sprites
    {
        private static readonly List<SolidBrush> GreenBrushList = new List<SolidBrush>() 
        { 
            new SolidBrush(Color.ForestGreen),
            new SolidBrush(Color.Green),
            new SolidBrush(Color.DarkGreen), 
            new SolidBrush(Color.DarkOliveGreen) 
        };

        /*!
         * \param chunkPoint - Координаты X и Y в чанке. 
         * \param chunkGraphics Графика(область) на которой будет отрисован блок, по заданным координатам и подготовленным цветам блока.
         */
        public Grass(Point chunkPoint, Graphics chunkGraphics) : base(chunkPoint, GreenBrushList, chunkGraphics)
        {
        }
    }
}