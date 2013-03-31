using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VectorArenaCore.MathHelper;
using VectorArenaCore.Worlds;

namespace VectorArenaCore.Ships
{
    public class ShipWeapons
    {
        Ship ship;

        DateTime lastBulletFired;

        World world;

        readonly TimeSpan fireInterval = TimeSpan.FromMilliseconds(80);

        public ShipWeapons(Ship ship, World world)
        {
            this.ship = ship;
            this.world = world;
            lastBulletFired = DateTime.Now;
        }

        public void Update()
        {
            // Fire based on the action being performed
            if (ship.Actions[Ship.Action.Fire])
            {
                if (DateTime.Now - lastBulletFired >= fireInterval)
                {
                    Vector2 velocity = new Vector2((float)Math.Cos(ship.Movement.Rotation), (float)Math.Sin(ship.Movement.Rotation));
                    Vector2 position = new Vector2(ship.Movement.Position.X + velocity.X * Ship.Radius, ship.Movement.Position.Y + velocity.Y * Ship.Radius);
                    world.BulletManager.Add(position, velocity, ship);
                    lastBulletFired = DateTime.Now;
                }
            }
        }
    }
}
