using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using VectorArenaWebRole;

namespace VectorArenaWebRole
{
    public class Global : HttpApplication
    {
        Game game;

        void Application_Start(object sender, EventArgs e)
        {
            // Registrer the default hubs route: ~/signalr
            RouteTable.Routes.MapHubs();

            // Start the game
            game = new Game();
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }
    }
}
