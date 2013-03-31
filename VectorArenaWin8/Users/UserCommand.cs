using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VectorArenaCore.Ships;

namespace VectorArenaWin8.Users
{
    public class UserCommand
    {
        public int Id;
        public TimeSpan ElapsedTime;
        public Ship.Action Action;
        public bool Active;

        static int idCounter;

        public UserCommand(Ship.Action action, bool active, TimeSpan elapsedTime)
        {
            Id = Interlocked.Increment(ref idCounter);
            
            Action = action;
            Active = active;
            ElapsedTime = elapsedTime;
        }
    }
}
