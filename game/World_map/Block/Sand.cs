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
    internal class Sand : Sprites
    {
        [NonSerialized()]
        public static List<SolidBrush> YellowBrushList = new List<SolidBrush>() 
        {
            new SolidBrush(Color.FromArgb(255, 210, 203, 149)),
            new SolidBrush(Color.FromArgb(255, 175, 168, 114)),
            new SolidBrush(Color.FromArgb(255, 220, 207, 164)),
            new SolidBrush(Color.FromArgb(255, 254, 254, 211))
        };

        /*!
         * \brief Класс 
         * Хранит в себе цевата блока Земли.
         */
        public Sand(int inX, int inY, Graphics g)
        {
            Sprites.Draw_sprite(inX, inY, Sprites.Generate_texture(YellowBrushList), g);
        }
    }
}