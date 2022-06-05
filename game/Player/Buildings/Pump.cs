using System;
using System.Collections.Generic;
using game.World_map.Block;

namespace game.Player
{
    [Serializable]
    internal class Pump : Building
    {
        private static string suitableBlock = typeof(Water).ToString();

        private static Dictionary<string, Dictionary<string, int>> buildingCostsDictionary =
            new Dictionary<string, Dictionary<string, int>>()
            {
                {"Build", new Dictionary<string, int>() {{"Sand", 50}, {"Iron", 50}}},
                {"Upgrade", new Dictionary<string, int>() {{"Iron", 40}}}
            };


        public Pump()
        {
            buildingType = "Pump";
            buildingMaxLevel = 2;
            UsingResourcesDictionary["Energy"] = 1;
            ProducingResourcesDictionary["Water"] = 5;

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

        public override Dictionary<string, int> AmountResourcesForUpgrade()
        {
            Dictionary<string, int> retDictionary = new Dictionary<string, int>();
            foreach (var dictValue in buildingCostsDictionary["Upgrade"])
            {
                retDictionary[dictValue.Key] = (int)(dictValue.Value * Math.Pow(Math.E / 2, buildingLevel));
            }

            return retDictionary;
        }

        private bool IsResourcesEnough(Dictionary<string, int> checkDictionary)
        {
            foreach (var dictValue in checkDictionary)
            {
                if (playerObj.GetAmountOfResources(dictValue.Key) - dictValue.Value * Math.Pow(Math.E / 2, buildingLevel) < 0) return false;
            }

            return true;
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

                    UsingResourcesDictionary["Energy"] = (int)(UsingResourcesDictionary["Energy"] * Math.E * 0.8);
                    ProducingResourcesDictionary["Water"] = (int)(ProducingResourcesDictionary["Water"] * Math.E);

                    buildingLevel++;
                }
            }

        }

        public static string GetSuitableBlock()
        {
            return suitableBlock;
        }
    }
}

