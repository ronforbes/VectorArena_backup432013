using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VectorArenaCore.Networking
{
    class WorldPacket
    {
        public List<object> Ships;
        public List<object> Bullets;
        public List<object> Bots;

        public WorldPacket()
        {
            Ships = new List<object>();
            Bullets = new List<object>();
            Bots = new List<object>();
        }
    }
}
