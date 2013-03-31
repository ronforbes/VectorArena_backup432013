using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VectorArenaCore.Bots;
using VectorArenaCore.Bullets;
using VectorArenaCore.Ships;
using VectorArenaCore.Worlds;
using VectorArenaWebRole.Users;

namespace VectorArenaWebRole.Networking
{
    public class PacketSerializer
    {
        public object[] Serialize(World world, User user)
        {
            // Serialize the ships
            List<object> serializedShips = new List<object>();
            
            foreach (Ship ship in world.ShipManager.Ships.Values)
            {
                object[] serializedShip = Serialize(ship);
                serializedShips.Add(serializedShip);
            }

            // Serialize the bullets
            List<object> serializedBullets = new List<object>();

            lock (world.BulletManager.Bullets)
            {
                List<Bullet> bullets = new List<Bullet>(world.BulletManager.Bullets);

                foreach (Bullet bullet in bullets)
                {
                    object[] seriealizedBullet = Serialize(bullet);
                    serializedBullets.Add(seriealizedBullet);
                }
            }

            // Serialize the bots
            List<object> serializedBots = new List<object>();

            foreach (Bot bot in world.BotManager.Bots)
            {
                object[] serializedBot = Serialize(bot);
                serializedBots.Add(serializedBot);
            }

            // Serialize the world
            object[] serializedWorld = new object[4];

            serializedWorld[0] = serializedShips;
            serializedWorld[1] = serializedBullets;
            serializedWorld[2] = serializedBots;
            serializedWorld[3] = user.LatestCommandId;

            return serializedWorld;
        }

        object[] Serialize(Ship ship)
        {
            object[] serializedShip = new object[10];

            serializedShip[0] = ship.Id;
            serializedShip[1] = ship.Movement.Position.X;
            serializedShip[2] = ship.Movement.Position.Y;
            serializedShip[3] = ship.Movement.Velocity.X;
            serializedShip[4] = ship.Movement.Velocity.Y;
            serializedShip[5] = ship.Movement.Acceleration.X;
            serializedShip[6] = ship.Movement.Acceleration.Y;
            serializedShip[7] = ship.Movement.Rotation;
            serializedShip[8] = ship.Health.Alive;
            serializedShip[9] = ship.Health.Health;

            return serializedShip;
        }

        object[] Serialize(Bullet bullet)
        {
            object[] serializedBullet = new object[5];

            serializedBullet[0] = bullet.Id;
            serializedBullet[1] = bullet.Movement.Position.X;
            serializedBullet[2] = bullet.Movement.Position.Y;
            serializedBullet[3] = bullet.Movement.Velocity.X;
            serializedBullet[4] = bullet.Movement.Velocity.Y;

            return serializedBullet;
        }

        object[] Serialize(Bot bot)
        {
            object[] serializedBot = new object[7];

            serializedBot[0] = bot.Id;
            serializedBot[1] = bot.Movement.Position.X;
            serializedBot[2] = bot.Movement.Position.Y;
            serializedBot[3] = bot.Movement.Velocity.X;
            serializedBot[4] = bot.Movement.Velocity.Y;
            serializedBot[5] = bot.Movement.Acceleration.X;
            serializedBot[6] = bot.Movement.Acceleration.Y;

            return serializedBot;
        }
    }
}
