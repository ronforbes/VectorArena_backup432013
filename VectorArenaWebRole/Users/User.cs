using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VectorArenaCore.Ships;

namespace VectorArenaWebRole.Users
{
    public class User
    {
        public string ConnectionId;
        public Ship Ship;
        public int LatestCommandId;

        public User(string connectionId)
        {
            ConnectionId = connectionId;
        }
    }
}