using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using VectorArenaCore.Ships;
using VectorArenaWebRole.Users;

namespace VectorArenaWebRole.Networking
{
    public class ServerHub : Hub
    {
        Game game;

        public ServerHub() : this(Game.Instance) { }

        public ServerHub(Game game)
        {
            this.game = game;
        }

        public override Task OnConnected()
        {
            int id = game.AddUser(Context.ConnectionId);

            return Clients.Client(Context.ConnectionId).Handshake(id);
        }

        public override Task OnDisconnected()
        {
            game.RemoveUser(Context.ConnectionId);

            return base.OnDisconnected();
        }

        public override Task OnReconnected()
        {
            return base.OnReconnected();
        }

        public void StartAction(string action, int commandId)
        {
            User user = game.UserManager.User(Context.ConnectionId);
            Ship ship = user.Ship;
            Ship.Action shipAction = (Ship.Action)Enum.Parse(typeof(Ship.Action), action);
            ship.Actions[shipAction] = true;
            user.LatestCommandId = commandId;
        }

        public void StopAction(string action, int commandId)
        {
            User user = game.UserManager.User(Context.ConnectionId);
            Ship ship = user.Ship;
            Ship.Action shipAction = (Ship.Action)Enum.Parse(typeof(Ship.Action), action);
            ship.Actions[shipAction] = false;
            user.LatestCommandId = commandId;
        }
    }
}