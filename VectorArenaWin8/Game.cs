using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using VectorArenaCore.Worlds;
using VectorArenaWin8.Networking;
using VectorArenaWin8.Users;
using VectorArenaWin8.Worlds;

namespace VectorArenaWin8
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
    {
        World world;
        User user;
        ClientNetworkManager networkManager;
        WorldView worldView;
        UserController userController;
        GraphicsDeviceManager _graphics;

        public Game()
        {
            world = new World();
            user = new User();
            networkManager = new ClientNetworkManager(world, user);
            worldView = new WorldView(world, user);
            userController = new UserController(user, networkManager);
            networkManager.UserController = userController;

            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            world.Initialize();
            networkManager.Initialize();
            worldView.Initialize(GraphicsDevice);
            userController.Initialize();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Initialize content needed to display the world
            worldView.LoadContent(GraphicsDevice);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            worldView.UnloadContent();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            world.Update(gameTime.ElapsedGameTime);

            if (user.Ship == null && user.ShipId != -1)
            {
                user.Ship = world.ShipManager.Ship(user.ShipId);
            }

            worldView.Update(gameTime);

            userController.Update(gameTime.ElapsedGameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            worldView.Draw();

            base.Draw(gameTime);
        }
    }
}
