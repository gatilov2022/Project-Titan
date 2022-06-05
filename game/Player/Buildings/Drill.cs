using System;
using System.Collections.Generic;
using System.Linq;
using game.World_map.Block;

namespace game.Player.Buildings
{
    [Serializable]
    internal class Drill : Building
    {
        private static string _suitableBlock = typeof(Ore).ToString();
        private static Dictionary<string, Dictionary<string, int>> _buildingCostsDictionary =
            new Dictionary<string, Dictionary<string, int>>
            {
                {
                    "Build", new Dictionary<string, int>
                    {
                        {
                            "Sand", 50
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
                            "Iron", 40
                        }
                    }
                }
            };
        public Drill()
        {
            BuildingMaxLevel = 2;
            UsingResourcesDictionary["Energy"] = 5;
            ProducingResourcesDictionary["Iron"] = 10;

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
            return _buildingCostsDictionary["Build"].All(dictValue => PlayerObject.GetAmountOfResources(dictValue.Key) - dictValue.Value >= 0);
        }

        private bool IsResourcesEnough(Dictionary<string, int> checkDictionary)
        {
            foreach (var dictValue in checkDictionary)
            {
                if (PlayerObject.GetAmountOfResources(dictValue.Key) - dictValue.Value * Math.Pow(Math.E / 2, BuildingLevel) < 0) return false;
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
                    UsingResourcesDictionary["Energy"] = (int)(UsingResourcesDictionary["Energy"] * Math.E * 0.8);
                    ProducingResourcesDictionary["Iron"] = (int)(ProducingResourcesDictionary["Iron"] * Math.E);

                    BuildingLevel++;
                }
            }
        }
        public static string GetSuitableBlock()
        {
            return _suitableBlock;
        }
    }
}
