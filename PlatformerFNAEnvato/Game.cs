using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformerFNAEnvato.ECS;
using System;

namespace PlatformerFNAEnvato
{
    public class FNAgame : Game
    {
        GraphicsDeviceManager gma;
        private SpriteBatch batch;
        //Character player;
        private const float mult = 2f;
        Entity testPlayer;

        public FNAgame()
        {
            gma = new GraphicsDeviceManager(this);

            Content.RootDirectory = "../../../Content";
            
            IsMouseVisible = true;

            //player = new Character();
            testPlayer = new Entity();
            testPlayer.AddComponent(new VelocityComponent());
            testPlayer.AddComponent(new TransformComponent());
            testPlayer.AddComponent(new InputComponent());
            testPlayer.AddComponent(new PhysicsComponent());
            testPlayer.AddComponent(new SpriteComponent());

        }

        protected override void Initialize()
        {
            gma.PreferredBackBufferHeight = (int)(240 * mult);
            gma.PreferredBackBufferWidth = (int)(320 * mult);
            //gma.SynchronizeWithVerticalRetrace = false;
            //IsFixedTimeStep = true;
            //TargetElapsedTime = TimeSpan.FromSeconds(1f / 120);
            gma.ApplyChanges();
            testPlayer.GetComponent<TransformComponent>().position = new Vector2(100, 100);
            testPlayer.GetComponent<VelocityComponent>().walkSpeed = 100f;

            batch = new SpriteBatch(GraphicsDevice);
            //player.Init();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            testPlayer.GetComponent<SpriteComponent>().texture = Content.Load<Texture2D>("mariosingle");

            //player.LoadContent(Content);
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            //player.Update(gameTime);

            testPlayer.Update(gameTime);

            float fps = 1f / (float)gameTime.ElapsedGameTime.TotalSeconds;
            System.Console.WriteLine(fps);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            batch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, Matrix.CreateScale(mult));
            testPlayer.Draw(batch);
            //player.Draw(batch);
            batch.End();

            base.Draw(gameTime);
        }
    }
}
