using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VectorArenaCore.Bots;
using VectorArenaCore.Bullets;
using VectorArenaCore.Ships;

namespace VectorArenaCore.Networking
{
    public class WorldPacket
    {
        public List<Ship> Ships;
        public List<Bullet> Bullets;
        public List<Bot> Bots;
        public int LastCommandId;

        public WorldPacket()
        {
            Ships = new List<Ship>();
            Bullets = new List<Bullet>();
            Bots = new List<Bot>();
        }
    }
}
