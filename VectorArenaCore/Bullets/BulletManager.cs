using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VectorArenaCore.Bullets
{
    public class BulletManager
    {
        /// <summary>
        /// The bullets fired into the world
        /// </summary>
        public List<Bullet> Bullets;

        /// <summary>
        /// Constructs the bullet manager
        /// </summary>
        public BulletManager()
        {
            Bullets = new List<Bullet>();
        }

        /// <summary>
        /// Sets bullets to initial state
        /// </summary>
        public void Initialize()
        {
            Bullets.Clear();
        }

        /// <summary>
        /// Updates the bullets
        /// </summary>
        /// <param name="elapsedTime"></param>
        public void Update(TimeSpan elapsedTime)
        {

        }
    }
}
