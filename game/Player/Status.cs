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

        public void Add_Resources(int sand, int water, int ore, int energy)
        {
            this.sand += sand;
            this.water += water;
            this.ore += ore;
            this.energy += energy;
        }
        
        public void Delete_resources(int sand, int water, int ore, int energy)
        {
            this.sand -= sand;
            this.water -= water;
            this.ore -= ore;
            this.energy -= energy;
        }

        public bool Are_There_Resources()
        {
            if (this.water < 100 || this.ore < 100 || this.energy < 100 || this.sand < 100)
                return false;
            return true;
        }

        public int Get_Sand()
        {
            return sand;
        }
        public int Get_Water()
        {
            return water;
        }
        public int Get_Ore()
        {
            return ore;
        }
        public int Get_Energy()
        {
            return energy;
        }
    }
}
