using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VectorArenaCore.Ships;

namespace VectorArenaWebRole.Networking
{
    public class UserManager
    {
        List<User> users;
        ShipManager shipManager;

        public UserManager(ShipManager shipManager)
        {
            users = new List<User>();
            this.shipManager = shipManager;
        }

        public void Initialize()
        {
            users.Clear();
        }

        public int Add(string connectionId)
        {
            User newUser = new User(connectionId);
            Ship newShip = shipManager.Create();

            newUser.Ship = newShip;

            users.Add(newUser);

            return newShip.Id;
        }

        public bool Remove(string connectionId)
        {
            User userToRemove = users.Find(u => u.ConnectionId == connectionId);

            bool removedUser = users.Remove(userToRemove);

            return removedUser;
        }
    }
}