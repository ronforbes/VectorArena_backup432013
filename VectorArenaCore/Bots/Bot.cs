using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VectorArenaCore.Entities;

namespace VectorArenaCore.Bots
{
    public class Bot : Entity
    {
        public Bot()
        {
            Movement = new BotMovement();
        }
    }
}
