using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AI_FuSM_Lab1._2
{
    public class Game1 : Game
    {
        public static ContentManager myContentManager;
        public static GraphicsDeviceManager myGraphics;
        SpriteBatch mySpritebatch;

        Player myPlayer;

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
        }

        protected override void UnloadContent()
        {
        }
        
        protected override void Update(GameTime aGameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardUtility.Update();
            myPlayer.Update(aGameTime);

            base.Update(aGameTime);
        }
        
        protected override void Draw(GameTime aGameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            mySpritebatch.Begin();

            myPlayer.Draw(mySpritebatch);

            mySpritebatch.End();
            base.Draw(aGameTime);
        }
    }
}
