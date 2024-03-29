﻿using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using VectorArenaCore.Networking;
using VectorArenaCore.Worlds;
using VectorArenaWebRole.Users;

namespace VectorArenaWebRole.Networking
{
    /// <summary>
    /// Manages communication between a server and clients
    /// </summary>
    class ServerNetworkManager : IDisposable
    {
        /// <summary>
        /// Broadcasts messages to connected clients
        /// </summary>
        IHubContext context;

        PacketSerializer packetSerializer;

        /// <summary>
        /// World to be broadcast to connected clients
        /// </summary>
        World world;

        /// <summary>
        /// Users to receive synchronization state
        /// </summary>
        UserManager userManager;

        /// <summary>
        /// Maintains periodic synchronizations to clients
        /// </summary>
        Timer syncTimer;

        bool isDisposed;

        const double syncsPerSecond = 60;

        public ServerNetworkManager(World world, UserManager userManager)
        {
            packetSerializer = new PacketSerializer();
            this.world = world;
            this.userManager = userManager;
            context = GlobalHost.ConnectionManager.GetHubContext<ServerHub>();

            // Setup the synchronization timer
            syncTimer = new Timer(1000 / syncsPerSecond);
            syncTimer.AutoReset = true;
            syncTimer.Elapsed += Sync;
        }

        /// <summary>
        /// Initializes the connection to clients
        /// </summary>
        public void Initialize()
        {
            syncTimer.Start();
        }

        /// <summary>
        /// Synchronizes connected clients to the server's state
        /// </summary>
        public void Sync(object sender, ElapsedEventArgs e)
        {
            foreach (User user in userManager.Users.Values)
            {
                object[] serializedWorld = packetSerializer.Serialize(world, user);

                context.Clients.Client(user.ConnectionId).Sync(serializedWorld);
            }
        }

        /// <summary>
        /// Shuts down the connection to clients
        /// </summary>
        public void Shutdown()
        {
            syncTimer.Stop();
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
