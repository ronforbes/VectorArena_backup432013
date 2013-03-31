using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VectorArenaCore.MathHelper;

namespace VectorArenaCore.Entities
{
    public class EntityMovement
    {
        public Vector2 Position;
        public Vector2 Velocity;
        public Vector2 Acceleration;
        public float Rotation;

        public EntityMovement()
        {
            Position = Vector2.Zero;
            Velocity = Vector2.Zero;
            Acceleration = Vector2.Zero;
            Rotation = 0.0f;
        }

        public virtual void Update(TimeSpan elapsedTime) { }
    }
}
