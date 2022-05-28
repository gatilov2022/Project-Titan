using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace game.Town
{
    internal class Buildings
    {
        private int tick_sand;
        private int tick_ore;
        private int tick_water;
        private int tick_energy;
        private SoundPlayer sound;

        public Buildings()
        {
            tick_sand = 0;tick_ore = 0;
            tick_water = 0;tick_energy = 0;
        }

        public void Tick_Add(Player.Status status)
        {
            status.Add_Resources(tick_sand, tick_water, tick_ore, tick_energy);
        }
    }
}
