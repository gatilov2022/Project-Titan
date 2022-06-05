using System;
using System.Collections.Generic;
using System.Drawing;

namespace game.World_map.Block
{
    /*!
     * \brief Класс 
     * Хранит в себе цевата блока Земли.
     */
    [Serializable]
    internal class Ore : Sprites
    {
        [NonSerialized()]
        private static readonly List<SolidBrush> OreBrushList = new List<SolidBrush>() 
        { 
            new SolidBrush(Color.FromArgb(255, 128, 128, 128)),
            new SolidBrush(Color.FromArgb(255, 189, 154, 129)),
            new SolidBrush(Color.FromArgb(255, 128, 128, 128)),
            new SolidBrush(Color.FromArgb(255, 116, 116, 128)),
            new SolidBrush(Color.FromArgb(255, 142, 142, 128))
        };

        /*!
         * \brief Класс 
         * Хранит в себе цевата блока Земли.
         */
        public Ore(int inX, int inY, Graphics g) : base(inX, inY, OreBrushList, g)
        {
        }
    }
}