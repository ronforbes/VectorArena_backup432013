using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace VectorArenaCore.Ships
{
    public class ShipManager
    {
        static int idCounter = 0;

        /// <summary>
        /// The ships that inhabit the world
        /// </summary>
        public List<Ship> Ships;

        public ShipManager()
        {
            Ships = new List<Ship>();
        }

        /// <summary>
        /// Sets ships to initial state
        /// </summary>
        public void Initialize()
        {
            Ships.Clear();
        }

        /// <summary>
        /// Creates a new ship and adds it to the world
        /// </summary>
        /// <returns></returns>
        public Ship Create()
        {
            Ship newShip = new Ship();

            newShip.Id = Interlocked.Increment(ref idCounter);

            Ships.Add(newShip);

            return newShip;
        }

        /// <summary>
        /// Adds a new ship
        /// </summary>
        public Ship Add()
        {
            Ship newShip = new Ship();

            Ships.Add(newShip);

            return newShip;
        }

        /// <summary>
        /// Returns the ship with the specified ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Ship Ship(int id)
        {
            Ship ship = Ships.FirstOrDefault(s => s.Id == id);

            return ship;
        }

        /// <summary>
        /// Updates the ships
        /// </summary>
        /// <param name="elapsedTime"></param>
        public void Update(TimeSpan elapsedTime)
        {
            foreach (Ship ship in Ships)
            {
                ship.Update(elapsedTime);
            }
        }
    }
}
