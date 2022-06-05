using System;
using System.Collections.Generic;
using System.Drawing;

namespace game.World_map.Block
{
    /*!
     * \brief Класс Grass 
     * Хранит в себе цевата блока Земли.
     */
    [Serializable]
    internal class Water : Sprites
    {
        [NonSerialized()]
        static readonly List<SolidBrush> BlueBrushList = new List<SolidBrush>() 
        {
            new SolidBrush(Color.FromArgb(255, 20, 20, 180)),
            new SolidBrush(Color.FromArgb(255, 30, 30, 180)),
            new SolidBrush(Color.FromArgb(255, 25, 25, 180))
        };
        /*!
         * \brief Класс 
         * Хранит в себе цевата блока Земли.
         */
        public Water(int inX, int inY, Graphics g)
        {
            Sprites.Draw_sprite(inX, inY, Sprites.Generate_texture(BlueBrushList), g);
        }
    }
}