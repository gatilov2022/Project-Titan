
using System.Drawing;

namespace game
{
    internal class ResourcesInfo
    {
        private static Player.Player _playerObject;
        private readonly string _resourceName;
        private Point _amountCoordinates;
        private Point _shiftCoordinates;

        private static readonly Brush BrushWhite = Brushes.White;
        private static readonly Brush BrushRed = Brushes.Red;
        private static readonly  Brush BrushGreen = Brushes.Green;

        private static readonly Font TextFont = new Font("Arial", 11, FontStyle.Bold);

        private const int ResourceInfoYCoordinate = 4;
        public ResourcesInfo(string resourceName, Point inAmountCoordinates, Point inShiftCoordinates)
        {
            _resourceName = resourceName;
            _amountCoordinates = inAmountCoordinates;
            _shiftCoordinates = inShiftCoordinates;
        }

        public static void SetPlayerObject(Player.Player inPlayer)
        {
            _playerObject = inPlayer;
        }
        public void DrawResourceInfo(Graphics formGraphics, int resourcesInfoXCoordinate)
        {
            formGraphics.DrawString(_playerObject.GetAmountOfResources(_resourceName).ToString(), TextFont, BrushWhite, resourcesInfoXCoordinate + _amountCoordinates.X, ResourceInfoYCoordinate + _amountCoordinates.Y);
        }

        public void DrawResourceShift(Graphics formGraphics, int resourcesInfoXCoordinate)
        {
            formGraphics.DrawString(_playerObject.GetShiftRes(_resourceName).ToString(), TextFont, _playerObject.GetShiftRes(_resourceName) < 0 ? BrushRed : BrushGreen,
                resourcesInfoXCoordinate + _amountCoordinates.X + _shiftCoordinates.X, ResourceInfoYCoordinate+_shiftCoordinates.Y);
        }
    }
}
