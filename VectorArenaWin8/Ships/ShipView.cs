using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorArenaCore.Ships;
using VectorArenaWin8.Graphics;

namespace VectorArenaWin8.Ships
{
    class ShipView
    {
        const float lineWidth = 5.0f;
        const float lightRadius = 50.0f;

        readonly List<Vector3> vertices;
        readonly Color color = Color.White;
        readonly Color lightColor = new Color(0.25f, 0.25f, 0.25f, 1.0f);

        public ShipView()
        {
            vertices = new List<Vector3>();
            vertices.Add(new Vector3(15.0f, 0.0f, 0.0f));
            vertices.Add(new Vector3(-15.0f, -15.0f, 0.0f));
            vertices.Add(new Vector3(-10.0f, 0.0f, 0.0f));
            vertices.Add(new Vector3(-15.0f, 15.0f, 0.0f));
        }

        public void Draw(Ship ship, LineBatch lineBatch, PointBatch pointBatch, Camera camera)
        {
            // Draw the ship
            Matrix rotation = Matrix.CreateRotationZ(ship.Movement.Rotation);
            Matrix translation = Matrix.CreateTranslation(new Vector3(ship.Movement.Position.X, ship.Movement.Position.Y, 0.0f));

            lineBatch.Begin(rotation * translation, camera);

            for (int v = 0; v < vertices.Count; v++)
            {
                lineBatch.Draw(vertices[v], vertices[(v + 1) % vertices.Count], lineWidth, color);
            }

            lineBatch.End();

            pointBatch.Begin(translation, camera);
            pointBatch.Draw(Vector3.Zero, lightRadius, lightColor);
            pointBatch.End();
        }
    }
}
