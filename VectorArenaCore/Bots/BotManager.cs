using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VectorArenaCore.Bots
{
    public class BotManager
    {
        /// <summary>
        /// The bots floating through the world
        /// </summary>
        public List<Bot> Bots;

        /// <summary>
        /// Constructs the bot manager
        /// </summary>
        public BotManager()
        {
            Bots = new List<Bot>();
        }

        /// <summary>
        /// Sets bots to initial state
        /// </summary>
        public void Initialize()
        {
            Bots.Clear();
        }

        /// <summary>
        /// Updates the bots
        /// </summary>
        /// <param name="elapsedTime"></param>
        public void Update(TimeSpan elapsedTime)
        {

        }

        /// <summary>
        /// Synchronizes bots to state received from server
        /// </summary>
        /// <param name="bots"></param>
        public void Sync(List<Bot> bots)
        {

        }
    }
}
