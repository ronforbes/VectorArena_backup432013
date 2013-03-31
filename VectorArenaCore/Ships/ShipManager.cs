using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using VectorArenaCore.MathHelper;
using VectorArenaCore.Worlds;

namespace VectorArenaCore.Ships
{
    public class ShipManager
    {
        static int idCounter = 0;

        /// <summary>
        /// The ships that inhabit the world
        /// </summary>
        public Dictionary<int, Ship> Ships;

        World world;

        public ShipManager(World world)
        {
            Ships = new Dictionary<int, Ship>();

            this.world = world;
        }

        /// <summary>
        /// Sets ships to initial state
        /// </summary>
        public void Initialize()
        {
            Ships.Clear();
        }

        /// <summary>
        /// Creates a new ship and adds it to the world (should only be called by the server)
        /// </summary>
        /// <returns></returns>
        public Ship Create()
        {
            Ship newShip = new Ship(world);

            newShip.Id = Interlocked.Increment(ref idCounter);

            Ships.Add(newShip.Id, newShip);

            return newShip;
        }

        /// <summary>
        /// Adds a ship to the world (should be called by the client when sync'ing from the server)
        /// </summary>
        public Ship Add(int id)
        {
            Ship newShip = new Ship(world);

            newShip.Id = id;

            Ships.Add(newShip.Id, newShip);

            return newShip;
        }

        /// <summary>
        /// Returns the ship with the specified ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Ship Ship(int id)
        {
            Ship ship = null;

            if (Ships.ContainsKey(id))
            {
                ship = Ships[id];
            }

            return ship;
        }

        /// <summary>
        /// Updates the ships
        /// </summary>
        /// <param name="elapsedTime"></param>
        public void Update(TimeSpan elapsedTime)
        {
            foreach (Ship ship in Ships.Values)
            {
                ship.Update(elapsedTime);
            }
        }

        /// <summary>
        /// Synchronizes ships to state received from server
        /// </summary>
        /// <param name="ships"></param>
        public void Sync(List<Ship> ships)
        {
            foreach (Ship ship in ships)
            {
                if (Ship(ship.Id) == null)
                {
                    Add(ship.Id);
                }

                Vector2 deltaPosition =  ship.Movement.Position - Ships[ship.Id].Movement.Position;
                if (deltaPosition.Length() != 0.0f)
                {
                    Ships[ship.Id].Movement.Position += deltaPosition * 0.5f;
                }

                Vector2 deltaVelocity = ship.Movement.Velocity - Ships[ship.Id].Movement.Velocity;
                if (deltaVelocity.Length() != 0.0f)
                {
                    Ships[ship.Id].Movement.Velocity += deltaVelocity * 0.5f;
                }
                
                Ships[ship.Id].Movement.Acceleration = ship.Movement.Acceleration;

                float deltaRotation = ship.Movement.Rotation - Ships[ship.Id].Movement.Rotation;
                if (deltaRotation != 0.0f)
                {
                    Ships[ship.Id].Movement.Rotation += deltaRotation * 0.5f;
                }

                Ships[ship.Id].Health.Alive = ship.Health.Alive;
                Ships[ship.Id].Health.Health = ship.Health.Health;
            }
        }
    }
}
