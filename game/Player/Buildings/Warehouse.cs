using System;
using System.Collections.Generic;
using game.World_map.Block;

namespace game.Player.Buildings
{
    [Serializable]
    internal class Warehouse : Building
    {
        private static string _suitableBlock = typeof(Grass).ToString();
        private static Dictionary<string, Dictionary<string, int>> _buildingCostsDictionary =
            new Dictionary<string, Dictionary<string, int>>
            {
                {
                    "Build", new Dictionary<string, int>
                    {
                        {
                            "Sand", 10
                        },
                        {
                            "Iron", 50
                        }
                    }
                },
                {
                    "Upgrade", new Dictionary<string, int>
                    {
                        {
                            "Iron", 50

                        }
                    }
                }
            };
        public Warehouse()
        {
            BuildingMaxLevel = 2;

            AddBuilding(this);
        }

        public static void TakeResourcesForBuild()
        {
            foreach (var dictVal in _buildingCostsDictionary["Build"])
            {
                PlayerObject.DecreaseAmountOfResources(dictVal.Key, dictVal.Value);
            }
        }

        public static bool IsResourcesEnough()
        {
            foreach (var dictValue in _buildingCostsDictionary["Build"])
            {
                if (PlayerObject.GetAmountOfResources(dictValue.Key) - dictValue.Value < 0)
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsResourcesEnough(Dictionary<string, int> checkDictionary)
        {
            foreach (var dictValue in checkDictionary)
            {
                if (PlayerObject.GetAmountOfResources(dictValue.Key) - dictValue.Value * Math.Pow(Math.E / 2, BuildingLevel) < 0)
                {
                    return false;
                }
            }
            return true;
        }

        public override Dictionary<string, int> AmountResourcesForUpgrade()
        {
            var retDictionary = new Dictionary<string, int>();

            foreach (var dictValue in _buildingCostsDictionary["Upgrade"])
            {
                retDictionary[dictValue.Key] = (int)(dictValue.Value * Math.Pow(Math.E / 2, BuildingLevel));
            }
            return retDictionary;
        }

        private void TakeResourcesForUpgrade()
        {
            foreach (var dictVal in _buildingCostsDictionary["Upgrade"])
            {
                PlayerObject.DecreaseAmountOfResources(dictVal.Key, dictVal.Value * (BuildingLevel + 1));
            }
        }
        
        public override void UpgradeBuilding()
        {
            if (!IsMaxLevel())
            {
                if (IsResourcesEnough(_buildingCostsDictionary["Upgrade"]))
                {
                    TakeResourcesForUpgrade();
                    BuildingLevel++;

                    PlayerObject.IncreaseResourceCapacity(300 * BuildingLevel);

                }
            }
        }

        public static string GetSuitableBlock()
        {
            return _suitableBlock;
        }
    }
}
