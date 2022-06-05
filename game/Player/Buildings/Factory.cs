using System;
using System.Collections.Generic;
using game.World_map.Block;

namespace game.Player.Buildings
{
    [Serializable]
    internal class Factory : Building
    {
        private static Dictionary<string, int> _buildingCostsDictionary =
            new Dictionary<string, int>
            {
                {
                    "Sand", 100
                },
                {
                    "Iron", 50
                }
            };
        
        private static Dictionary<string, int> _t1Cost = new Dictionary<string, int>
        {
            {
                "Iron", 100
            },
            {
                "ComponentsT1", 50
            }
        };
        private static Dictionary<string, int> _t2Cost = new Dictionary<string, int>
        {
            {
                "Iron", 200
            },
            {
                "ComponentsT1", 100
            },
            {
                "ComponentsT2", 50
            }
        };
        private static string _suitableBlock = typeof(Grass).ToString();
        public Factory()
        {
            BuildingMaxLevel = 2;
            UsingResourcesDictionary["Energy"] = 5;
            UsingResourcesDictionary["Iron"] = 5;
            ProducingResourcesDictionary["ComponentsT1"] = 1;

            AddBuilding(this);
        }

        private static bool IsResourcesEnough(Dictionary<string, int> checkDictionary)
        {
            foreach (var dictValue in checkDictionary)
            {
                if (PlayerObject.GetAmountOfResources(dictValue.Key) - dictValue.Value < 0)
                {
                    return false;
                }
            }
            return true;
        }

        public override Dictionary<string, int> AmountResourcesForUpgrade()
        {
            switch (BuildingLevel)
            {
                case 0:
                    return _t1Cost;
                case 1:
                    return _t2Cost;
            }
            return null;
        }

        public static bool IsResourcesEnough()
        {
            foreach (var dictValue in _buildingCostsDictionary)
            {
                if (PlayerObject.GetAmountOfResources(dictValue.Key) - dictValue.Value < 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static void TakeResourcesForBuild()
        {
            foreach (var dictVal in _buildingCostsDictionary)
            {
                PlayerObject.DecreaseAmountOfResources(dictVal.Key, dictVal.Value);
            }
        }

        private void TakeResourcesForUpgrade(Dictionary<string, int> upgradeDictionary)
        {
            foreach (var dictVal in upgradeDictionary)
            {
                PlayerObject.DecreaseAmountOfResources(dictVal.Key, dictVal.Value);
            }
        }
        public override void UpgradeBuilding()
        {
            if (!IsMaxLevel())
            {
                switch (BuildingLevel)
                {
                    case 0:
                        if (IsResourcesEnough(_t1Cost))
                        {
                            TakeResourcesForUpgrade(_t1Cost);

                            UsingResourcesDictionary["Energy"] = (int)(UsingResourcesDictionary["Energy"] * Math.E * 0.8);
                            UsingResourcesDictionary["Iron"] = (int)(UsingResourcesDictionary["Iron"] * Math.E);
                            ProducingResourcesDictionary["ComponentsT2"] = 2;

                            BuildingLevel++;
                        }
                        break;
                    case 1:
                        if (IsResourcesEnough(_t2Cost))
                        {
                            TakeResourcesForUpgrade(_t2Cost);

                            UsingResourcesDictionary["Energy"] = (int)(UsingResourcesDictionary["Energy"] * Math.E * 0.8);
                            UsingResourcesDictionary["Iron"] = (int)(UsingResourcesDictionary["Iron"] * Math.E);
                            UsingResourcesDictionary["ComponentsT1"] = 1;
                            UsingResourcesDictionary["ComponentsT2"] = 1;
                            ProducingResourcesDictionary["ComponentsT3"] = 2;

                            BuildingLevel++;
                        }
                        break;
                }
            }
        }

        public static string GetSuitableBlock()
        {
            return _suitableBlock;
        }
    }
}
