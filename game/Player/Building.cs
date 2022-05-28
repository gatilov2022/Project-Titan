using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using game.World_map;

namespace game.Player
{
    public class Building : Sprites
    {
        private Point buildingCoordiantes;
        Bitmap buildingImage;
        protected Type buildingType;

        protected Dictionary<string, int> usingResoursecDictionary = new Dictionary<string, int>()  {{"Energy" , 0} , 
            {"Water", 0} ,
            {"Sand",  0},
            {"Iron" , 0}};

        protected Dictionary<string, int> producingResourcesDictionary = new Dictionary<string, int>() {{"Energy", 0}, 
                {"Water", 0}, 
                {"Iron", 0}, 
                {"Sand", 0}};

        protected string[] listOfSuitableBlocks;

        protected int buildingLevel = 0, buildingMaxLevel; 

        private static List<Building> listOfBuildings = new List<Building>();

        protected bool IsMaxLevel()
        {
            return buildingLevel == buildingMaxLevel;
        }

        protected void AddBuilding(Building someBuilding)
        {
            listOfBuildings.Add(someBuilding);
        }

        public static bool Checking_The_Building(Point p, Point Drag)
        {
            var blockSize = new Sprites().GetSpritesSize();
            for (int i = 0; i < listOfBuildings.Count; i++)
            {
                var point = new Point((p.X - Drag.X) / blockSize, (p.Y - Drag.Y) / blockSize);
                if (point == listOfBuildings[i].buildingCoordiantes)
                    return false;
            }
            return true;
        }
        static void CreateBuilding(int buildingNumber)
        {
            //_buttons = new Button[] { factory_but, pump_but, drill_but, base_but, wareh_but, house_but, steam_but };

            
            switch (buildingNumber)
            {
                case 0:
                    new Factory();
                    break;
                case 1:
                    new Pump();
                    break;
                    case 2:
                        new Drill();
                    break;
                case 3:
                    //new Base();
                    break;
                case 4:
                    //new Warehouse();
                    break;
                case 5:
                    //new House();
                    break;
                case 6:
                    new SteamEngine();
                    break;

                default: break;
            }
        }

        static void UpdateResources()
        {
            bool BuildingActive = false;
            foreach (var someBuilding in listOfBuildings)
            {

                foreach (var dictItem in someBuilding.usingResoursecDictionary)
                {
                    if (Player.GetAmountOfResources(dictItem.Key) - dictItem.Value > 0)
                    {
                        Player.DecreaseAmountOfResources(dictItem.Key, dictItem.Value);
                        BuildingActive = true;
                    }
                }

                if (BuildingActive)

                foreach (var dictItem in someBuilding.producingResourcesDictionary)
                {
                    Player.IncreaseAmountOfResources(dictItem.Key, dictItem.Value);
                }
            }
        }

        public static void DrawCreatedBuildings(Graphics graphicsForm, Point Drag)
        {
           
                foreach (var someBuilding in listOfBuildings)
                {
                    var blockSize = new Sprites().GetSpritesSize();

                    int actualX = someBuilding.buildingCoordiantes.X * blockSize + Drag.X,
                        actualY = someBuilding.buildingCoordiantes.Y * blockSize + Drag.Y;

                    var rec = new Rectangle(actualX, actualY, blockSize + 1, blockSize + 1);
                    graphicsForm.DrawImage(someBuilding.buildingImage, rec);
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
                
                CreateBuilding(m);
                break;
            }

            listOfBuildings[listOfBuildings.Count - 1].buildingCoordiantes = (new Point((p.X - Drag.X) / blockSize, (p.Y - Drag.Y) / blockSize));
            listOfBuildings[listOfBuildings.Count - 1].buildingImage = bitmaps[m];
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

            buildingType = typeof(Drill);

            buildingMaxLevel = 3;
            usingResoursecDictionary["usingEnergy"] = 5;
            usingResoursecDictionary["producingIron"] = 5;
            AddBuilding(this);
        }

        public void UpgradeBuilding()
        {
            if (!IsMaxLevel())
            {
                buildingLevel++;

                usingResoursecDictionary["Energy"] = (int)(usingResoursecDictionary["Energy"] * Math.E * 0.8);
                producingResourcesDictionary["Iron"] = (int)(producingResourcesDictionary["Iron"] * Math.E);
            }
        }
    }

    class Factory : Building
    {
        public Factory()
        {
            buildingMaxLevel = 2;
            usingResoursecDictionary["Energy"] = 5;
            usingResoursecDictionary["Iron"] = 5;
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
                        usingResoursecDictionary["Energy"] =
                            (int) (usingResoursecDictionary["usingEnergy"] * Math.E * 0.8);
                        usingResoursecDictionary["Iron"] = (int) (usingResoursecDictionary["usingIron"] * Math.E);
                        break;
                    }
                    case 2:
                    {
                        usingResoursecDictionary["Energy"] =
                            (int) (usingResoursecDictionary["usingEnergy"] * Math.E * 0.8);
                        usingResoursecDictionary["Iron"] = (int) (usingResoursecDictionary["usingIron"] * Math.E);
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
            usingResoursecDictionary["Energy"] = 1;
            usingResoursecDictionary["Water"] = 5;
            AddBuilding(this);
        }

        public void UpgradeBuilding()
        {
            if (!IsMaxLevel())
            {
                usingResoursecDictionary["Energy"] = (int)(usingResoursecDictionary["Energy"] * Math.E * 0.8);
                producingResourcesDictionary["Water"] = (int)(producingResourcesDictionary["Iron"] * Math.E);
            }
        }
    }

    class SteamEngine : Building
    {
        public SteamEngine()
        {
            buildingMaxLevel = 2;
            usingResoursecDictionary["Water"] = 3;
            usingResoursecDictionary["Energy"] = 6;
            AddBuilding(this);
        }

        public void UpgradeBuilding()
        {
            if (!IsMaxLevel())
            {
                usingResoursecDictionary["Water"] = (int)(usingResoursecDictionary["Energy"] * Math.E * 0.8);
                producingResourcesDictionary["Energy"] = (int)(producingResourcesDictionary["Iron"] * Math.E);
            }
        }
    }
}