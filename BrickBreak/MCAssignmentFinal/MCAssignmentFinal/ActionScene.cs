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
    public class ActionScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private Bat bat;
        private Ball ball;
        private Box box1;
        private Box box2;
        private Box box3;
        private Box box4;
        private Box box5;
        private Box box6;
        private Box box7;
        private Box box8;
        private Box box9;
        private Box box10;
        private Box box11;
        private Box box12;
        private Box box13;
        private Box box14;
        private Box box15;
        private Box box16;
        private Box box17;
        private Box box18;
        private Box box19;
        private Box box20;
        private Box box21;
        private Box box22;
        private Box box23;
        private Box box24;
        private Box box25;
        private Box box26;
        private Box box27;
        private Box box28;
        private Box box29;
        private Box box30;
        private CollisionDetection collisionDetection;
        private Vector2 stage;
        private ScoreBoard scoreBoard;
        SoundEffect wallBounce;

        bool loseSoundPlayed;

        public bool LoseSoundPlayed
        {
            get { return loseSoundPlayed; }
            set { loseSoundPlayed = value; }
        }
        bool winSoundPlayed;

        public bool WinSoundPlayed
        {
            get { return winSoundPlayed; }
            set { winSoundPlayed = value; }
        }

        public ActionScene(Game game, SpriteBatch spriteBatch, Vector2 stage)
            : base(game)
        {
            // TODO: Construct any child components here
            this.spriteBatch = spriteBatch;

            wallBounce = Game.Content.Load<SoundEffect>("sounds/click");

            this.stage = stage;

            bat = new Bat(game, spriteBatch, game.Content.Load<Texture2D>("images/bat"));
            this.Components.Add(bat);

            scoreBoard = new ScoreBoard(game, spriteBatch,game.Content.Load<SpriteFont>("fonts/scoreBoardFont"), bat);
            this.Components.Add(scoreBoard);

            ball = new Ball(game, spriteBatch, game.Content.Load<Texture2D>("images/ball"), new Vector2(stage.X / 2, stage.Y - 150), new Vector2(0, 0), Shared.stage, scoreBoard, this, wallBounce);
            this.Components.Add(ball);

            box1 = new Box(game, spriteBatch, ball, game.Content.Load<Texture2D>("images/box"), new Vector2(100, 100), 10, scoreBoard);
            this.Components.Add(box1);

            box2 = new Box(game, spriteBatch, ball, game.Content.Load<Texture2D>("images/box"), new Vector2(160, 100), 10, scoreBoard);
            this.Components.Add(box2);

            box3 = new Box(game, spriteBatch, ball, game.Content.Load<Texture2D>("images/box"), new Vector2(220, 100), 10, scoreBoard);
            this.Components.Add(box3);

            box4 = new Box(game, spriteBatch, ball, game.Content.Load<Texture2D>("images/box"), new Vector2(280, 100), 10, scoreBoard);
            this.Components.Add(box4);

            box5 = new Box(game, spriteBatch, ball, game.Content.Load<Texture2D>("images/box"), new Vector2(340, 100), 10, scoreBoard);
            this.Components.Add(box5);

            box6 = new Box(game, spriteBatch, ball, game.Content.Load<Texture2D>("images/box"), new Vector2(400, 100), 10, scoreBoard);
            this.Components.Add(box6);

            box7 = new Box(game, spriteBatch, ball, game.Content.Load<Texture2D>("images/box"), new Vector2(460, 100), 10, scoreBoard);
            this.Components.Add(box7);

            box8 = new Box(game, spriteBatch, ball, game.Content.Load<Texture2D>("images/box"), new Vector2(520, 100), 10, scoreBoard);
            this.Components.Add(box8);

            box9 = new Box(game, spriteBatch, ball, game.Content.Load<Texture2D>("images/box"), new Vector2(580, 100), 10, scoreBoard);
            this.Components.Add(box9);

            box10 = new Box(game, spriteBatch, ball, game.Content.Load<Texture2D>("images/box"), new Vector2(640, 100), 10, scoreBoard);
            this.Components.Add(box10);

            box11 = new Box(game, spriteBatch, ball, game.Content.Load<Texture2D>("images/box"), new Vector2(100, 125), 10, scoreBoard);
            this.Components.Add(box11);

            box12 = new Box(game, spriteBatch, ball, game.Content.Load<Texture2D>("images/box"), new Vector2(160, 125), 10, scoreBoard);
            this.Components.Add(box12);

            box13 = new Box(game, spriteBatch, ball, game.Content.Load<Texture2D>("images/box"), new Vector2(220, 125), 10, scoreBoard);
            this.Components.Add(box13);

            box14 = new Box(game, spriteBatch, ball, game.Content.Load<Texture2D>("images/box"), new Vector2(280, 125), 10, scoreBoard);
            this.Components.Add(box14);

            box15 = new Box(game, spriteBatch, ball, game.Content.Load<Texture2D>("images/box"), new Vector2(340, 125), 10, scoreBoard);
            this.Components.Add(box15);

            box16 = new Box(game, spriteBatch, ball, game.Content.Load<Texture2D>("images/box"), new Vector2(400, 125), 10, scoreBoard);
            this.Components.Add(box16);

            box17 = new Box(game, spriteBatch, ball, game.Content.Load<Texture2D>("images/box"), new Vector2(460, 125), 10, scoreBoard);
            this.Components.Add(box17);

            box18 = new Box(game, spriteBatch, ball, game.Content.Load<Texture2D>("images/box"), new Vector2(520, 125), 10, scoreBoard);
            this.Components.Add(box18);

            box19 = new Box(game, spriteBatch, ball, game.Content.Load<Texture2D>("images/box"), new Vector2(580, 125), 10, scoreBoard);
            this.Components.Add(box19);

            box20 = new Box(game, spriteBatch, ball, game.Content.Load<Texture2D>("images/box"), new Vector2(640, 125), 10, scoreBoard);
            this.Components.Add(box20);

            box21 = new Box(game, spriteBatch, ball, game.Content.Load<Texture2D>("images/box"), new Vector2(100, 150), 10, scoreBoard);
            this.Components.Add(box21);

            box22 = new Box(game, spriteBatch, ball, game.Content.Load<Texture2D>("images/box"), new Vector2(160, 150), 10, scoreBoard);
            this.Components.Add(box22);

            box23 = new Box(game, spriteBatch, ball, game.Content.Load<Texture2D>("images/box"), new Vector2(220, 150), 10, scoreBoard);
            this.Components.Add(box23);

            box24 = new Box(game, spriteBatch, ball, game.Content.Load<Texture2D>("images/box"), new Vector2(280, 150), 10, scoreBoard);
            this.Components.Add(box24);

            box25 = new Box(game, spriteBatch, ball, game.Content.Load<Texture2D>("images/box"), new Vector2(340, 150), 10, scoreBoard);
            this.Components.Add(box25);

            box26 = new Box(game, spriteBatch, ball, game.Content.Load<Texture2D>("images/box"), new Vector2(400, 150), 10, scoreBoard);
            this.Components.Add(box26);

            box27 = new Box(game, spriteBatch, ball, game.Content.Load<Texture2D>("images/box"), new Vector2(460, 150), 10, scoreBoard);
            this.Components.Add(box27);

            box28 = new Box(game, spriteBatch, ball, game.Content.Load<Texture2D>("images/box"), new Vector2(520, 150), 10, scoreBoard);
            this.Components.Add(box28);

            box29 = new Box(game, spriteBatch, ball, game.Content.Load<Texture2D>("images/box"), new Vector2(580, 150), 10, scoreBoard);
            this.Components.Add(box29);

            box30 = new Box(game, spriteBatch, ball, game.Content.Load<Texture2D>("images/box"), new Vector2(640, 150), 10, scoreBoard);
            this.Components.Add(box30);



            collisionDetection = new CollisionDetection(game, ball, bat);
            this.Components.Add(collisionDetection);


        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            loseSoundPlayed = false;
            winSoundPlayed = false;

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

            Box b = null;

            if (ks.IsKeyDown(Keys.Enter))
            {
                if (ball.Enabled == false && bat.Enabled == false)
                {
                    scoreBoard.Score = 0;
                    scoreBoard.Lives = 3;
                    MediaPlayer.Resume();

                    foreach (GameComponent item in this.Components)
                    {
                        if (item is Box)
                        {
                            b = (Box)item;
                            b.Enabled = true;
                            b.Visible = true;
                        }
                    }

                    ball.Enabled = true;
                    bat.Enabled = true;
                    ball.Speed = new Vector2(0, 0);
                    ball.Position = new Vector2(stage.X / 2, stage.Y - 150);

                    loseSoundPlayed = false;
                    winSoundPlayed = false;
                } 
            }

            bool allDestroyed = false;
            b = null;
            foreach (GameComponent item in this.Components)
            {
                if (item is Box)
                {
                    b = (Box)item;
                    if (scoreBoard.Lives <= 0)
                    {
                        b.Enabled = true;
                        b.Visible = true;
                        
                        if(loseSoundPlayed == false)
                        {
                            SoundEffect loseSound = Game.Content.Load<SoundEffect>("sounds/gameOver");
                            MediaPlayer.Pause();
                            loseSound.Play();
                            loseSoundPlayed = true;
                        }
                    }              
                }
            }

            b = null;
            foreach (GameComponent item in this.Components)
            {
                if (item is Box)
                {
                    b = (Box)item;
                    if (b.Visible == false)
                    {
                        allDestroyed = true;
                    }
                    else
                    {
                        allDestroyed = false;
                        break;
                    }  
                }
            } 

            if(allDestroyed)
            {
                if(winSoundPlayed == false)
                {
                    SoundEffect winSound = Game.Content.Load<SoundEffect>("sounds/winrar");
                    MediaPlayer.Pause();
                    winSound.Play();
                    winSoundPlayed = true;
                }
                ball.Enabled = false;
                bat.Enabled = false;
            }

            base.Update(gameTime);
        }
    }
}
