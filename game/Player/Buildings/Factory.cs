using System;
using System.Collections.Generic;
using game.World_map.Block;

namespace game.Player.Buildings
{
    /*!
     * \brief Класс Factory служит для производства компонентов разного уровня в замен на железо и энергию
     */
    [Serializable]
    public class Factory : Building
    {
        private static Dictionary<string, int> _buildingCostsDictionary = new Dictionary<string, int>{{"Sand", 100}, {"Iron", 50}};
        private static Dictionary<string, int> _t1Cost = new Dictionary<string, int>{{"Iron", 100}, {"ComponentsT1", 50}};
        private static Dictionary<string, int> _t2Cost = new Dictionary<string, int>{{"Iron", 200}, {"ComponentsT1", 100}, {"ComponentsT2", 50}};

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

        /*!
         * \brief Метод улучшает показатели здания.
         * \return retDictionary Новые показатели здания при улучшении.
         */
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

        /*!
         * \brief Проверка, хватает ли ресурсов для постройки.
         * \return false Если не хватает ресурсов.
         * \return true Если хватает ресурсов.
         */
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

        /*!
         * \brief Метод забирает ресурсу у игрока.
         * В замен строится здание и начинается производство компонентов.
         */
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

        /*!
         * \brief Метод для проверки возможности улучшения здания.
         * Если уровень максимальный или ресурсов не хватает, ничего не улучшится.
         */
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
                            BuildingLevel++;

                            UsingResourcesDictionary["Energy"] = (int)(UsingResourcesDictionary["Energy"] * Math.E * 0.8);
                            UsingResourcesDictionary["Iron"] = (int)(UsingResourcesDictionary["Iron"] * Math.E);
                            ProducingResourcesDictionary["ComponentsT2"] = 2;
                        }
                        break;
                    case 1:
                        if (IsResourcesEnough(_t2Cost))
                        {
                            TakeResourcesForUpgrade(_t2Cost);
                            BuildingLevel++;

                            UsingResourcesDictionary["Energy"] = (int)(UsingResourcesDictionary["Energy"] * Math.E * 0.8);
                            UsingResourcesDictionary["Iron"] = (int)(UsingResourcesDictionary["Iron"] * Math.E);
                            UsingResourcesDictionary["ComponentsT1"] = 1;
                            UsingResourcesDictionary["ComponentsT2"] = 1;
                            ProducingResourcesDictionary["ComponentsT3"] = 2;
                        }
                        break;
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
