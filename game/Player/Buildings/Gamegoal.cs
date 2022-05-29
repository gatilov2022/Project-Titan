using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using game.World_map.Block;

namespace game.Player.Buildings
{
    internal class Gamegoal : Building
    {
        private static string suitableBlock = typeof(Grass).ToString();
        

        private static Dictionary<string, Dictionary<string, int>> buildingCostsDictionary =
            new Dictionary<string, Dictionary<string, int>>()
            {
                {"Build", new Dictionary<string, int>() {{"Sand", 5000}, {"Iron", 4000}, {"ComponentsT1", 4000}, {"ComponentsT2", 2000}, {"ComponentsT3", 1000}}}
            };
        public Gamegoal()
        {
            buildingType = "GameGoal";
            AddBuilding(this);
        }
        public static void TakeResourcesForBuild()
        {
            foreach (var dictVal in buildingCostsDictionary["Build"])
            {
                Player.DecreaseAmountOfResources(dictVal.Key, dictVal.Value);
            }
        }
        public static bool IsResourcesEnough()
        {
            foreach (var dictValue in buildingCostsDictionary["Build"])
            {
                if (Player.GetAmountOfResources(dictValue.Key) - dictValue.Value < 0) return false;
            }
            return true;
        }

        public static string GetSuitableBlock()
        {
            return suitableBlock;
        }

    }
}

