using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using game.Player;
using game.World_map;

namespace game
{
    public partial class FormGame : Form
    {
        private readonly StartMenu _startMenu;
        private readonly Player.Player _playerObject;

        private Button _pressedButton;
        //private readonly Button[] _buttons;
        private Point _dragStartCoordinates, _dragDistancePoint = new Point(0,0);

        private bool _dragging, _scrollingDown, _scrollingUp;
        private int _mouseX, _mouseY, _lastX, _lastY, _spritesSize, _scrollToX, _scrollToY;

        private const int SpriteSizeChangeOnScroll = 7;
        private const double MaxMultiplier = 6, MinMultiplier = 0.25;

        private readonly ResourcesInfo[] _resourcesInfoList =
        {
            new ResourcesInfo("Water", new Point(90, 24), new Point(60, 24)),
            new ResourcesInfo("Iron", new Point(90, 0),new Point(60, 0)),
            new ResourcesInfo("Sand", new Point(215, 24), new Point(60, 24)),
            new ResourcesInfo("Energy", new Point(215, 0), new Point(60, 0)),
            new ResourcesInfo("ComponentsT1", new Point(328, 0), new Point(30, 0)),
            new ResourcesInfo("ComponentsT2", new Point(328, 14), new Point(30, 14)),
            new ResourcesInfo("ComponentsT3", new Point(328, 28), new Point(30, 28))
        };

        public FormGame(StartMenu startMenu, Player.Player loadingPlayer = null)
        {
            InitializeComponent();

            _playerObject = loadingPlayer ?? new Player.Player();
            _startMenu = startMenu;
            _spritesSize = Sprites.GetSpritesSize();

            MouseWheel += GameWindowMouseWheel;

            Building.SetPlayerObj(_playerObject);
            ResourcesInfo.SetPlayerObject(_playerObject);
            timer1.Start();
            Sprites.SetSpritesMinSize((int)(Convert.ToInt32(Math.Sqrt(Sprites.GetPixelCount())) * MinMultiplier * 2));
            Sprites.SetSpritesMaxSize((int)(Convert.ToInt32(Math.Sqrt(Sprites.GetPixelCount())) * MaxMultiplier * 2));
        }

        private void GameWindowResized(object sender, EventArgs e)
        {
            ChangeMapZoom();
        }

        private void GameLogicTimerTick(object sender, EventArgs e)
        {
            _playerObject.SetResourcesShiftToZero();
            Building.UpdateResources();
            Invalidate();
        }

        private void GameWindowClosed(object sender, FormClosedEventArgs e)
        {
            _startMenu.Show();
        }

        private void GameWindowDoubleClick(object sender, EventArgs e)
        {
            if (Building.HasBuildingOnTheBlock(new Point(_mouseX, _mouseY), _dragDistancePoint) && !Building.GetBuilding(new Point(_mouseX,_mouseY), _dragDistancePoint).IsMaxLevel())
            {
                var someBuilding= Building.GetBuilding(new Point(_mouseX, _mouseY), _dragDistancePoint) as Building;
                var costString = "";

                foreach (var dictPare in someBuilding.AmountResourcesForUpgrade())
                {
                    costString += $"\n{dictPare.Key} - {dictPare.Value}";
                }
                costString = costString.Replace("Iron", "Железо")
                    .Replace("Sand", "Песок")
                    .Replace("ComponentsT1", "Компоненты 1-го уровня")
                    .Replace("ComponentsT2", "Компоненты 2-го уровня")
                    .Replace("ComponentsT3", "Компоненты 3-го уровня");

                if (MessageBox.Show(@"Улучшить здание? Стоимость улучшения:" + costString, @"BuildingUpgrade", 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
                    someBuilding.UpgradeBuilding();
            }
        }

        private void GameWindowMouseWheel(object sender, MouseEventArgs e)
        {
            _scrollToX = e.X;
            _scrollToY = e.Y;
            _spritesSize = Sprites.GetSpritesSize();

            if (e.Delta < 0 && _spritesSize - SpriteSizeChangeOnScroll >= Sprites.GetSpritesMinSize())
            {
                _scrollingDown = true;
            } 
            else if (e.Delta > 0 && _spritesSize + SpriteSizeChangeOnScroll <= Sprites.GetSpritesMaxSize())
            {
                _scrollingUp = true;
            }

            ChangeMapZoom();
            Invalidate();
        }

        public static void SaveObjects<T>(string filePath, T objectToWrite, bool append = false)
        {
            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }
        private void SaveGameButtonClick(object sender, EventArgs e)
        {
            var mapObjects = Map.GetChunks();
            var buildObjects = Building.GetBuildings();
            var date = $"{DateTime.Now.ToString().Replace(" ", "_").Replace(":", ".")}";
            var path = Environment.CurrentDirectory + "\\saves"; 

            Directory.CreateDirectory($"{path}\\{date}");
            SaveObjects($"{path}\\{date}\\Player.sav", _playerObject);

            if (buildObjects.Count > 0)
            {
                SaveObjects($"{path}\\{date}\\Buildings.sav", buildObjects[0]);
            }
            for (var index = 1; index < buildObjects.Count; index++)
            {
                SaveObjects($"{path}\\{date}\\Buildings.sav", buildObjects[index], true);
            }
            if (mapObjects.Count > 0)
            {
                SaveObjects($"{path}\\{date}\\Chunks.sav", mapObjects[0]);
            }
            for (var index = 1; index < mapObjects.Count; index++)
            {
                SaveObjects($"{path}\\{date}\\Chunks.sav", mapObjects[index], true);
            }
        }
        private void GameFieldMouseMoveEvent(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                var xDelta = _dragStartCoordinates.X - e.X;
                var yDelta = _dragStartCoordinates.Y - e.Y;

                var mapSizeInPixels = Map.GetMapSize() * Chunk.GetChunkSize() * _spritesSize;

                if (-_dragDistancePoint.X + xDelta >= 1 && -_dragDistancePoint.X + xDelta + Width <= mapSizeInPixels - 1)
                {
                    _dragDistancePoint.X -= (_dragStartCoordinates.X - e.X);
                } 
                else if (-_dragDistancePoint.X + Width + xDelta > mapSizeInPixels)
                {
                    _dragDistancePoint.X = -mapSizeInPixels + Width + 1;
                }

                else if (-_dragDistancePoint.X + xDelta < 0)
                {
                    _dragDistancePoint.X = 0;
                }
                
                if (-_dragDistancePoint.Y + yDelta >= 1 && -_dragDistancePoint.Y + yDelta + Height <= mapSizeInPixels - 1) 
                {
                    _dragDistancePoint.Y -= (_dragStartCoordinates.Y - e.Y);
                    
                }
                else if (-_dragDistancePoint.Y + Height + yDelta > mapSizeInPixels)
                {
                    _dragDistancePoint.Y = -mapSizeInPixels + Height + 1;
                }
                else if (-_dragDistancePoint.Y + yDelta < 0)
                {
                    _dragDistancePoint.Y = 0;
                }

                _dragStartCoordinates.X = e.X;
                _dragStartCoordinates.Y = e.Y;

                Invalidate();
            }

            var blockSize = Sprites.GetSpritesSize();
            var currentXBlock = (e.X - _dragDistancePoint.X % blockSize) / blockSize;
            var currentYBlock = (e.Y - _dragDistancePoint.Y % blockSize) / blockSize;

            if (currentXBlock != _lastX || currentYBlock != _lastY)
            {
                _lastY = currentYBlock; 
                _lastX = currentXBlock;
                _mouseX = currentXBlock * blockSize;
                _mouseY = currentYBlock * blockSize;

                Invalidate();
            }
        }
        
        private void ButtonMouseMove(object sender, MouseEventArgs e)
        {
            var sendButton = sender as Button;

            if (sendButton.FlatAppearance.BorderColor != Color.Blue)
            {
                sendButton.FlatAppearance.BorderColor = Color.Yellow;
            }
        }

        private void GameFieldMouseUpEvent(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    _dragging = false;
                    break;
                case MouseButtons.Right:
                    if (_pressedButton != null)
                    {
                        if (!Building.BuildingIsAbleToPlace(new Point(_mouseX, _mouseY), 
                                _dragDistancePoint, _pressedButton))
                        {
                            return;
                        }
                        new Building().PlaceBuilding(new Point(_mouseX, _mouseY), _pressedButton, _dragDistancePoint);
                    }

                    Invalidate();
                    break;
            }
        }

        private void GameFieldMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _dragging = true;
                _dragStartCoordinates.X = e.X;
                _dragStartCoordinates.Y = e.Y;
            }
        }

        private void ButtonMouseLeave(object sender, EventArgs e)
        {
            var sendButton = sender as Button;

            if (sendButton.FlatAppearance.BorderColor != Color.Blue)
            {
                sendButton.FlatAppearance.BorderColor = Color.Red;
            }
        }
        

        private void ButtonMouseClick(object sender, EventArgs e)
        {
            //События для кнопок, при нажатии которых, рамка Flat будет синей(Blue). При повторном клике, рамка меняет цвет на жёлтый(Yellow).
            var sendButton = sender as Button;

            if (_pressedButton != null)
            {
                _pressedButton.FlatAppearance.BorderColor = Color.Red;
                _pressedButton = null;
            }
            if (sendButton.FlatAppearance.BorderColor.Equals(Color.Yellow))
            {
                sendButton.FlatAppearance.BorderColor = Color.Blue;
                _pressedButton = sendButton;
            }
            else
            {
                sendButton.FlatAppearance.BorderColor = Color.Yellow;
                _pressedButton = null;
            }

            Invalidate();
        }

        private void ChangeMapZoom()
        {
            _spritesSize = Sprites.GetSpritesSize();

            if (_scrollingDown)
            {
                Sprites.DecreaseSize(SpriteSizeChangeOnScroll);

                _dragDistancePoint.X = (_dragDistancePoint.X - _scrollToX) / _spritesSize * (_spritesSize - SpriteSizeChangeOnScroll) + _scrollToX;
                _dragDistancePoint.Y = (_dragDistancePoint.Y - _scrollToY) / _spritesSize * (_spritesSize - SpriteSizeChangeOnScroll) + _scrollToY;
                _scrollingDown = false;
            }
            else if (_scrollingUp)
            {
                Sprites.IncreaseSize(SpriteSizeChangeOnScroll);

                _dragDistancePoint.X = ((_dragDistancePoint.X - _scrollToX) / _spritesSize) * (_spritesSize + SpriteSizeChangeOnScroll) + _scrollToX;
                _dragDistancePoint.Y = ((_dragDistancePoint.Y - _scrollToY) / _spritesSize) * (_spritesSize + SpriteSizeChangeOnScroll) + _scrollToY;
                _scrollingUp = false;
            }

            _spritesSize = Sprites.GetSpritesSize();
            var mapSizeInPixels = Map.GetMapSize() * Chunk.GetChunkSize() * _spritesSize;

            if (-_dragDistancePoint.X + Width > mapSizeInPixels)
            {
                _dragDistancePoint.X = -(mapSizeInPixels - Width);
            }
            else if (-_dragDistancePoint.X < 0)
            {
                _dragDistancePoint.X = 0;
            }
            if (-_dragDistancePoint.Y + Height > mapSizeInPixels)
            {
                _dragDistancePoint.Y = -(mapSizeInPixels - Height);
            }
            else if (-_dragDistancePoint.Y < 0)
            {
                _dragDistancePoint.Y = 0;
            }
        }

        private void DrawForm(object sender, PaintEventArgs e)
        {
            var formGraphics = e.Graphics;
            
            Map.DrawMap(formGraphics, _dragDistancePoint);
            Building.DrawCreatedBuildings(formGraphics, _dragDistancePoint);

                if (_pressedButton != null)
                {

                    var blockOccupied = Building.BuildingIsAbleToPlace(new Point(_mouseX, _mouseY), _dragDistancePoint, _pressedButton);
                    
                    Building.DrawBuilding(formGraphics, _pressedButton, _dragDistancePoint, _mouseX, _mouseY, blockOccupied);
                }
            
        DrawResourcesInfo(formGraphics, Size);
            DrawBuildingPick(formGraphics, Size);
        }

        private void DrawResourcesInfo(Graphics formGraphics, Size sizeForm)
        {
            
            var resourcesInfoXCoordinate = sizeForm.Width / 2 - Properties.Resources.ResourcesInfo.Width / 2;

            formGraphics.DrawImage(Properties.Resources.ResourcesInfo, new Point(resourcesInfoXCoordinate, 0));

            foreach (var resourcesInfoObject in _resourcesInfoList)
            {
                resourcesInfoObject.DrawResourceInfo(formGraphics, resourcesInfoXCoordinate);
                resourcesInfoObject.DrawResourceShift(formGraphics, resourcesInfoXCoordinate);
            }
            
        }

        private void DrawBuildingPick(Graphics graphicsForm, Size sizeForm)
        {
            var buildingPickXCoordinate= sizeForm.Width / 2 - 420 / 2;
            graphicsForm.DrawImage(Properties.Resources.botton_button, buildingPickXCoordinate, sizeForm.Height - 90, 420, 60);
        }
    }
}