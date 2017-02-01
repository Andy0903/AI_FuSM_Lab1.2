using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AI_FuSM_Lab1._2
{
    abstract class Entity
    {
        #region Member variables
        Texture2D myTexutre;
        #endregion

        #region Properties
        virtual protected Color Color
        {
            get; set;
        }

        virtual public Rectangle Hitbox
        {
            get { return new Rectangle((int)Position.X, (int)Position.Y, myTexutre.Width, myTexutre.Height); }
        }

        public Vector2 Position
        {
            get;
            set;
        }

        public Texture2D Texture
        {
            get { return myTexutre; }
        }
        #endregion

        #region Constructors
        protected Entity(string aFileName, Vector2 aPosition)
        {
            InitializeMemberVariables(aFileName, aPosition);
        }
        #endregion

        #region Public methods
        virtual public void Draw(SpriteBatch aSpriteBatch)
        {
            aSpriteBatch.Draw(myTexutre, Position, Color);
        }
        #endregion

        #region Private methods
        private void InitializeMemberVariables(string aFileName, Vector2 aPosition)
        {
            if (aFileName != null)
            {
                myTexutre = Game1.myContentManager.Load<Texture2D>(aFileName);
            }
            Position = aPosition;
            Color = Color.White;
        }
        #endregion
    }
}
