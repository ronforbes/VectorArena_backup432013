using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using VectorArenaCore.MathHelper;
using VectorArenaCore.Ships;

namespace VectorArenaCore.Bullets
{
    public class BulletManager
    {
        /// <summary>
        /// The bullets fired into the world
        /// </summary>
        public List<Bullet> Bullets;

        static int idCounter = 0;

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

        public Bullet Add(Vector2 position, Vector2 velocity, Ship ship)
        {
            Bullet newBullet = new Bullet(position, velocity, ship);

            newBullet.Id = Interlocked.Increment(ref idCounter);

            Bullets.Add(newBullet);

            return newBullet;
        }

        /// <summary>
        /// Updates the bullets
        /// </summary>
        /// <param name="elapsedTime"></param>
        public void Update(TimeSpan elapsedTime)
        {

        }

        /// <summary>
        /// Synchronizes bullets to state received from server
        /// </summary>
        /// <param name="bullets"></param>
        public void Sync(List<Bullet> bullets)
        {

        }
    }
}
