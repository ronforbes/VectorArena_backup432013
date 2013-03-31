using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VectorArenaCore.Entities;
using VectorArenaCore.MathHelper;
using VectorArenaCore.Ships;

namespace VectorArenaCore.Bullets
{
    public class Bullet : Entity
    {
        Ship ship;

        public Bullet(Vector2 position, Vector2 velocity, Ship ship)
        {
            Movement = new BulletMovement(position, velocity);
            this.ship = ship;
        }
    }
}
