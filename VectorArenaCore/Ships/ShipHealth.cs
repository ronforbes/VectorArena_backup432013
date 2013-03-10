using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VectorArenaCore.Ships
{
    public class ShipHealth
    {
        public bool Alive;
        public int Health;

        public ShipHealth()
        {
            Alive = false;
            Health = 0;
        }
    }
}
