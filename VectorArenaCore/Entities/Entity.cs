using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VectorArenaCore.Entities
{
    public class Entity
    {
        public int Id;

        public virtual void Update(TimeSpan elapsedTime) { }
    }
}
