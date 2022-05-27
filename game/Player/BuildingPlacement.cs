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

        public void Add_build(Point p, Button[] buts, Point Drag)
        {
            var blockSize = new Sprites().GetSpritesSize();

            for (var m = 0; m < buts.Length; m++)
            {
                if (buts[m].FlatAppearance.BorderColor != Color.Blue) continue;
                
                onMapCoord.Add(new Point((p.X - Drag.X) / blockSize, (p.Y - Drag.Y) / blockSize));
                tiles.Add(bitmaps[m]);
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