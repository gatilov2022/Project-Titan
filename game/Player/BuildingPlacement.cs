using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using game.World_map;


namespace game.Player
{
    internal class Map_Build
    {
        private readonly Bitmap[] bitmaps = new Bitmap[] {
            Properties.Resources.Factory_1lvl, Properties.Resources.Pump_1lvl,
            Properties.Resources.Drill_Burner_1lvl, Properties.Resources.Base,
            Properties.Resources.Warehouse, Properties.Resources.Home_Defult,
            Properties.Resources.Steam_Eng_1lvl
        };

        private readonly List<Bitmap> tiles = new List<Bitmap>();
        private readonly List<Point> onMapCoord = new List<Point>();

        public bool Checking_The_Building(Point p, Point Drag)
        {
            var blockSize = new Sprites().GetSpritesSize();
            for (int i = 0;i < tiles.Count; i++)
            {
                var point = new Point((p.X - Drag.X) / blockSize, (p.Y - Drag.Y) / blockSize);
                if (point == onMapCoord[i])
                    return false;
            }
            return true;
        }

        public void Add_build(Point p, Button[] buts, Point Drag, Status status)
        {
            for (var m = 0; m < buts.Length; m++)
            {
                if (buts[m].FlatAppearance.BorderColor != Color.Blue) continue;

                var blockSize = new Sprites().GetSpritesSize();
                onMapCoord.Add(new Point((p.X - Drag.X) / blockSize, (p.Y - Drag.Y) / blockSize));
                tiles.Add(bitmaps[m]);
                status.Delete_resources(100, 100, 100, 100);

                //Код, если будут по разному стоимость

                //switch (m)
                //{
                //    case 0:
                //        status.Delete_resources(100, 100, 100, 100);
                //        break;
                //    case 1:
                //        status.Delete_resources(100, 100, 100, 100);
                //        break;
                //    case 2:
                //        status.Delete_resources(100, 100, 100, 100);
                //        break;
                //    case 6:
                //        status.Delete_resources(100, 100, 100, 100);
                //        break;
                //}
            }
        }
        public void Grah_build(Graphics graphicsForm, Point Drag)
        {
            var blockSize = new Sprites().GetSpritesSize(); 

            for (var i = 0; i < tiles.Count; i++)
            {
                int actualX = onMapCoord[i].X * blockSize + Drag.X, actualY = onMapCoord[i].Y * blockSize + Drag.Y;
                var rec = new Rectangle(actualX, actualY, blockSize + 1, blockSize + 1);
                graphicsForm.DrawImage(tiles[i], rec);
            }
        }
    }
}