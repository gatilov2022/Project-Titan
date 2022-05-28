using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace game.Player
{
    internal static class Player
    {
        static Dictionary<string, int> playerResources = new Dictionary<string, int>()
        {
            {"Iron", 500}, {"Sand", 400}, {"Energy", 500}, {"Water", 300}
        };

        public static int GetAmountOfResources(string resource)
        {
            return playerResources[resource];
        }

        public static void DecreaseAmountOfResources(string resource, int amount)
        {
            playerResources[resource] -= amount;
        }

        public static void IncreaseAmountOfResources(string resource, int amount)
        {
            playerResources[resource] += amount;
        }
    }
}
