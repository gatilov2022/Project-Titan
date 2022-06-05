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
         * Создаёт цветовую 
         */
        public Grass(int inX, int inY, Graphics g)
        {
            Sprites.Draw_sprite(inX, inY, Sprites.Generate_texture(GreenBrushList), g);
        }
    }
}