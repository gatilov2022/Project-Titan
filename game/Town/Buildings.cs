using System;
using System.Drawing;
using System.Windows.Forms;

namespace game.Town
{
    internal class Buildings
    {
        private int tick_sand;
        private int tick_ore;
        private int tick_water;
        private int tick_energy;

        public Buildings()
        {
            tick_sand = 0;tick_ore = 0;
            tick_water = 0;tick_energy = 0;
        }

        public void Tick_Add(Player.Status status)
        {
            status.Add_Sand(tick_sand);
            status.Add_Ore(tick_ore);
            status.Add_Water(tick_water);
            status.Add_Energy(tick_energy);
        }
        public void Add_Resources(Button[] but)
        {
            for (int i = 0; i < but.Length; i++)
            {
                if(but[i].FlatAppearance.BorderColor == Color.Blue)
                {
                    if (i == 0)
                        tick_ore++;
                    else if (i == 1)
                        tick_water++;
                    else if(i == 2)
                        tick_sand++;
                    else if(i == 6)
                        tick_energy++;
                }
            }
        }
    }
}
