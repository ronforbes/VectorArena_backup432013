using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorArenaCore.Ships;

namespace VectorArenaWP8.Networking
{
    class User
    {
        public int ShipId;
        public Ship Ship;

        public User()
        {
            ShipId = -1;
            Ship = null;
        }
    }
}
