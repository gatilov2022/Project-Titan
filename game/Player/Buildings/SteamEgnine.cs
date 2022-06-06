using System;
using System.Collections.Generic;
using game.World_map.Block;

namespace game.Player.Buildings
{
    /*!
     * \brief Класс SteamEngine служит для переработки воды в энергию. 
     */
    [Serializable]
    public class SteamEngine : Building
    {
        private static string _suitableBlock = typeof(Grass).ToString();
        private static Dictionary<string, Dictionary<string, int>> _buildingCostsDictionary = new Dictionary<string, Dictionary<string, int>>
        {
            {"Build", new Dictionary<string, int>{{"Sand", 20}, {"Iron", 50}}},
            {"Upgrade", new Dictionary<string, int>{{"Iron", 20}}}
        };

        public SteamEngine()
        {
            BuildingMaxLevel = 2;
            UsingResourcesDictionary["Water"] = 3;
            ProducingResourcesDictionary["Energy"] = 6;

            AddBuilding(this);
        }

        /*!
         * \brief Метод забирает ресурсу у игрока.
         * В замен строится здание и начинается переработка ресурсов.
         */
        public static void TakeResourcesForBuild()
        {
            foreach (var dictVal in _buildingCostsDictionary["Build"])
            {
                PlayerObject.DecreaseAmountOfResources(dictVal.Key, dictVal.Value);
            }
        }

        /*!
         * \brief Класс SteamEngine служит для переработки воды в энергию. 
         */
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

        /*!
         * \brief Метод улучшает показатели здания.
         * \return retDictionary Новые показатели здания при улучшении.
         */
        public override Dictionary<string, int> AmountResourcesForUpgrade()
        {
            var retDictionary = new Dictionary<string, int>();
            foreach (var dictValue in _buildingCostsDictionary["Upgrade"])
            {
                retDictionary[dictValue.Key] = (int)(dictValue.Value * Math.Pow(Math.E / 2, BuildingLevel));
            }

            return retDictionary;
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

        private void TakeResourcesForUpgrade()
        {
            foreach (var dictVal in _buildingCostsDictionary["Upgrade"])
            {
                PlayerObject.DecreaseAmountOfResources(dictVal.Key, dictVal.Value * (BuildingLevel + 1));
            }
        }

        /*!
         * \brief Метод для проверки возможности улучшения здания.
         * Если уровень максимальный или ресурсов не хватает, ничего не улучшится.
         */
        public override void UpgradeBuilding()
        {
            if (!IsMaxLevel())
            {
                if (IsResourcesEnough(_buildingCostsDictionary["Upgrade"]))
                {
                    TakeResourcesForUpgrade();
                    BuildingLevel++;

                    UsingResourcesDictionary["Water"] = (int) (UsingResourcesDictionary["Water"] * Math.E * 0.8);
                    ProducingResourcesDictionary["Energy"] = (int) (ProducingResourcesDictionary["Energy"] * Math.E);
                }
            }
        }

        /*!
         * \return _suitableBlock Тип блока на котором может стоять здание.
         */
        public static string GetSuitableBlock()
        {
            return _suitableBlock;
        }
    }
}
