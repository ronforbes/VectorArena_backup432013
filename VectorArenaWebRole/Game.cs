using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;
using VectorArenaCore.Worlds;
using VectorArenaWebRole.Networking;
using VectorArenaWebRole.Users;

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
        public UserManager UserManager;

        const double updatesPerSecond = 60;
        readonly static Lazy<Game> instance = new Lazy<Game>(() => new Game());

        public static Game Instance
        {
            get { return instance.Value; }
        }

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

            UserManager = new UserManager(world.ShipManager);

            networkManager = new ServerNetworkManager(world, UserManager);

            Initialize();
        }

        /// <summary>
        /// Initializes the game
        /// </summary>
        void Initialize()
        {
            world.Initialize();
            updateTimer.Start();
            networkManager.Initialize();
            UserManager.Initialize();
        }

        public int AddUser(string connectionId)
        {
            int id = UserManager.Add(connectionId);

            return id;
        }

        public bool RemoveUser(string connectionId)
        {
            bool userRemoved = UserManager.Remove(connectionId);

            return userRemoved;
        }

        /// <summary>
        /// Updates the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="elapsedEventArgs"></param>
        void Update(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            TimeSpan elapsedTime = elapsedEventArgs.SignalTime - previousUpdateTime;
            previousUpdateTime = elapsedEventArgs.SignalTime;

            world.Update(elapsedTime);
        }
    }
}