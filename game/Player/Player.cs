using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace game.Player
{
    
        class Resources
        {
            protected int Iron, Sand, Glass, Energy;

            protected void GetResource() {}

        };



    internal class Player : Resources
    {
        public int GetAmountOfRecources()
        {
            return 3;
            //return GetResource()
        }
    }
}
