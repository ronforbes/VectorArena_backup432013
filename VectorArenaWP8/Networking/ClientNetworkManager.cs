using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VectorArenaWP8.Networking
{
    /// <summary>
    /// Manages communication between a client and server
    /// </summary>
    class ClientNetworkManager : IDisposable
    {
        bool isDisposed;

        /// <summary>
        /// Initiates the connection to the server
        /// </summary>
        public void Initialize()
        {

        }

        /// <summary>
        /// Shuts down the connection to the server
        /// </summary>
        public void Shutdown()
        {

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
