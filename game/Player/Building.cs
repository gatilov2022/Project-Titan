using System.Drawing;
using System.Windows.Forms;
using game.World_map;

namespace game.Player
{
    public class Building : Sprites
    {
        static private Bitmap[] bitmaps = new Bitmap[] {
            Properties.Resources.Factory_1lvl, Properties.Resources.Pump_1lvl,
            Properties.Resources.Drill_Burner_1lvl, Properties.Resources.Base,
            Properties.Resources.Warehouse, Properties.Resources.Home_Defult,
            Properties.Resources.Steam_Eng_1lvl
        };
        static public void Draw_building(Graphics graphicsForm, Button[] buts, Point DragDelta, int X, int Y, bool checkBuild)
        {
            var SpritesSize = new Sprites().GetSpritesSize();

            var rec = new Rectangle(DragDelta.X % SpritesSize + X, DragDelta.Y % SpritesSize + Y, SpritesSize + 1, SpritesSize + 1);

            for (int m = 0; m < buts.Length; m++)
            {
                if (buts[m].FlatAppearance.BorderColor == Color.Blue)
                {
                    graphicsForm.DrawImage(bitmaps[m], rec);
                    if (checkBuild)
                        graphicsForm.FillRectangle(new SolidBrush(Color.FromArgb(60, Color.Green)), rec);
                    else
                        graphicsForm.FillRectangle(new SolidBrush(Color.FromArgb(60, Color.Red)), rec);
                    break;
                }
            }
        }
    }
}