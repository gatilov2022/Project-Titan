using System;
using System.Collections.Generic;
using System.Linq;


namespace game.Player
{
    /*!
     * \brief Класс Player хранит в себе информация о ресурсах.
     * В хранение входит: кол-во каждого ресурса, кол-во выробатывания его или поглощения.
     */
    [Serializable]
    public class Player
    {
        private Dictionary<string, int[]> _playerResources;
        public Player()
        {
            _playerResources = new Dictionary<string, int[]>
            {
                {"Iron",  new[]{500, 0, 1000}}, {"Sand",  new[]{400, 0, 600}}, {"Energy", new[]{400, 0, 600}}, {"Water",  new[]{300, 0, 400}}, {"ComponentsT1" ,  new[]{0, 0, 100}}, {"ComponentsT2",  new[]{0, 0, 100}}, {"ComponentsT3",  new[]{0, 0, 100}}
            };
        }
        /*!
         * \brief Метод возращаёт информацию по всем ресурсам.
         * \return _playerResources Все ресурсы.
         */
        public Dictionary<string, int[]> GetPlayerResourcesDict()
        {
            return _playerResources;
        }
        /*!
         * \brief Метод для загрузки сохранённых данных
         * \param loadResources Загружаеммые данные.
         */
        public void loadResourecesDict(Dictionary<string, int[]> loadResources)
        {
            _playerResources = loadResources;
        }

        /*!
         * \brief Метод возращающий кол-во ресурса.
         * \param resource Тип ресурса.
         * \return _playerResources[resource][0] Кол-во заданного ресурса.
         */
        public int GetAmountOfResources(string resource)
        {
            return _playerResources[resource][0];
        }

        /*!
         * \brief Метод уменьшает кол-во ресурса.
         * \param resource Тип ресурса.
         * \param amount Кол-во ресурса, которое будет вычтено.
         */
        public void DecreaseAmountOfResources(string resource, int amount)
        {
            _playerResources[resource][0] -= amount;
        }

        /*!
         * \brief Метод увеличивающий кол-во ресурса.
         * \param resource Тип ресурса.
         * \param amount Кол-во ресурса, которое будет добавлено.
         */
        public void IncreaseAmountOfResources(string resource, int amount)
        {
            _playerResources[resource][0] += amount;
        }

        /*!
         * \brief Метод увеличивающий добывание ресурса.
         * \param resource Тип ресурса.
         * \param amount Кол-во ресурса на сколько будет увеличено.
         */
        public void IncrShiftRes(string resource, int amount)
        {
            _playerResources[resource][1] += amount;
        }

        /*!
         * \brief Возращает кол-во ресурса в секунду.
         * \param resource Тип ресурса.
         */
        public int GetShiftRes(string resource)
        {
            return _playerResources[resource][1];
        }

        /*!
         * \brief Метод ууменьшающий добывание ресурса.
         * \param resource Тип ресурса.
         * \param amount Кол-во ресурса на сколько будет уменьшено.
         */
        public void DecreaseShiftRes(string resource, int amount)
        {
            _playerResources[resource][1] -= amount;
        }

        /*!
         * \brief Метод обнуляющий кол-во ресурсов в секунду.
         */
        public void SetResourcesShiftToZero()
        {
            foreach (var key in _playerResources.Keys.ToArray())
            {
                _playerResources[key][1] = 0;
            }
        }

        /*!
         * \brief Меотод возращает максимальное кол-во ресурсов у игрока.
         * \param resource Тип ресурса.
         */
        public int GetResourceCapacity(string resource)
        {
            return _playerResources[resource][2];
        }

        /*!
         * \brief Метод увеличивающий максимальное кол-во ресурсов у игрока.
         */
        public void IncreaseResourceCapacity(int amount)
        {
            foreach (var key in _playerResources.Keys.ToArray())
            {
                _playerResources[key][2] += amount;
            }
        }
    }
}
