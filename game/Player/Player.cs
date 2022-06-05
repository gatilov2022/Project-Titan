using System;
using System.Collections.Generic;
using System.Linq;


namespace game.Player
{
    [Serializable]
    public class Player
    {
        private Dictionary<string, int[]> _playerResources;
        public Player()
        {
            _playerResources = new Dictionary<string, int[]>
            {
                {"Iron",  new[]{500, 0, 1000}}, {"Sand",  new[]{400, 0, 600}}, {"Energy", new[]{400, 0, 600}}, {"Water",  new[]{300, 0, 400}}, {"ComponentsT1" ,  new[]{0, 0, 100}}, {"ComponentsT2",  new[]{0, 0, 100}}, {"ComponentsT3",  new[]{0, 0, 100}}
            };
        }
        public Dictionary<string, int[]> GetPlayerResourcesDict()
        {
            return _playerResources;
        }
        public void loadResourecesDict(Dictionary<string, int[]> loadResources)
        {
            _playerResources = loadResources;
        }

        public int GetAmountOfResources(string resource)
        {
            return _playerResources[resource][0];
        }

        public void DecreaseAmountOfResources(string resource, int amount)
        {
            _playerResources[resource][0] -= amount;
        }

        public void IncreaseAmountOfResources(string resource, int amount)
        {
            _playerResources[resource][0] += amount;
        }

        public void IncrShiftRes(string resource, int amount)
        {
            _playerResources[resource][1] += amount;
        }

        public int GetShiftRes(string resource)
        {
            return _playerResources[resource][1];
        }

        public void DecreaseShiftRes(string resource, int amount)
        {
            _playerResources[resource][1] -= amount;
        }

        public void SetResourcesShiftToZero()
        {
            foreach (var key in _playerResources.Keys.ToArray())
            {
                _playerResources[key][1] = 0;
            }
        }

        public int GetResourceCapacity(string resource)
        {
            return _playerResources[resource][2];
        }

        public void IncreaseResourceCapacity( int amount)
        {
            foreach (var key in _playerResources.Keys.ToArray())
            {
                _playerResources[key][2] += amount;
            }
        }
    }
}
