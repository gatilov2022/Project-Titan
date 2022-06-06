using System;
using System.Collections.Generic;
using System.Linq;
using game.World_map.Block;

namespace game.Player.Buildings
{
    /*!
     * \brief Класс Drill служит для добычи железа в замен на энергию.
     */
    [Serializable]
    public class Drill : Building
    {
        private static string _suitableBlock = typeof(Ore).ToString();
        private static Dictionary<string, Dictionary<string, int>> _buildingCostsDictionary = new Dictionary<string, Dictionary<string, int>>
        {
            {"Build", new Dictionary<string, int>{{"Sand", 50}, {"Iron", 50}}},
            {"Upgrade", new Dictionary<string, int>{{"Iron", 40}}}
        };

        public Drill()
        {
            BuildingMaxLevel = 2;
            UsingResourcesDictionary["Energy"] = 5;
            ProducingResourcesDictionary["Iron"] = 10;

            AddBuilding(this);
        }

        /*!
         * \brief Метод забирает ресурсу у игрока.
         * В замен игрок получает добычу железа.
         */
        public static void TakeResourcesForBuild()
        {
            foreach (var dictVal in _buildingCostsDictionary["Build"])
            {
                PlayerObject.DecreaseAmountOfResources(dictVal.Key, dictVal.Value);
            }
        }

        /*!
         * \brief Проверка, хватает ли ресурсов для постройки.
         * \return false Если не хватает ресурсов.
         * \return true Если хватает ресурсов.
         */
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

                    UsingResourcesDictionary["Energy"] = (int)(UsingResourcesDictionary["Energy"] * Math.E * 0.8);
                    ProducingResourcesDictionary["Iron"] = (int)(ProducingResourcesDictionary["Iron"] * Math.E);
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
