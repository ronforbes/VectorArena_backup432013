using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorArenaCore.Ships;
using VectorArenaCore.Worlds;
using VectorArenaWin8.Graphics;
using VectorArenaWin8.Networking;
using VectorArenaWin8.Ships;
using VectorArenaWin8.Users;

namespace VectorArenaWin8.Worlds
{
    /// <summary>
    /// Displays the world on screen
    /// </summary>
    public class WorldView
    {
        /// <summary>
        /// World to be displayed
        /// </summary>
        World world;

        /// <summary>
        /// User's perspective in which the world will be displayed
        /// </summary>
        User user;

        /// <summary>
        /// Starfield drawn in the background of the world
        /// </summary>
        Starfield starfield;

        /// <summary>
        /// Grid drawn in the background of the world
        /// </summary>
        Grid grid;

        /// <summary>
        /// Draws ships in the world
        /// </summary>
        ShipView shipView;

        /// <summary>
        /// Graphics device used to display the world
        /// </summary>
        GraphicsDevice graphicsDevice;

        /// <summary>
        /// Line batch used to draw shapes in the world
        /// </summary>
        LineBatch lineBatch;

        /// <summary>
        /// Point batch used to draw shapes in the world
        /// </summary>
        PointBatch pointBatch;

        /// <summary>
        /// Sprite batch used for bloom postprocess
        /// </summary>
        SpriteBatch spriteBatch;

        /// <summary>
        /// Camera perspective from which the world will be drawn
        /// </summary>
        Camera camera;

        /// <summary>
        /// Bloom shader postprocess
        /// </summary>
        Bloom bloom;

        /// <summary>
        /// Offscreen surface used for postprocessing
        /// </summary>
        RenderTarget2D renderTarget;
        
        /// <summary>
        /// Background color on which the world is drawn
        /// </summary>
        readonly Color clearColor = new Color(0.0f, 0.0f, 0.1f, 0.1f);

        /// <summary>
        /// Constructs the world display
        /// </summary>
        /// <param name="world"></param>
        /// <param name="user"></param>
        public WorldView(World world, User user)
        {
            this.world = world;
            this.user = user;
            starfield = new Starfield(World.Width, World.Height);
            grid = new Grid(World.Width, World.Height);
            shipView = new ShipView();
        }

        /// <summary>
        /// Initializes the world view
        /// </summary>
        /// <param name="graphicsDevice"></param>
        public void Initialize(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
            camera = new Camera(graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height);
            PresentationParameters parameters = graphicsDevice.PresentationParameters;
            renderTarget = new RenderTarget2D(graphicsDevice, parameters.BackBufferWidth, parameters.BackBufferHeight, false, parameters.BackBufferFormat, parameters.DepthStencilFormat, parameters.MultiSampleCount, RenderTargetUsage.DiscardContents);
        }

        /// <summary>
        /// Loads graphics content needed to display the world
        /// </summary>
        /// <param name="graphicsDevice"></param>
        public void LoadContent(GraphicsDevice graphicsDevice)
        {
            lineBatch = new LineBatch(graphicsDevice);
            pointBatch = new PointBatch(graphicsDevice);
            spriteBatch = new SpriteBatch(graphicsDevice);
            bloom = new Bloom(graphicsDevice, spriteBatch);
        }

        /// <summary>
        /// Unloads graphics content used to display the world
        /// </summary>
        public void UnloadContent()
        {
            lineBatch.Dispose();
            pointBatch.Dispose();
            spriteBatch.Dispose();
            bloom.Dispose();
        }

        /// <summary>
        /// Updates the objects and camera used to draw the world
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            //bulletManagerView.Update(world.BulletManager);
            //botManagerView.Update(world.BotManager);

            // TODO: feels like we shouldn't check for this every frame.
            // Find a better place for this to live
            if (camera.TargetEntity == null && user.Ship != null)
            {
                camera.TargetEntity = user.Ship;
                camera.Position = new Vector3(user.Ship.Movement.Position.X, user.Ship.Movement.Position.Y, Camera.Distance);
            }

            camera.Update(gameTime);
        }

        /// <summary>
        /// Draws the world
        /// </summary>
        public void Draw()
        {
            graphicsDevice.SetRenderTarget(renderTarget);
            graphicsDevice.Clear(ClearOptions.Target, clearColor, 0, 0);

            starfield.Draw(pointBatch, camera);
            grid.Draw(lineBatch, camera);

            foreach (Ship ship in world.ShipManager.Ships.Values)
            {
                shipView.Draw(ship, lineBatch, pointBatch, camera);
            }

            //bulletManagerView.Draw();
            //botManagerView.Draw();

            bloom.Begin(renderTarget);

            graphicsDevice.SetRenderTarget(null);
            graphicsDevice.Clear(ClearOptions.Target, clearColor, 0, 0);

            bloom.End(renderTarget);
        }
    }
}
