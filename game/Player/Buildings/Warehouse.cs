using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using game.World_map.Block;

namespace game.Player.Buildings
{
    [Serializable]
    internal class Warehouse : Building
    {

        private static string suitableBlock = typeof(Grass).ToString();


        private static Dictionary<string, Dictionary<string, int>> buildingCostsDictionary =
            new Dictionary<string, Dictionary<string, int>>()
            {
                {"Build", new Dictionary<string, int>() {{"Sand", 10}, {"Iron", 50}}},
                {"Upgrade", new Dictionary<string, int>() {{"Iron", 50}}}
            };
        public Warehouse()
        {
            buildingType = "Warehouse";
            buildingMaxLevel = 2;

            AddBuilding(this);
        }
        public static void TakeResourcesForBuild()
        {
            foreach (var dictVal in buildingCostsDictionary["Build"])
            {
                playerObj.DecreaseAmountOfResources(dictVal.Key, dictVal.Value);
            }
        }
        public static bool IsResourcesEnough()
        {
            foreach (var dictValue in buildingCostsDictionary["Build"])
            {
                if (playerObj.GetAmountOfResources(dictValue.Key) - dictValue.Value < 0) return false;
            }
            return true;
        }
        private bool IsResourcesEnough(Dictionary<string, int> checkDictionary)
        {
            foreach (var dictValue in checkDictionary)
            {
                if (playerObj.GetAmountOfResources(dictValue.Key) - dictValue.Value * Math.Pow(Math.E / 2, buildingLevel) < 0) return false;
            }

            return true;
        }

        public override Dictionary<string, int> AmountResourcesForUpgrade()
        {
            Dictionary<string, int> retDictionary = new Dictionary<string, int>();
            foreach (var dictValue in buildingCostsDictionary["Upgrade"])
            {
                retDictionary[dictValue.Key] = (int)(dictValue.Value * Math.Pow(Math.E / 2, buildingLevel));
            }
            return retDictionary;
        }

        private void TakeResourcesForUpgrade()
        {
            foreach (var dictVal in buildingCostsDictionary["Upgrade"])
            {
                playerObj.DecreaseAmountOfResources(dictVal.Key, dictVal.Value * (buildingLevel + 1));
            }
        }
        override 
        public void UpgradeBuilding()
        {
            if (!IsMaxLevel())
            {
                if (IsResourcesEnough(buildingCostsDictionary["Upgrade"]))
                {
                    TakeResourcesForUpgrade();
                    buildingLevel++;

                    playerObj.IncreaseResourceCapacity(300 * buildingLevel);


                }

            }

        }

        public static string GetSuitableBlock()
        {
            return suitableBlock;
        }
    }
}
