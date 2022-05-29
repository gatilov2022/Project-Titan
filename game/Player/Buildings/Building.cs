using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using game.Player.Buildings;
using game.World_map;

namespace game.Player
{
    public class Building : Sprites
    {
        private Point _buildingCoordiantes;
        private Bitmap _buildingImage;

        protected string buildingType;

        protected Dictionary<string, int> UsingResourcesDictionary = new Dictionary<string, int>()  {{"Energy" , 0} , 
            {"Water", 0} ,
            {"Sand",  0},
            {"Iron" , 0}};

        protected Dictionary<string, int> ProducingResourcesDictionary = new Dictionary<string, int>() {{"Energy", 0}, 
                {"Water", 0}, 
                {"Iron", 0}, 
                {"Sand", 0}};

        public virtual Dictionary<string, int> AmountResourcesForUpgrade()
        { return new Dictionary<string, int>(); }

        protected int buildingLevel = 0, buildingMaxLevel; 

        private static List<Building> _listOfBuildings = new List<Building>();

        protected bool IsMaxLevel()
        {
            return buildingLevel == buildingMaxLevel;
        }

        protected void AddBuilding(Building someBuilding)
        {
            _listOfBuildings.Add(someBuilding);
        }

        public static bool HasBuildingOnTheBlock(Point p, Point Drag)
        {
            var blockSize = Sprites.GetSpritesSize();

            for (int i = 0; i < _listOfBuildings.Count; i++)
            {
                var point = new Point((p.X - Drag.X) / blockSize, (p.Y - Drag.Y) / blockSize);

                if (point == _listOfBuildings[i]._buildingCoordiantes)
                    return true;
            }
            return false;
        }

        public static object GetBuilding(Point p, Point Drag)
        {
            var blockSize = Sprites.GetSpritesSize();
            for (int i = 0; i < _listOfBuildings.Count; i++)
            {
                var point = new Point((p.X - Drag.X) / blockSize, (p.Y - Drag.Y) / blockSize);

                if (point == _listOfBuildings[i]._buildingCoordiantes)
                    return _listOfBuildings[i];
            }
            return null;
        }

        public virtual void UpgradeBuilding()
        {
        }

        public static bool Checking_The_Building(Point p, Point Drag, Button[] ButtonsList)
        {
            int buttonNum;

            for (buttonNum = 0; buttonNum < ButtonsList.Length; buttonNum++)
            {
                if (ButtonsList[buttonNum].FlatAppearance.BorderColor == Color.Blue) break;
            }


            if (HasBuildingOnTheBlock(p, Drag)) return false;
            
            var block = Map.GetBlockType(new Point(p.X - Drag.X, p.Y - Drag.Y));

            switch (buttonNum)
            {
                case 0:
                    return Factory.GetSuitableBlock() == block && Factory.IsResourcesEnough();

                case 1:
                    return Pump.GetSuitableBlock() == block && Pump.IsResourcesEnough();

                case 2:
                    return Drill.GetSuitableBlock() == block && Drill.IsResourcesEnough();


                case 3:
                    return Gamegoal.GetSuitableBlock() == block && Gamegoal.IsResourcesEnough();

                case 4:
                    return Warehouse.GetSuitableBlock() == block && Warehouse.IsResourcesEnough();


                case 5:
                    return SandQuarry.GetSuitableBlock() == block && SandQuarry.IsResourcesEnough();


                case 6:
                    return SteamEngine.GetSuitableBlock() == block && SteamEngine.IsResourcesEnough();

            }
            return true;
        }
        static bool CreateBuilding(int buildingNumber)
        {
            //_buttons = new Button[] { factory_but, pump_but, drill_but, base_but, wareh_but, house_but, steam_but };
            //_buttons = new Button[] {0factory_but ,1pump_but ,2drill_but ,3base_but//gamegoal ,4wareh_but ,5house_but ,6steam_but};

            switch (buildingNumber)
            {
                case 0:
                    if (!Factory.IsResourcesEnough()) 
                        return false;

                        Factory.TakeResourcesForBuild();
                        new Factory();
                        return true;
                    
                case 1:
                    if (!Pump.IsResourcesEnough())
                        return false;

                    Pump.TakeResourcesForBuild();

                    new Pump();

                    return true;

                case 2:
                    if (!Buildings.Drill.IsResourcesEnough())
                        return false;

                    Buildings.Drill.TakeResourcesForBuild();
                    new Drill();
                    return true;

                case 3:
                    if (!Buildings.Gamegoal.IsResourcesEnough())
                        return false;

                    Buildings.Gamegoal.TakeResourcesForBuild();
                    new Gamegoal();
                    return true;
                case 4:
                    if (!Buildings.Warehouse.IsResourcesEnough())
                        return false;

                    Buildings.Warehouse.TakeResourcesForBuild();
                    new Warehouse();
                    return true;

                case 5:
                    if (!Buildings.SandQuarry.IsResourcesEnough())
                        return false;

                    Buildings.SandQuarry.TakeResourcesForBuild();
                    new SandQuarry();
                    return true;

                case 6:
                    if (!SteamEngine.IsResourcesEnough())
                        return false;

                    SteamEngine.TakeResourcesForBuild();

                    new SteamEngine();
                    return true;

                default: return false;
            }
        }

        public static void UpdateResources()
        {
            bool BuildingActive = true;
            foreach (var someBuilding in _listOfBuildings)
            {
                foreach (var dictItem in someBuilding.UsingResourcesDictionary)
                {
                    if (Player.GetAmountOfResources(dictItem.Key) - dictItem.Value < 0)
                    {
                        BuildingActive = false;
                        break;
                    }
                }

                if (BuildingActive)
                {
                    foreach (var dictItem in someBuilding.UsingResourcesDictionary)
                    {
                            Player.DecreaseAmountOfResources(dictItem.Key, dictItem.Value);
                            Player.DecrShiftRes(dictItem.Key, dictItem.Value);
                    }

                    foreach (var dictItem in someBuilding.ProducingResourcesDictionary)
                    {
                        if(Player.GetAmountOfResources(dictItem.Key) + dictItem.Value <= Player.GetResourceCapacity(dictItem.Key))
                        {
                            Player.IncreaseAmountOfResources(dictItem.Key, dictItem.Value);
                            Player.IncrShiftRes(dictItem.Key, dictItem.Value);
                        }                    }
                }
            }
        }

        private static Font timesFont = new Font("Times New Roman", 14, FontStyle.Bold);
        public static void DrawCreatedBuildings(Graphics graphicsForm, Point Drag)
        {
           
                foreach (var someBuilding in _listOfBuildings)
                {
                    var blockSize = Sprites.GetSpritesSize();

                    int actualX = someBuilding._buildingCoordiantes.X * blockSize + Drag.X,
                        actualY = someBuilding._buildingCoordiantes.Y * blockSize + Drag.Y;

                    var rec = new Rectangle(actualX, actualY, blockSize + 1, blockSize + 1);
                    graphicsForm.DrawImage(someBuilding._buildingImage, rec);
                    graphicsForm.DrawString($"{someBuilding.buildingLevel + 1}", timesFont, new SolidBrush(someBuilding.buildingLevel == someBuilding.buildingMaxLevel ? Color.OrangeRed : Color.White), actualX + Sprites.GetSpritesSize() - 13, actualY  );
                }
            
        }

        private static Bitmap[] bitmaps = new Bitmap[] {
            Properties.Resources.Factory_1lvl, Properties.Resources.Pump_1lvl,
            Properties.Resources.Drill_Burner_1lvl, Properties.Resources.goal_of_the_game,
            Properties.Resources.Warehouse, Properties.Resources.Sand_Quarry,
            Properties.Resources.Steam_Eng_1lvl
        };

        public void PlaceBuilding(Point p, Button[] buts, Point Drag)
        {
            var blockSize = Sprites.GetSpritesSize();
            var m = 0;
            for ( ;m < buts.Length; m++)
            {
                if (buts[m].FlatAppearance.BorderColor != Color.Blue) continue;


                if (CreateBuilding(m))
                {
                    _listOfBuildings[_listOfBuildings.Count - 1]._buildingCoordiantes =
                        (new Point((p.X - Drag.X) / blockSize, (p.Y - Drag.Y) / blockSize));
                    _listOfBuildings[_listOfBuildings.Count - 1]._buildingImage = bitmaps[m];
                    break;
                }
            }

            
        }

        public static void DrawBuilding(Graphics graphicsForm, Button[] buts, Point DragDelta, int X, int Y, bool chekBuild)
        {
            var SpritesSize = Sprites.GetSpritesSize();

            var rec = new Rectangle(DragDelta.X % SpritesSize + X, DragDelta.Y % SpritesSize + Y, SpritesSize + 1, SpritesSize + 1);

            for (int m = 0; m < buts.Length; m++)
            {
                if (buts[m].FlatAppearance.BorderColor == Color.Blue)
                {
                    graphicsForm.DrawImage(bitmaps[m], rec);
                    if(!chekBuild)
                        graphicsForm.FillRectangle(new SolidBrush(Color.FromArgb(60, Color.Red)), rec);
                    else
                        graphicsForm.FillRectangle(new SolidBrush(Color.FromArgb(60, Color.Green)), rec);
                    break;
                }
            }
        }
    }
    
}