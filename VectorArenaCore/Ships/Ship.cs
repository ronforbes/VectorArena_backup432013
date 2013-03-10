using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VectorArenaCore.Entities;

namespace VectorArenaCore.Ships
{
    public class Ship : Entity
    {
        public ShipMovement Movement;
        public ShipHealth Health;

        public Ship()
        {
            Movement = new ShipMovement();
            Health = new ShipHealth();
        }

        public override void Update(TimeSpan elapsedTime)
        {
            
        }
    }
}
