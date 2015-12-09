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
    public class Ball : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 position;
        private ActionScene actionScene;
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        private Vector2 speed;
        private ScoreBoard scoreBoard;
        private SoundEffect wallBounce;
        public Vector2 Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        private Vector2 stage;
        public Ball(Game game, SpriteBatch spriteBatch, Texture2D tex, Vector2 position, Vector2 speed, Vector2 stage, ScoreBoard scoreBoard, ActionScene actionScene, SoundEffect wallBounce)
            : base(game)
        {
            // TODO: Construct any child components here
            this.tex = tex;
            this.spriteBatch = spriteBatch;
            this.wallBounce = wallBounce;
            this.position = position;
            this.speed = speed;
            this.stage = stage;
            this.scoreBoard = scoreBoard;
            this.actionScene = actionScene;
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
            Random r = new Random();

            if (scoreBoard.Lives <= 0)
            {
                speed = new Vector2(0, 0);
                position = new Vector2(stage.X / 2, stage.Y - 150);

                if(ks.IsKeyDown(Keys.Enter))
                {
                    scoreBoard.Lives = 3;
                    scoreBoard.Score = 0;
                    actionScene.LoseSoundPlayed = false;
                    actionScene.WinSoundPlayed = false;
                    MediaPlayer.Resume();
                }
            }

            if (speed.X == 0 && speed.Y == 0)
            {
                if (ks.IsKeyDown(Keys.Space))
                {
                    if (r.Next(0,2) == 1)
                    {
                        speed.X = r.Next(2,5);
                    }
                    else
                    {
                        speed.X = r.Next(-5, -2);
                    }

                    if (r.Next(0, 2) == 1)
                    {
                        speed.Y = r.Next(2, 5);
                    }
                    else
                    {
                        speed.Y = r.Next(-5, -2);
                    }
                }
            }
            if (scoreBoard.Lives > 0)
            {
                position += speed;
            }

            if (position.Y > stage.Y)
            {
                scoreBoard.Lives--;
                speed = new Vector2(0, 0);
                position = new Vector2(stage.X / 2, stage.Y - 150);
            }            

            if (position.X < 0)
            {
                wallBounce.Play();
                speed.X = Math.Abs(speed.X);
            }

            if (position.X > stage.X - tex.Height)
            {
                wallBounce.Play();
                speed.X = -Math.Abs(speed.X);
            }

            if (position.Y < 0)
            {
                wallBounce.Play();
                speed.Y = Math.Abs(speed.Y);
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
