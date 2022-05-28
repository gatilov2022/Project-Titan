using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using game.World_map;

namespace game.Player
{
    public class Building : Sprites
    {
        private Point _buildingCoordiantes;
        private Bitmap _buildingImage;
        protected Type BuildingType;

        protected Dictionary<string, int> UsingResourcesDictionary = new Dictionary<string, int>()  {{"Energy" , 0} , 
            {"Water", 0} ,
            {"Sand",  0},
            {"Iron" , 0}};

        protected Dictionary<string, int> ProducingResourcesDictionary = new Dictionary<string, int>() {{"Energy", 0}, 
                {"Water", 0}, 
                {"Iron", 0}, 
                {"Sand", 0}};

        protected string[] listOfSuitableBlocks;

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

        public static bool Checking_The_Building(Point p, Point Drag)
        {
            var blockSize = new Sprites().GetSpritesSize();
            for (int i = 0; i < _listOfBuildings.Count; i++)
            {
                var point = new Point((p.X - Drag.X) / blockSize, (p.Y - Drag.Y) / blockSize);
                if (point == _listOfBuildings[i]._buildingCoordiantes)
                    return false;
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
                    if (Player.GetAmountOfResources("Sand") - 100 < 0
                        || Player.GetAmountOfResources("Iron") - 50 < 0) 
                        return false;

                        Player.DecreaseAmountOfResources("Sand", 100);
                        Player.DecreaseAmountOfResources("Iron", 50);
                        new Factory();
                        return true;
                    
                case 1:
                    if (Player.GetAmountOfResources("Iron") - 10 < 0)
                        return false;
                    
                    Player.DecreaseAmountOfResources("Iron", 10);

                    new Pump();
                    return true;

                case 2:
                    if (Player.GetAmountOfResources("Sand") - 50 < 0
                        || Player.GetAmountOfResources("Iron") - 50 < 0)
                        return false;

                    Player.DecreaseAmountOfResources("Sand", 50);
                    Player.DecreaseAmountOfResources("Iron", 50);

                    new Drill();
                    return true;

                case 3:
                    new GameGoal();
                    return true;
                case 4:
                    if (Player.GetAmountOfResources("Sand") - 100 < 0
                        || Player.GetAmountOfResources("Iron") - 100 < 0)
                        return false;

                    Player.DecreaseAmountOfResources("Sand", 100);
                    Player.DecreaseAmountOfResources("Iron", 100);

                    new Warehouse();
                    return true;

                case 5:
                    if (Player.GetAmountOfResources("Iron") - 50 < 0)
                        return false;
                    
                    Player.DecreaseAmountOfResources("Iron", 50);

                    new SandQuarry();

                    return true;

                case 6:
                    if (Player.GetAmountOfResources("Sand") - 20 < 0
                        || Player.GetAmountOfResources("Iron") - 50 < 0)
                        return false;

                    Player.DecreaseAmountOfResources("Sand", 20);
                    Player.DecreaseAmountOfResources("Iron", 50);

                    new SteamEngine();
                    return true;

                default: return false;
            }
        }

        public static void UpdateResources()
        {
            bool BuildingActive = false;
            foreach (var someBuilding in _listOfBuildings)
            {
                foreach (var dictItem in someBuilding.UsingResourcesDictionary)
                {
                    if (Player.GetAmountOfResources(dictItem.Key) - dictItem.Value > 0)
                    {
                        Player.DecreaseAmountOfResources(dictItem.Key, dictItem.Value);
                        BuildingActive = true;
                    }
                }

                if (BuildingActive)

                foreach (var dictItem in someBuilding.ProducingResourcesDictionary)
                {
                    Player.IncreaseAmountOfResources(dictItem.Key, dictItem.Value);
                }
            }
        }

        public static void DrawCreatedBuildings(Graphics graphicsForm, Point Drag)
        {
           
                foreach (var someBuilding in _listOfBuildings)
                {
                    var blockSize = new Sprites().GetSpritesSize();

                    int actualX = someBuilding._buildingCoordiantes.X * blockSize + Drag.X,
                        actualY = someBuilding._buildingCoordiantes.Y * blockSize + Drag.Y;

                    var rec = new Rectangle(actualX, actualY, blockSize + 1, blockSize + 1);
                    graphicsForm.DrawImage(someBuilding._buildingImage, rec);
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
            var blockSize = new Sprites().GetSpritesSize();
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
            var SpritesSize = new Sprites().GetSpritesSize();

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

    internal class Drill : Building
    {
        protected int buildingLevel, buildingMaxLevel;

        public Drill()
        {

            BuildingType = typeof(Drill);

            buildingMaxLevel = 3;
            UsingResourcesDictionary["Energy"] = 5;
            ProducingResourcesDictionary["Iron"] = 5;
            AddBuilding(this);
        }

        public void UpgradeBuilding()
        {
            if (!IsMaxLevel())
            {
                buildingLevel++;

                UsingResourcesDictionary["Energy"] = (int)(UsingResourcesDictionary["Energy"] * Math.E * 0.8);
                ProducingResourcesDictionary["Iron"] = (int)(ProducingResourcesDictionary["Iron"] * Math.E);
            }
        }
    }

    class Factory : Building
    {
        public Factory()
        {
            BuildingType = typeof(Factory);

            buildingMaxLevel = 2;
            UsingResourcesDictionary["Energy"] = 5;
            UsingResourcesDictionary["Iron"] = 5;

            AddBuilding(this);
        }

        public void UpgradeBuilding()
        {
            if (!IsMaxLevel())
            {
                switch (buildingLevel)
                {
                    case 1:
                    {
                        UsingResourcesDictionary["Energy"] =
                            (int) (UsingResourcesDictionary["Energy"] * Math.E * 0.8);
                        UsingResourcesDictionary["Iron"] = (int) (UsingResourcesDictionary["Iron"] * Math.E);
                        break;
                    }
                    case 2:
                    {
                        UsingResourcesDictionary["Energy"] =
                            (int) (UsingResourcesDictionary["Energy"] * Math.E * 0.8);
                        UsingResourcesDictionary["Iron"] = (int) (UsingResourcesDictionary["Iron"] * Math.E);
                        break;
                    }
                }
            }
        }
    }

    class Pump : Building
    {
        public Pump()
        {
            
            buildingMaxLevel = 1;
            UsingResourcesDictionary["Energy"] = 1;
            ProducingResourcesDictionary["Water"] = 5;
            AddBuilding(this);
        }

        public void UpgradeBuilding()
        {
            if (!IsMaxLevel())
            {
                UsingResourcesDictionary["Energy"] = (int)(UsingResourcesDictionary["Energy"] * Math.E * 0.8);
                ProducingResourcesDictionary["Water"] = (int)(ProducingResourcesDictionary["Water"] * Math.E);
            }
        }
    }

    class SteamEngine : Building
    {
        public SteamEngine()
        {
            BuildingType = typeof(SteamEngine);

            buildingMaxLevel = 2;
            UsingResourcesDictionary["Water"] = 3;
            ProducingResourcesDictionary["Energy"] = 6;

            AddBuilding(this);
        }

        public void UpgradeBuilding()
        {
            if (!IsMaxLevel())
            {
                UsingResourcesDictionary["Water"] = (int)(UsingResourcesDictionary["Water"] * Math.E * 0.8);
                ProducingResourcesDictionary["Energy"] = (int)(ProducingResourcesDictionary["Energy"] * Math.E);
            }
        }
    }

    class SandQuarry : Building
    {
        public SandQuarry()
        {
            BuildingType = typeof(SandQuarry);

            
            buildingMaxLevel = 1;
            UsingResourcesDictionary["Water"] = 3;
            UsingResourcesDictionary["Energy"] = 6;

            ProducingResourcesDictionary["Sand"] = 10;

            AddBuilding(this);
        }

        public void UpgradeBuilding()
        {
            if (!IsMaxLevel())
            {
                UsingResourcesDictionary["Energy"] = (int)(UsingResourcesDictionary["Energy"] * Math.E * 0.8);
                ProducingResourcesDictionary["Sand"] = (int)(ProducingResourcesDictionary["Sand"] * Math.E);
            }
        }
    }

    class Warehouse : Building
    {
        public Warehouse()
        {
            BuildingType = typeof(Warehouse);

            buildingMaxLevel = 2;

            AddBuilding(this);
        }

        public void UpgradeBuilding()
        {
            if (!IsMaxLevel())
            {

            }
        }
    }

    class GameGoal : Building
    {
        public GameGoal()
        {

        }
    }
    
}