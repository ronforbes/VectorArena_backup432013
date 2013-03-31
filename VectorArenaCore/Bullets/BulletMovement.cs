using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VectorArenaCore.Entities;
using VectorArenaCore.MathHelper;

namespace VectorArenaCore.Bullets
{
    public class BulletMovement : EntityMovement
    {
        public float Speed = 500.0f;

        public BulletMovement(Vector2 position, Vector2 velocity)
        {
            Position = position;
            Velocity = velocity;
        }
    }
}
