using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorArenaWin8.Graphics;

namespace VectorArenaWin8.Worlds
{
    class Starfield
    {
        Random random;
        Vector3[] points;
        float[] brightnesses;

        const int depth = 10000;
        const float starRadius = 5.0f;
        const int starCount = 100000;

        public Starfield(int width, int height)
        {
            random = new Random();

            points = new Vector3[starCount];
            brightnesses = new float[starCount];

            BoundingBox bounds = new BoundingBox(new Vector3(-1 * width / 2, -1 * height / 2, -1 * depth / 2), new Vector3(width / 2, height / 2, depth / 2));

            for (int s = 0; s < points.Length; s++)
            {
                points[s] = new Vector3(random.Next((int)bounds.Min.X, (int)bounds.Max.X),
                    random.Next((int)bounds.Min.Y, (int)bounds.Max.Y),
                    random.Next((int)bounds.Min.Z, (int)bounds.Max.Z));
                brightnesses[s] = (float)random.NextDouble();
            }
        }

        public void Draw(PointBatch pointBatch, Camera camera)
        {
            // Draw the starfield
            pointBatch.Begin(Matrix.Identity, camera);

            for (int s = 0; s < starCount; s++)
            {
                pointBatch.Draw(points[s], starRadius, new Color(brightnesses[s], brightnesses[s], brightnesses[s]));
            }

            pointBatch.End();
        }
    }
}
