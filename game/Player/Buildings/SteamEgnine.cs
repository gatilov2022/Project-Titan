using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using game.World_map.Block;

namespace game.Player.Buildings
{
    internal class SteamEngine : Building
    {
        private static string suitableBlock = typeof(Grass).ToString();

        private static Dictionary<string, Dictionary<string, int>> buildingCostsDictionary =
            new Dictionary<string, Dictionary<string, int>>()
            {
                {"Build", new Dictionary<string, int>() {{"Sand", 20}, {"Iron", 50}}},
                {"Upgrade", new Dictionary<string, int>() {{"Iron", 20}}}
            };
        public SteamEngine()
        {
            buildingType = "SteamEngine";
            buildingMaxLevel = 2;
            UsingResourcesDictionary["Water"] = 3;
            ProducingResourcesDictionary["Energy"] = 6;


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
                if (Player.GetAmountOfResources(dictValue.Key) - dictValue.Value * Math.Pow(Math.E / 2, buildingLevel) < 0) return false;
            }

            return true;
        }

        private void TakeResourcesForUpgrade()
        {
            foreach (var dictVal in buildingCostsDictionary["Upgrade"])
            {
                Player.DecreaseAmountOfResources(dictVal.Key, dictVal.Value * (buildingLevel + 1));
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

                    UsingResourcesDictionary["Water"] = (int) (UsingResourcesDictionary["Water"] * Math.E * 0.8);
                    ProducingResourcesDictionary["Energy"] = (int) (ProducingResourcesDictionary["Energy"] * Math.E);

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
