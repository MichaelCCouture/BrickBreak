using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace MCAssignmentFinal
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Bat : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 position;
        private Vector2 initPosition;
        private Vector2 speed;
        public Bat(Game game, SpriteBatch spriteBatch, Texture2D tex)
            : base(game)
        {
            // TODO: Construct any child components here
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            initPosition = new Vector2((Shared.stage.X - tex.Width) / 2, Shared.stage.Y - tex.Height);
            position = initPosition;
            speed = new Vector2(4, 0);
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            KeyboardState ks = Keyboard.GetState();
            

            if (ks.IsKeyDown(Keys.Right))
            {
                position.X += speed.X;
                if (position.X + tex.Width > Shared.stage.X)
                {
                    position.X = Shared.stage.X - tex.Width;
                }
            }
            if (ks.IsKeyDown(Keys.Left))
            {
                position.X -= speed.X;
                if (position.X < 0)
                {
                    position.X = 0;
                }
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, position, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
        public Rectangle getBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y, tex.Width, tex.Height);
        }
    }
}
