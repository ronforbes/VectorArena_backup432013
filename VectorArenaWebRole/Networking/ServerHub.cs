using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

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
    }
}