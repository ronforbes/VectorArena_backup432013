using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VectorArenaCore.Entities;
using VectorArenaCore.Worlds;

namespace VectorArenaCore.Ships
{
    public class Ship : Entity
    {
        public ShipHealth Health;
        public ShipWeapons Weapons;

        public enum Action
        {
            TurnLeft,
            TurnRight,
            ThrustForward,
            ThrustBackward,
            Fire
        }

        public Dictionary<Action, bool> Actions;

        public const float Radius = 15.0f;

        public Ship(World world)
        {
            Movement = new ShipMovement(this);
            Health = new ShipHealth();
            Weapons = new ShipWeapons(this, world);
            
            Actions = new Dictionary<Action, bool>();
            Actions.Add(Action.TurnLeft, false);
            Actions.Add(Action.TurnRight, false);
            Actions.Add(Action.ThrustForward, false);
            Actions.Add(Action.ThrustBackward, false);
            Actions.Add(Action.Fire, false);
        }

        public override void Update(TimeSpan elapsedTime)
        {
            Movement.Update(elapsedTime);
            Weapons.Update();
        }
    }
}
