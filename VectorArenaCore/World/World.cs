using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VectorArenaCore.Bot;
using VectorArenaCore.Bullet;
using VectorArenaCore.Ship;

namespace VectorArenaCore.World
{
    /// <summary>
    /// The world in which the game takes place
    /// </summary>
    public class World
    {
        /// <summary>
        /// Manages ships flying around in the world
        /// </summary>
        ShipManager shipManager;

        /// <summary>
        /// Manages bullets flying through the world
        /// </summary>
        BulletManager bulletManager;

        /// <summary>
        /// Manages bots floating through the world
        /// </summary>
        BotManager botManager;

        /// <summary>
        /// Constructs the world
        /// </summary>
        /// <param name="networkManager"></param>
        public World()
        {
            shipManager = new ShipManager();
            bulletManager = new BulletManager();
            botManager = new BotManager();
        }

        /// <summary>
        /// Sets the world to the initial state
        /// </summary>
        public void Initialize()
        {
            shipManager.Initialize();
            bulletManager.Initialize();
            botManager.Initialize();
        }

        /// <summary>
        /// Updates the world
        /// </summary>
        public void Update(TimeSpan elapsedTime)
        {
            shipManager.Update(elapsedTime);
            bulletManager.Update(elapsedTime);
            botManager.Update(elapsedTime);
        }
    }
}
