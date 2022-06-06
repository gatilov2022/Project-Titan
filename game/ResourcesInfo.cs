
using System.Drawing;

namespace game
{
    /*!
     * \brief Класс для вывода информации по ресурсам.
     * Выводит кол-во ресурсов, их увеличение или уменьшение.
     */
    public class ResourcesInfo
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

        /*!
         * \brief Задает пользователя при старте игры.
         * \param inPlayer Игрок, у которого берётся информация об ресурсах.
         */
        public static void SetPlayerObject(Player.Player inPlayer)
        {
            _playerObject = inPlayer;
        }

        /*!
         * \brief Вывод кол-ва ресурсов на графику формы.
         * \param formGraphics Графика формы на которой будет отображено кол-во ресурсов
         * \param resourcesInfoXCoordinate Координата Х для размещения информации.
         */
        public void DrawResourceInfo(Graphics formGraphics, int resourcesInfoXCoordinate)
        {
            formGraphics.DrawString(_playerObject.GetAmountOfResources(_resourceName).ToString(), TextFont, BrushWhite, resourcesInfoXCoordinate + _amountCoordinates.X, ResourceInfoYCoordinate + _amountCoordinates.Y);
        }

        /*!
         * \brief Вывод убытка или прироста ресурсов.
         * \param formGraphics Графика формы на которой будут отображены убыток или прирост ресурсов.
         * \param resourcesInfoXCoordinate Координата Х для размещения информации.
         */
        public void DrawResourceShift(Graphics formGraphics, int resourcesInfoXCoordinate)
        {
            formGraphics.DrawString(_playerObject.GetShiftRes(_resourceName).ToString(), TextFont, _playerObject.GetShiftRes(_resourceName) < 0 ? BrushRed : BrushGreen,
                resourcesInfoXCoordinate + _amountCoordinates.X + _shiftCoordinates.X, ResourceInfoYCoordinate+_shiftCoordinates.Y);
        }
    }
}
