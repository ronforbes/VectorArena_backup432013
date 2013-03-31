using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VectorArenaCore.Ships;

namespace VectorArenaWebRole.Users
{
    public class UserManager
    {
        public Dictionary<string, User> Users;
        ShipManager shipManager;

        public UserManager(ShipManager shipManager)
        {
            Users = new Dictionary<string, User>();
            this.shipManager = shipManager;
        }

        public void Initialize()
        {
            Users.Clear();
        }

        public int Add(string connectionId)
        {
            User newUser = new User(connectionId);
            Ship newShip = shipManager.Create();

            newUser.Ship = newShip;

            Users.Add(connectionId, newUser);

            return newShip.Id;
        }

        public User User(string connectionId)
        {
            if (Users.ContainsKey(connectionId))
            {
                return Users[connectionId];
            }
            else
                return null;
        }

        public bool Remove(string connectionId)
        {
            bool removedUser = Users.Remove(connectionId);

            return removedUser;
        }
    }
}