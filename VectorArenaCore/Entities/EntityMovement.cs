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
            Position = new Vector2();
            Velocity = new Vector2();
            Acceleration = new Vector2();
            Rotation = 0.0f;
        }
    }
}
