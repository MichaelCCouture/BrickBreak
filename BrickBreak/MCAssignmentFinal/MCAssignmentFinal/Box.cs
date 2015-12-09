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
    public class Box : Microsoft.Xna.Framework.DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Ball ball;
        Texture2D tex;
        Vector2 position;
        int points;
        ScoreBoard scoreBoard;
        Explosion explosion;
        SoundEffect hitSound;
        public Box(Game game, SpriteBatch spriteBatch, Ball ball, Texture2D tex, Vector2 position, int points, ScoreBoard scoreBoard)
            : base(game)
        {
            // TODO: Construct any child components here
            this.spriteBatch = spriteBatch;
            this.ball = ball;
            this.tex = tex;
            this.position = position;
            this.points = points;
            this.scoreBoard = scoreBoard;

            hitSound = game.Content.Load<SoundEffect>("sounds/explode");


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
            Rectangle ballRect = ball.getBounds();

            Rectangle topFace = new Rectangle((int)position.X, (int)position.Y, tex.Width, 2);
            Rectangle leftFace = new Rectangle((int)position.X, (int)position.Y, 2, tex.Height);
            Rectangle rightFace = new Rectangle((int)position.X + tex.Width, (int)position.Y, 2, tex.Height);
            Rectangle bottomFace = new Rectangle((int)position.X, (int)position.Y + tex.Height, tex.Width, 2);

            if (ballRect.Intersects(topFace))
            {
                ball.Speed = new Vector2(ball.Speed.X, -Math.Abs(ball.Speed.Y));
                explosion = new Explosion(Game, spriteBatch, position);
                Game.Components.Add(explosion);
                hitSound.Play();
                this.Enabled = false;
                this.Visible = false;
                scoreBoard.Score += points;
            }
            else if (ballRect.Intersects(leftFace))
            {
                ball.Speed = new Vector2(-Math.Abs(ball.Speed.X), ball.Speed.Y);
                explosion = new Explosion(Game, spriteBatch, position);
                Game.Components.Add(explosion);
                hitSound.Play();
                this.Enabled = false;
                this.Visible = false;
                scoreBoard.Score += points;
            }
            else if (ballRect.Intersects(rightFace))
            {
                ball.Speed = new Vector2(Math.Abs(ball.Speed.X), ball.Speed.Y);
                explosion = new Explosion(Game, spriteBatch, position);
                Game.Components.Add(explosion);
                hitSound.Play();
                this.Enabled = false;
                this.Visible = false;
                scoreBoard.Score += points;
            }
            else if (ballRect.Intersects(bottomFace))
            {
                ball.Speed = new Vector2(ball.Speed.X, Math.Abs(ball.Speed.Y));
                explosion = new Explosion(Game, spriteBatch, position);
                Game.Components.Add(explosion);
                hitSound.Play();
                this.Enabled = false;
                this.Visible = false;
                scoreBoard.Score += points;
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
    }
}
