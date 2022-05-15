using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game.Player
{
    internal class Status
    {
        private int sand;
        private int water;
        private int ore;
        private int energy;

        public Status()
        {
            sand = 1000;water = 1000;
            ore = 1000;energy = 1000;
        }

        public void Add_Sand(int sand)
        {
            this.sand += sand;
        }
        public void Add_Water(int water)
        {
            this.water += water;
        }
        public void Add_Ore(int ore)
        {
            this.ore += ore;
        }
        public void Add_Energy(int energy)
        {
            this.energy += energy;
        }
    }
}
