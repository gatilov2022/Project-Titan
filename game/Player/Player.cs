using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using game.Player.Buildings;


namespace game.Player
{
    internal static class Player
    {
        static Dictionary<string, int> playerWarehouse = new Dictionary<string, int>() {
            {"Iron", 1000}, {"Sand", 600}, { "Energy", 400}, { "Water", 400}, { "ComponentsT1" , 100}, { "ComponentsT2", 100}, { "ComponentsT3", 100}
        };
        

        static Dictionary<string, int> playerResourcesShift = new Dictionary<string, int>() {
            {"Iron", 5}, {"Sand", 0}, { "Energy", 0}, { "Water", 0}, { "ComponentsT1" , 0}, { "ComponentsT2", 0}, { "ComponentsT3", 0}
        }; 
        static Dictionary<string, int> playerResources = new Dictionary<string, int>()
        {
            {"Iron", 500}, {"Sand", 400}, {"Energy", 500}, {"Water", 300}, {"ComponentsT1" , 0}, {"ComponentsT2", 0}, {"ComponentsT3", 0}
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

        public static void IncrShiftRes(string resource, int amount)
        {
            playerResourcesShift[resource] += amount;
        }

        public static int GetShiftRes(string resource)
        {
            return playerResourcesShift[resource];
        }

        public static void DecrShiftRes(string resource, int amount)
        {
            playerResourcesShift[resource] -= amount;
        }

        public static void SetShiftToZero()
        {
            var keyList = playerResourcesShift.Keys.ToArray();
            for (int i = 0; i < playerResourcesShift.Count; i++)
            {
                playerResourcesShift[keyList[i]] = 0;
            }
        }
    }
}
