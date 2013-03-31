using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VectorArenaCore.Bots;
using VectorArenaCore.Bullets;
using VectorArenaCore.Networking;
using VectorArenaCore.Ships;

namespace VectorArenaCore.Worlds
{
    /// <summary>
    /// The world in which the game takes place
    /// </summary>
    public class World
    {
        /// <summary>
        /// Manages ships flying around in the world
        /// </summary>
        public ShipManager ShipManager;

        /// <summary>
        /// Manages bullets flying through the world
        /// </summary>
        public BulletManager BulletManager;

        /// <summary>
        /// Manages bots floating through the world
        /// </summary>
        public BotManager BotManager;

        /// <summary>
        /// Width of the world
        /// </summary>
        public const int Width = 10000;

        /// <summary>
        /// Height of the world
        /// </summary>
        public const int Height = 10000;

        /// <summary>
        /// Constructs the world
        /// </summary>
        /// <param name="networkManager"></param>
        public World()
        {
            ShipManager = new ShipManager(this);
            BulletManager = new BulletManager();
            BotManager = new BotManager();
        }

        /// <summary>
        /// Sets the world to the initial state
        /// </summary>
        public void Initialize()
        {
            ShipManager.Initialize();
            BulletManager.Initialize();
            BotManager.Initialize();
        }

        /// <summary>
        /// Updates the world
        /// </summary>
        public void Update(TimeSpan elapsedTime)
        {
            ShipManager.Update(elapsedTime);
            BulletManager.Update(elapsedTime);
            BotManager.Update(elapsedTime);
        }

        public void Sync(WorldPacket worldPacket)
        {
            ShipManager.Sync(worldPacket.Ships);
            BulletManager.Sync(worldPacket.Bullets);
            BotManager.Sync(worldPacket.Bots);
        }
    }
}
