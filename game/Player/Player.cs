using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using game.Player.Buildings;


namespace game.Player
{
    [Serializable]
    public class Player
    {
        private Dictionary<string, int> playerWarehouse;


        private Dictionary<string, int> playerResourcesShift;

        private Dictionary<string, int> playerResources;

        public Player()
        {
            playerResources = new Dictionary<string, int>()
            {
                {"Iron", 500}, {"Sand", 400}, {"Energy", 500}, {"Water", 300}, {"ComponentsT1" , 0}, {"ComponentsT2", 0}, {"ComponentsT3", 0}
            };

            playerResourcesShift = new Dictionary<string, int>() {
                {"Iron", 5}, {"Sand", 0}, { "Energy", 0}, { "Water", 0}, { "ComponentsT1" , 0}, { "ComponentsT2", 0}, { "ComponentsT3", 0}
            };

            playerWarehouse = new Dictionary<string, int>() {
                {"Iron", 1000}, {"Sand", 600}, { "Energy", 400}, { "Water", 400}, { "ComponentsT1" , 100}, { "ComponentsT2", 100}, { "ComponentsT3", 100}
            };
        }
        public Dictionary<string, int> GetWarehouseDict()
        {
            return playerWarehouse;
        }
        public Dictionary<string, int> GetPlayerResourcesDict()
        {
            return playerResources;
        }
        public void loadWarehouseDict(Dictionary<string, int> loadWarehouse)
        {
            playerWarehouse = loadWarehouse;
        }
        public void loadResourecesDict(Dictionary<string, int> loadResources)
        {
            playerResources = loadResources;
        }


        public int GetAmountOfResources(string resource)
        {
            return playerResources[resource];
        }

        public void DecreaseAmountOfResources(string resource, int amount)
        {
            playerResources[resource] -= amount;
        }

        public void IncreaseAmountOfResources(string resource, int amount)
        {
            playerResources[resource] += amount;
        }

        public void IncrShiftRes(string resource, int amount)
        {
            playerResourcesShift[resource] += amount;
        }

        public int GetShiftRes(string resource)
        {
            return playerResourcesShift[resource];
        }

        public void DecrShiftRes(string resource, int amount)
        {
            playerResourcesShift[resource] -= amount;
        }

        public void SetShiftToZero()
        {
            var keyList = playerResourcesShift.Keys.ToArray();
            for (int i = 0; i < playerResourcesShift.Count; i++)
            {
                playerResourcesShift[keyList[i]] = 0;
            }
        }

        public int GetResourceCapacity(string resource)
        {
            return playerWarehouse[resource];
        }

        public void IncreaseResourceCapacity( int amount)
        {
            var keyList = playerWarehouse.Keys.ToArray();
            for (int i = 0; i < keyList.Length; i++)
            {
                playerWarehouse[keyList[i]] += amount;
            }
        }
    }
}
