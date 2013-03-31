using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorArenaCore.Networking;
using VectorArenaCore.Ships;

namespace VectorArenaWP8.Networking
{
    class PacketDeserializer
    {
        public WorldPacket Deserialize(dynamic world)
        {
            WorldPacket worldPacket = new WorldPacket();

            JContainer container = world;

            // Deserialize ships
            JArray ships = (JArray)container[0];

            foreach (JToken token in ships)
            {
                Ship ship = Deserialize(token);

                if(ship != null)
                {
                    worldPacket.Ships.Add(ship);
                }
            }

            return worldPacket;
        }

        Ship Deserialize(JToken token)
        {
            Ship ship = null;

            if (token.Count<object>() != 0)
            {
                ship = new Ship(null);
                ship.Id = (int)token[0];
                ship.Movement.Position.X = (float)token[1];
                ship.Movement.Position.Y = (float)token[2];
                ship.Movement.Velocity.X = (float)token[3];
                ship.Movement.Velocity.Y = (float)token[4];
                ship.Movement.Acceleration.X = (float)token[5];
                ship.Movement.Acceleration.Y = (float)token[6];
                ship.Movement.Rotation = (float)token[7];
                ship.Health.Alive = (bool)token[8];
                ship.Health.Health = (int)token[9];
            }

            return ship;
        }
    }
}
