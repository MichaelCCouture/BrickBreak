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
    public class ScoreBoard : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private SpriteFont spriteFont;
        private int score;
        
        private Bat bat;
        public int Score
        {
            get { return score; }
            set { score = value; }
        }
        private int lives;

        public int Lives
        {
            get { return lives; }
            set { lives = value; }
        }
        public ScoreBoard(Game game, SpriteBatch spriteBatch, SpriteFont spriteFont, Bat bat)
            : base(game)
        {
            // TODO: Construct any child components here
            this.spriteBatch = spriteBatch;
            this.spriteFont = spriteFont;
            this.bat = bat;
            score = 0;
            lives = 3;
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

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(spriteFont, "Lives: " + lives + " Score: " + score, new Vector2(0, 0), Color.White);

            if(!bat.Enabled)
            {
                spriteBatch.DrawString(Game.Content.Load<SpriteFont>("fonts/gameOverFont"), "YOU WIN!", new Vector2(200, 200), Color.White);
            }

            if (lives <= 0)
            {
                spriteBatch.DrawString(Game.Content.Load<SpriteFont>("fonts/gameOverFont"), "GAME OVER", new Vector2(200, 200), Color.White);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
