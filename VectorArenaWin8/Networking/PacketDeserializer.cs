using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorArenaCore.Bots;
using VectorArenaCore.Bullets;
using VectorArenaCore.MathHelper;
using VectorArenaCore.Networking;
using VectorArenaCore.Ships;

namespace VectorArenaWin8.Networking
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
                Ship ship = DeserializeShip(token);

                if(ship != null)
                {
                    worldPacket.Ships.Add(ship);
                }
            }

            // Deserialize bullets
            JArray bullets = (JArray)container[1];

            foreach (JToken token in bullets)
            {
                Bullet bullet = DeserializeBullet(token);

                if (bullet != null)
                {
                    worldPacket.Bullets.Add(bullet);
                }
            }

            // Deserialize bots
            JArray bots = (JArray)container[2];

            foreach (JToken token in bots)
            {
                Bot bot = DeserializeBot(token);

                if (bot != null)
                {
                    worldPacket.Bots.Add(bot);
                }
            }

            // Deserialize last command
            int lastCommandId = (int)container[3];
            worldPacket.LastCommandId = lastCommandId;

            return worldPacket;
        }

        Ship DeserializeShip(JToken token)
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

        Bullet DeserializeBullet(JToken token)
        {
            Bullet bullet = null;

            if (token.Count<object>() != 0)
            {
                bullet = new Bullet(Vector2.Zero, Vector2.Zero, null);
                bullet.Id = (int)token[0];
                bullet.Movement.Position.X = (float)token[1];
                bullet.Movement.Position.Y = (float)token[2];
                bullet.Movement.Velocity.X = (float)token[3];
                bullet.Movement.Velocity.Y = (float)token[4];
            }

            return bullet;
        }

        Bot DeserializeBot(JToken token)
        {
            Bot bot = null;

            if (token.Count<object>() != 0)
            {
                bot = new Bot();
                bot.Id = (int)token[0];
                bot.Movement.Position.X = (float)token[1];
                bot.Movement.Position.Y = (float)token[2];
                bot.Movement.Velocity.X = (float)token[3];
                bot.Movement.Velocity.Y = (float)token[4];
                bot.Movement.Acceleration.X = (float)token[5];
                bot.Movement.Acceleration.Y = (float)token[6];
            }

            return bot;
        }
    }
}
