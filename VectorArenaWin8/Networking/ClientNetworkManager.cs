using Microsoft.AspNet.SignalR.Client.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VectorArenaCore.Worlds;

namespace VectorArenaWin8.Networking
{
    /// <summary>
    /// Manages communication between a client and server
    /// </summary>
    class ClientNetworkManager : IDisposable
    {
        /// <summary>
        /// Handles the connection to the server
        /// </summary>
        HubConnection connection;

        /// <summary>
        /// Sends messages to the server
        /// </summary>
        IHubProxy proxy;

        /// <summary>
        /// The world that will be updated by the server
        /// </summary>
        World world;

        /// <summary>
        /// The user that will be set by the server
        /// </summary>
        User user;

        bool isDisposed;

        /// <summary>
        /// Constructs the client network manager
        /// </summary>
        public ClientNetworkManager(World world, User user)
        {
            // Construct the connection to the hub
#if DEBUG
            connection = new HubConnection("http://localhost:29058");
#else
            connection = new HubConnection("http://vectorarena.cloudapp.net");
#endif

            // Construct the proxy to the hub
            proxy = connection.CreateHubProxy("ServerHub");

            // Set the world context
            this.world = world;

            this.user = user;
        }

        /// <summary>
        /// Initiates the connection to the server
        /// </summary>
        public void Initialize()
        {
            // Respond to synchronization messages
            proxy.On("Handshake", id => Handshake(id));
            proxy.On("Sync", world => Sync(world));

            // Start the connection to the hub
            connection.Start();
        }

        void Handshake(dynamic shipId)
        {
            user.ShipId = (int)shipId;
        }

        void Sync(dynamic world)
        {

        }

        /// <summary>
        /// Shuts down the connection to the server
        /// </summary>
        public void Shutdown()
        {
            // Disconnect from the hub
            connection.Stop();

            // Stop responding to synchronization messages
            proxy.On("Sync", world => { });
        }

        public void Dispose()
        {
            Dispose(true);
        }

        void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    this.Shutdown();
                }

                isDisposed = true;
            }
        }
    }
}
