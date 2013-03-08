using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;
using VectorArenaCore.World;
using VectorArenaWebRole.Networking;

namespace VectorArenaWebRole
{
    /// <summary>
    /// Runs the game server
    /// </summary>
    public class Game
    {
        World world;
        Timer updateTimer;
        DateTime previousUpdateTime;
        ServerNetworkManager networkManager;

        const double updatesPerSecond = 60;

        /// <summary>
        /// Constructs the game
        /// </summary>
        public Game()
        {
            world = new World();

            updateTimer = new Timer(1000 / updatesPerSecond);
            updateTimer.AutoReset = true;
            updateTimer.Elapsed += Update;

            previousUpdateTime = DateTime.Now;

            networkManager = new ServerNetworkManager(world);
        }

        /// <summary>
        /// Initializes the game
        /// </summary>
        public void Initialize()
        {
            world.Initialize();
            updateTimer.Start();
            networkManager.Initialize();
        }

        /// <summary>
        /// Updates the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="elapsedEventArgs"></param>
        public void Update(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            TimeSpan elapsedTime = elapsedEventArgs.SignalTime - previousUpdateTime;
            previousUpdateTime = elapsedEventArgs.SignalTime;

            world.Update(elapsedTime);
        }
    }
}