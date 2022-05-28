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
        public void Add_Resources_Tick(Button[] but)
        {
            for (int i = 0; i < but.Length; i++)
            {
                if (but[i].FlatAppearance.BorderColor == Color.Blue)
                {
                    var random = new Random();
                    if (random.Next(2) == 0)
                        sound = new SoundPlayer(Properties.Resources.build);
                    else
                        sound = new SoundPlayer(Properties.Resources.build_hummer);
                    sound.Play();
                    if (i == 0)
                        tick_ore += 5;
                    else if (i == 1)
                        tick_water += 5;
                    else if (i == 2)
                        tick_sand += 5;
                    else if (i == 6)
                        tick_energy += 5;
                }
            }
        }
    }
}
