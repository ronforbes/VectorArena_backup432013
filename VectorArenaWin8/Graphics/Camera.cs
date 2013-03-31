using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorArenaCore.Entities;

namespace VectorArenaWin8.Graphics
{
    class Camera
    {
        public const float Distance = 500.0f;

        public Vector3 Position = Vector3.Backward;
        public Vector3 Target = Vector3.Zero;
        public Vector3 Up = Vector3.Up;
        public Viewport ScreenDimensions;
        public Entity TargetEntity;
        public Matrix World = Matrix.Identity;

        public Matrix View
        {
            get { return Matrix.CreateLookAt(Position, Target, Up); }
        }

        public Matrix Projection
        {
            get { return Matrix.CreatePerspectiveFieldOfView(Microsoft.Xna.Framework.MathHelper.PiOver4, (float)ScreenDimensions.Width / (float)ScreenDimensions.Height, 1.0f, 1000.0f); }
        }

        public Camera(int width, int height)
        {
            ScreenDimensions = new Viewport(0, 0, width, height);
            TargetEntity = null;
        }

        public void Update(GameTime gameTime)
        {
            if (TargetEntity != null)
            {
                Position = new Vector3(TargetEntity.Movement.Position.X, TargetEntity.Movement.Position.Y, Position.Z);
                Target = new Vector3(TargetEntity.Movement.Position.X, TargetEntity.Movement.Position.Y, 0.0f);
            }
        }
    }
}
