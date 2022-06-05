using System;
using System.Collections.Generic;
using game.World_map.Block;

namespace game.Player.Buildings
{
    [Serializable]
    internal class Gamegoal : Building
    {
        private static string _suitableBlock = typeof(Grass).ToString();
        private static Dictionary<string, Dictionary<string, int>> _buildingCostsDictionary =
            new Dictionary<string, Dictionary<string, int>>
            {
                {
                    "Build", new Dictionary<string, int>
                    {
                        {
                            "Sand", 5000
                        },
                        {
                            "Iron", 4000
                        },
                        {
                            "ComponentsT1", 4000
                        },
                        {
                            "ComponentsT2", 2000
                        },
                        {
                            "ComponentsT3", 1000
                        }
                    }
                }
            };

        public Gamegoal()
        {
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

        public static string GetSuitableBlock()
        {
            return _suitableBlock;
        }
    }
}

