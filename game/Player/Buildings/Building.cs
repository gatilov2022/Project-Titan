using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using game.Player.Buildings;
using game.World_map;

namespace game.Player
{
    /*!
     * \brief Класс Building даёт возможность строительства игроку.
     * Так же предоставляет возможность улучшать здания.
     */
    [Serializable]
    public class Building
    {
        private Point _buildingCoordinates;
        private Bitmap _buildingImage;
        protected static Player PlayerObject;

        private static Font _timesFont = new Font("Times New Roman", 14, FontStyle.Bold);

        protected Dictionary<string, int> UsingResourcesDictionary = new Dictionary<string, int>
        {
            {
                "Energy", 0
            },
            {
                "Water", 0
            },
            {
                "Sand", 0
            },
            {
                "Iron", 0
            }
        };

        protected Dictionary<string, int> ProducingResourcesDictionary = new Dictionary<string, int>
        {
            {
                "Energy", 0
            },
            {
                "Water", 0
            },
            {
                "Iron", 0
            },
            {
                "Sand", 0
            }
        };

        private static Dictionary<string, Bitmap> _bitmapsDictionary = new Dictionary<string, Bitmap>
        {
            {
                "factoryButton", Properties.Resources.Factory_1lvl

            },
            {
                "pumpButton", Properties.Resources.Pump_1lvl
            },
            {
                "drillButton", Properties.Resources.Drill_Burner_1lvl
            },
            {
                "gameGoalButton", Properties.Resources.goal_of_the_game
            },
            {
                "warehouseButton", Properties.Resources.Warehouse
            },
            {
                "sandQuarryButton", Properties.Resources.Sand_Quarry
            },
            {
                "steamEngineButton", Properties.Resources.Steam_Eng_1lvl
            }
        };

        protected int BuildingLevel = 0, BuildingMaxLevel;
        private static List<Building> _listOfBuildings = new List<Building>();
        
        /*!
         * \brief Виртуальный метод, возвращающий количество ресурсов, необходимое для повышения уровня обьекта класса Building
         * return Dictionary<string, int>
         */
        public virtual Dictionary<string, int> AmountResourcesForUpgrade()
        {
            return new Dictionary<string, int>();
        }

        /*!
         * \brief Устанавливает оьект класса Player для последющего взаимодейтсвия с ним
         * param inPlayerObject - Объект класса Palayer
         */
        public static void SetPlayerObj(Player inPlayerObject)
        {
            PlayerObject = inPlayerObject;
        }

        /*!
         * \brief Записывает в память обьект класса Building из сохраненного состояния игры
         * param buildings - Сохраненный обьект класса Building
         */
        public static void LoadBuildings(List<Building> buildings)
        {
            _listOfBuildings = buildings;
        }

        /*!
         * \brief Возвращает все созданные экземпляры класса Building для их последующего сохранения
         * return List<Building>
         */
        public static List<Building> GetBuildings()
        {
            return _listOfBuildings;
        }

        /*!
         * \brief Проверяет, является ли обьект класса Building максимальным уровнем
         * return bool
         */
        public bool IsMaxLevel()
        {
            return BuildingLevel == BuildingMaxLevel;
        }

        protected void AddBuilding(Building inBuilding)
        {
            _listOfBuildings.Add(inBuilding);
        }

        /*!
         * \brief Проверяет, занята ли позиция на введённых координатах обьектом класса Building
         * param mouseCoordinates - Координаты указателя мыши
         * param mapDragCoordinates - Координаты сдвига карты
         * return bool
         */
        public static bool HasBuildingOnTheBlock(Point mouseCoordinates, Point mapDragCoordinates)
        {
            var blockSize = Sprites.GetSpritesSize();

            return (from someBuilding in _listOfBuildings
                let point = new Point((mouseCoordinates.X - mapDragCoordinates.X) / blockSize,
                    (mouseCoordinates.Y - mapDragCoordinates.Y) / blockSize)
                where point == someBuilding._buildingCoordinates
                select someBuilding).Any();
        }
        /*!
         * \brief Возвращает обьект класса Building по заданным координатам или null
         * param mouseCoordinates - Координаты указателя мыши
         * param mapDragCoordinates - Координаты сдвига карты
         * return Building
         * return null
         */
        public static Building GetBuilding(Point mouseCoordinates, Point mapDragCoordinates)
        {
            var blockSize = Sprites.GetSpritesSize();

            for (var i = 0; i < _listOfBuildings.Count; i++)
            {
                var point = new Point((mouseCoordinates.X - mapDragCoordinates.X) / blockSize,
                    (mouseCoordinates.Y - mapDragCoordinates.Y) / blockSize);

                if (point == _listOfBuildings[i]._buildingCoordinates)
                {
                    return _listOfBuildings[i];
                }
            }

            return null;
        }

        /*!
         * \brief Виртуальный класс, повышающий уровень обьекта класса Building
         */
        public virtual void UpgradeBuilding()
        {
        }

        /*!
         * \brief Проверяет, соблюдены ли условия для размещения обьекта класса Building на игровой карте
         * param mouseCoordinates - Координаты указателя мыши
         * param mapDrag - Координаты сдвига карты
         * pressedButton - Текущее выбранное здание, условия раазмещения которого нужно проверить
         * return bool
         */
        public static bool BuildingIsAbleToPlace(Point mouseCoordinates, Point mapDrag, Button pressedButton)
        {
            if (HasBuildingOnTheBlock(mouseCoordinates, mapDrag))
            {
                return false;
            }

            var block = Map.GetBlockType(new Point(mouseCoordinates.X - mapDrag.X, mouseCoordinates.Y - mapDrag.Y));

            switch (pressedButton.Name)
            {
                case "factoryButton":
                    return Factory.GetSuitableBlock() == block && Factory.IsResourcesEnough();
                case "pumpButton":
                    return Pump.GetSuitableBlock() == block && Pump.IsResourcesEnough();
                case "drillButton":
                    return Drill.GetSuitableBlock() == block && Drill.IsResourcesEnough();
                case "gameGoalButton":
                    return Gamegoal.GetSuitableBlock() == block && Gamegoal.IsResourcesEnough();
                case "warehouseButton":
                    return Warehouse.GetSuitableBlock() == block && Warehouse.IsResourcesEnough();
                case "sandQuarryButton":
                    return SandQuarry.GetSuitableBlock() == block && SandQuarry.IsResourcesEnough();
                case "steamEngineButton":
                    return SteamEngine.GetSuitableBlock() == block && SteamEngine.IsResourcesEnough();
            }

            return true;
        }

        /*!
         * \brief Создаёт экземпляр одного из классов: Factory, Pump, Drill, Gamegoal, Warehouse, SandQuarry, SteamEngine
         * param pressedButton - текущее выбранное здание, которое нужно разместить
         * return bool
         */
        public static bool CreateBuilding(Button pressedButton)
        {
            switch (pressedButton.Name)
            {
                case "factoryButton":
                    if (!Factory.IsResourcesEnough())
                    {
                        return false;
                    }

                    Factory.TakeResourcesForBuild();
                    new Factory();
                    return true;

                case "pumpButton":
                    if (!Pump.IsResourcesEnough())
                    {
                        return false;
                    }

                    Pump.TakeResourcesForBuild();
                    new Pump();
                    return true;

                case "drillButton":
                    if (!Drill.IsResourcesEnough())
                    {
                        return false;
                    }

                    Drill.TakeResourcesForBuild();
                    new Drill();
                    return true;

                case "gameGoalButton":
                    if (!Gamegoal.IsResourcesEnough())
                    {
                        return false;
                    }

                    Gamegoal.TakeResourcesForBuild();
                    new Gamegoal();
                    return true;

                case "warehouseButton":
                    if (!Warehouse.IsResourcesEnough())
                    {
                        return false;
                    }

                    Warehouse.TakeResourcesForBuild();
                    new Warehouse();
                    return true;

                case "sandQuarryButton":
                    if (!SandQuarry.IsResourcesEnough())
                    {
                        return false;
                    }

                    SandQuarry.TakeResourcesForBuild();
                    new SandQuarry();
                    return true;

                case "steamEngineButton":
                    if (!SteamEngine.IsResourcesEnough())
                    {
                        return false;
                    }

                    SteamEngine.TakeResourcesForBuild();
                    new SteamEngine();
                    return true;

                default: return false;
            }
        }

        /*!
         * \brief Обновляет ресурсы игрока
         */
        public static void UpdateResources()
        {
            var buildingActive = true;

            foreach (var someBuilding in _listOfBuildings)
            {
                foreach (var dictItem in someBuilding.UsingResourcesDictionary)
                {
                    if (PlayerObject.GetAmountOfResources(dictItem.Key) - dictItem.Value < 0)
                    {
                        buildingActive = false;
                        break;
                    }
                }

                if (buildingActive)
                {
                    foreach (var dictItem in someBuilding.UsingResourcesDictionary)
                    {
                        PlayerObject.DecreaseAmountOfResources(dictItem.Key, dictItem.Value);
                        PlayerObject.DecreaseShiftRes(dictItem.Key, dictItem.Value);
                    }

                    foreach (var dictItem in someBuilding.ProducingResourcesDictionary)
                    {
                        if (PlayerObject.GetAmountOfResources(dictItem.Key) + dictItem.Value <=
                            PlayerObject.GetResourceCapacity(dictItem.Key))
                        {
                            PlayerObject.IncreaseAmountOfResources(dictItem.Key, dictItem.Value);
                            PlayerObject.IncrShiftRes(dictItem.Key, dictItem.Value);
                        }
                    }
                }
            }
        }

        /*!
         * \brief Отрисовывает все созданные здания
         * param graphicsForm - графика формы FormGame
         * param mapDrag - координаты сдвига карты 
         */
        public static void DrawCreatedBuildings(Graphics graphicsForm, Point mapDrag)
        {
            foreach (var someBuilding in _listOfBuildings)
            {
                var blockSize = Sprites.GetSpritesSize();
                int actualX = someBuilding._buildingCoordinates.X * blockSize + mapDrag.X,
                    actualY = someBuilding._buildingCoordinates.Y * blockSize + mapDrag.Y;
                var rec = new Rectangle(actualX, actualY, blockSize + 1, blockSize + 1);

                graphicsForm.DrawImage(someBuilding._buildingImage, rec);
                graphicsForm.DrawString($"{someBuilding.BuildingLevel + 1}", _timesFont,
                    new SolidBrush(someBuilding.BuildingLevel == someBuilding.BuildingMaxLevel
                        ? Color.OrangeRed
                        : Color.White),
                    actualX + Sprites.GetSpritesSize() - 13, actualY);
            }
        }

        /*!
         * \brief Размещает здание на игровой карте
         * param mouseCoordinates - Координаты указателя мыши
         * param pressedButton - Выбранное здание, которое нужно разместить
         * param dragCoordinates - Координаты сдвига карты
         */
        public void PlaceBuilding(Point mouseCoordinates, Button pressedButton, Point dragCoordinates)
        {
            var blockSize = Sprites.GetSpritesSize();

            if (CreateBuilding(pressedButton))
            {
                _listOfBuildings[_listOfBuildings.Count - 1]._buildingCoordinates = new Point(
                    (mouseCoordinates.X - dragCoordinates.X) / blockSize,
                    (mouseCoordinates.Y - dragCoordinates.Y) / blockSize);
                _listOfBuildings[_listOfBuildings.Count - 1]._buildingImage = _bitmapsDictionary[pressedButton.Name];
            }
        }

        /*!
         * \brief Рисует полупрозрачное здание на координатах указателя мыши в соответсвии с соблюдением условий размещения некоторого здания
         * param graphicsForm - Графика форы FormGame
         * param pressedButton - Текущее выбранное здание, которое нужно отрисовать
         * param dragCoordinates - Координаты сдвига карты
         * param mouseCoordinates - Координаты указателя мыши
         * param buildingPlaceable - Соблюдены ли условия размещения выбранного здания
         */
        public static void DrawPrebuildingImage(Graphics graphicsForm, Button pressedButton, Point dragCoordinates,
            Point mouseCoordinates, bool buildingPlaceable)
        {
            var spritesSize = Sprites.GetSpritesSize();
            var rec = new Rectangle(dragCoordinates.X % spritesSize + mouseCoordinates.X,
                dragCoordinates.Y % spritesSize + mouseCoordinates.Y, spritesSize + 1, spritesSize + 1);

            graphicsForm.DrawImage(_bitmapsDictionary[pressedButton.Name], rec);
            if (!buildingPlaceable)
                graphicsForm.FillRectangle(new SolidBrush(Color.FromArgb(60, Color.Red)), rec);
            else
                graphicsForm.FillRectangle(new SolidBrush(Color.FromArgb(60, Color.Green)), rec);
        }

    }
}