using System;
using System.Collections.Generic;
using System.Drawing;

namespace game.World_map
{
    /*!
     * \brief Класс Map служит созданию игровой области.
     * Хранит в себе размер карты, игровые области(чанки).
     */
    [Serializable]
    internal class Map
    {
        private static List<Chunk> _chunks = new List<Chunk>();
        private static int _mapSize = 12;

        /*!
         * \brief Метод для загрузки всех чанков из сохранения.
         */
        public static void LoadChunks(List<Chunk> deserealizedChunks)
        {
            _chunks = deserealizedChunks;
        }

        /*!
         * \brief Метод для получения всех чанков.
         * Полсе чего они сохраняются.
         * \return _chunks Все чанки карты.
         */
        public static List<Chunk> GetChunks()
        {
            return _chunks;
        }

        /*!
         * \brief Метод для возращения типа блока.
         * Ищет тип блока от координат курсора.
         * \param coordinates Координаты для поиска типа блока.
         * \return _chunks[chunkNumber].GetBlockByNumber(blockNumber) Тип блока.
         */
        public static string GetBlockType(Point coordinates)
        {
            var chunkNumber = coordinates.Y / (Chunk.GetChunkSize() * Sprites.GetSpritesSize()) * Map.GetMapSize() + 
                              coordinates.X / (Sprites.GetSpritesSize() * Chunk.GetChunkSize());

            var blockNumber = coordinates.Y / Sprites.GetSpritesSize() % Chunk.GetChunkSize() * Chunk.GetChunkSize() +
                              coordinates.X / Sprites.GetSpritesSize() % Chunk.GetChunkSize();

            return _chunks[chunkNumber].GetBlockByNumber(blockNumber).ToString();
        }

        /*!
         * \brief Генерация карты.
         * Генерирует по заданному размеру. Карта имеет вид квадрата.
         */
        public static void GenerateMap()
        {
            for (var chunk = 0; chunk < _mapSize * _mapSize; chunk++)
                    _chunks.Add(new Chunk());
        }
        /*!
         * \return Возращает размер карты.
         */
        public static int GetMapSize()
        {
            return _mapSize;
        }
        // Отрисовка всех объектов из всех списков
        /*!
         * \brief Отрисовка всех блоков на карте.
         * \param graphicsForm Область окна , на котором будет отображена карта.
         * \param dragDelta Координаты изменения от первичного располежения карты
         */
        public static void DrawMap(Graphics graphicsForm, Point dragDelta)
        {
            var spritesSize = Sprites.GetSpritesSize();

            for (var chunk = 0; chunk < _chunks.Count; chunk++)
            {
                var localCoordinateX = chunk % _mapSize * spritesSize * Chunk.GetChunkSize();
                var localCoordinateY = chunk / _mapSize * spritesSize * Chunk.GetChunkSize();

                graphicsForm.DrawImage(_chunks[chunk].GetImage(),
                    dragDelta.X + localCoordinateX, dragDelta.Y + localCoordinateY, 
                    spritesSize * Chunk.GetChunkSize() + 1, spritesSize * Chunk.GetChunkSize() + 1);
            }
        }
    }
}
