using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace PlatformerFNAEnvato
{
    public class FNAgame : Game
    {
        private SpriteBatch batch;
        Character player;
        private const float mult = 2f;

        public FNAgame()
        {
            GraphicsDeviceManager gma = new GraphicsDeviceManager(this);
            gma.PreferredBackBufferHeight = (int)(240 * mult);
            gma.PreferredBackBufferWidth = (int)(320 * mult);
            //gma.SynchronizeWithVerticalRetrace = false;
            //IsFixedTimeStep = true;
            //TargetElapsedTime = TimeSpan.FromSeconds(1f / 120f);

            player = new Character();
        }

        protected override void Initialize()
        {
            Content.RootDirectory = "../../../Content";

            batch = new SpriteBatch(GraphicsDevice);
            player.Init();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            player.LoadContent(Content);
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            player.Update(gameTime);

            float fps = 1f / (float)gameTime.ElapsedGameTime.TotalSeconds;
            System.Console.WriteLine(fps);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            batch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, Matrix.CreateScale(mult));
                player.Draw(batch);
            batch.End();

            base.Draw(gameTime);
        }
    }
}
