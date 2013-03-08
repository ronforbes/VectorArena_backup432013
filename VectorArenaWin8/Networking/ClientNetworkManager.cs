using Microsoft.AspNet.SignalR.Client.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        bool isDisposed;

        /// <summary>
        /// Constructs the client network manager
        /// </summary>
        public ClientNetworkManager()
        {
            // Construct the connection to the hub
#if DEBUG
            connection = new HubConnection("http://localhost:29058");
#else
            connection = new HubConnection("http://vectorarena.cloudapp.net");
#endif

            // Construct the proxy to the hub
            proxy = connection.CreateHubProxy("serverHub");
        }

        /// <summary>
        /// Initiates the connection to the server
        /// </summary>
        public void Initialize()
        {
            // Respond to synchronization messages
            proxy.On("Sync", world => Sync(world));

            // Start the connection to the hub
            connection.Start();
        }

        public void Sync(dynamic world)
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
