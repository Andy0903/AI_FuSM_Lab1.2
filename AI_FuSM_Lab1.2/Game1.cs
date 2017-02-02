using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Threading;

namespace AI_FuSM_Lab1._2
{
    public class Game1 : Game
    {
        public static ContentManager myContentManager;
        public static GraphicsDeviceManager myGraphics;
        SpriteBatch mySpritebatch;
        Random myRand = new Random();

        Player myPlayer;
        Enemy myEnemy;
        List<Pickup> myPickups = new List<Pickup>();

        Thread mySpawnThread;
        bool myThreadIsActive;

        public Game1()
        {
            myGraphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            myContentManager = Content;
            mySpritebatch = new SpriteBatch(GraphicsDevice);
            myPlayer = new Player(new Vector2(100, 100));
            myEnemy = new Enemy(new Vector2(400, 100), myPlayer);

            myThreadIsActive = true;
            mySpawnThread = new Thread(new ThreadStart(SpawnPickups));
            mySpawnThread.Start();
        }

        protected override void UnloadContent()
        {
        }
        
        protected override void Update(GameTime aGameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                myThreadIsActive = false;
                Exit();
            }

            KeyboardUtility.Update();
            myPlayer.Update(aGameTime);
            myEnemy.Update(aGameTime);
            base.Update(aGameTime);
        }

        private void SpawnPickups()
        {
            while (myThreadIsActive)
            {
                Vector2 hpPackPos = new Vector2(myRand.Next(10, myGraphics.PreferredBackBufferWidth - 50), myRand.Next(10, myGraphics.PreferredBackBufferWidth - 50));
                Vector2 ammoPackPos = new Vector2(myRand.Next(10, myGraphics.PreferredBackBufferWidth - 50), myRand.Next(10, myGraphics.PreferredBackBufferWidth - 50));


                myPickups.Add(new HealthPack(hpPackPos));
                Thread.Sleep(1000);
                myPickups.Add(new AmmoBox(ammoPackPos));
                Thread.Sleep(1000);
            }
        }
        
        protected override void Draw(GameTime aGameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            mySpritebatch.Begin();

            myPlayer.Draw(mySpritebatch);
            myEnemy.Draw(mySpritebatch);

            foreach (Pickup p in myPickups)
            {
                p.Draw(mySpritebatch);
            }

            mySpritebatch.End();
            base.Draw(aGameTime);
        }
    }
}
