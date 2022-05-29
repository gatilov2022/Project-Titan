using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using game.World_map.Block;

namespace game.Player.Buildings
{
    internal class Factory : Building
    {

        private static Dictionary<string, int> buildingCostsDictionary =
            new Dictionary<string, int>()
            {
                {"Sand", 100}, {"Iron", 50}

            };

        private static string suitableBlock = typeof(Grass).ToString();

        private static Dictionary<string, int> T1Cost = new Dictionary<string, int>()
            {{"Iron", 100}, {"ComponentsT1", 50}};
        private static Dictionary<string, int> T2Cost = new Dictionary<string, int>()
            {{"Iron", 200}, {"ComponentsT1", 100}, {"ComponentsT2", 50}};

        private static bool IsResourcesEnough(Dictionary<string, int> checkDictionary)
        {
            foreach (var dictValue in checkDictionary)
            {
                if (Player.GetAmountOfResources(dictValue.Key) - dictValue.Value < 0) return false;
            }

            return true;
        }
        override
        public Dictionary<string, int> AmountResourcesForUpgrade()
        {
            switch (buildingLevel)
            {
                case 0:
                    return T1Cost;
                case 1:
                    return T2Cost;
            }

            return null;
        }

        public static bool IsResourcesEnough()
        {
            foreach (var dictValue in buildingCostsDictionary)
            {
                if (Player.GetAmountOfResources(dictValue.Key) - dictValue.Value < 0) return false;
            }

            return true;
        }
        public Factory()
        {
            buildingType = "Factory";

            buildingMaxLevel = 2;
            UsingResourcesDictionary["Energy"] = 5;
            UsingResourcesDictionary["Iron"] = 5;

            ProducingResourcesDictionary["ComponentsT1"] = 1;
            AddBuilding(this);
        }

        public static void TakeResourcesForBuild()
        {
            foreach (var dictVal in buildingCostsDictionary)
            {
                Player.DecreaseAmountOfResources(dictVal.Key,dictVal.Value);
            }
        }

        private void TakeResourcesForUpgrade(Dictionary<string, int> upgradeDictionary)
        {
            foreach (var dictVal in upgradeDictionary)
            {
                Player.DecreaseAmountOfResources(dictVal.Key,dictVal.Value);
            }
        }

        
        override 
        public void UpgradeBuilding()
        {
            if (!IsMaxLevel())
            {
                switch (buildingLevel)
                {
                    case 0:
                        {
                            if (IsResourcesEnough(T1Cost))
                            {
                                TakeResourcesForUpgrade(T1Cost);
                                UsingResourcesDictionary["Energy"] = (int)(UsingResourcesDictionary["Energy"] * Math.E * 0.8);
                                UsingResourcesDictionary["Iron"] = (int)(UsingResourcesDictionary["Iron"] * Math.E);

                                ProducingResourcesDictionary["ComponentsT2"] = 2;
                                buildingLevel++;
                            }
                            break;
                        }
                    case 1:
                        {
                            if (IsResourcesEnough(T2Cost))
                            {
                                TakeResourcesForUpgrade(T2Cost);
                                UsingResourcesDictionary["Energy"] = (int)(UsingResourcesDictionary["Energy"] * Math.E * 0.8);
                                UsingResourcesDictionary["Iron"] = (int)(UsingResourcesDictionary["Iron"] * Math.E);
                                UsingResourcesDictionary["ComponentsT1"] = 1;
                                UsingResourcesDictionary["ComponentsT2"] = 1;

                                ProducingResourcesDictionary["ComponentsT3"] = 2;

                                buildingLevel++;
                            }
                            break;
                            
                        }
                    
                }
            }
        }
        public static string GetSuitableBlock()
        {
            return suitableBlock;
        }


    }
}
