using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace game.Player
{
    internal class Player
    {
        protected Dictionary<string, int> playerResources = new Dictionary<string, int>()
        {
            {"IronOre", 0}, {"Iron", 0}, {"Sand", 0}, {"Glass", 0}, {"Energy", 0}, {"Steam", 0}
        };

        public int GetAmountOfResources(string resource)
        {
            return playerResources[resource];
            //return GetResource()
        }

        public void DecreaseAmountOfResources(string resource, int amount)
        {
            playerResources[resource] -= amount;
        }

        public void IncreaseAmountOfResources(string resource, int amount)
        {
            playerResources[resource] += amount;
        }
    }
}
