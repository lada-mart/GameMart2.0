using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Net.Mime;

namespace GameMart
{
    public enum State
    {
        StartMenu,
        Levels,
        Game,
        Win,
        Lose
    }

    public enum MazeCells
    {
        Empty,
        Wall,
        TopSpickes,
        BottomSpickes,
        RightSpickes,
        LeftSpickes
    }
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;
        public static State state = State.StartMenu;
        public static ContentManager content;
        public static int[,] maze = new int[,]
        {
            {1, 1, 1, 1, 1, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4},
            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4},
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 3, 1},
        };

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 512;
            graphics.PreferredBackBufferHeight = 704;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            StartMenu._startGame = Content.Load<Texture2D>("StartGame");
            StartMenu._information = Content.Load<Texture2D>("Information");
            StartMenu._monkey = Content.Load<Texture2D>("Monkey");
            StartMenu._exit = Content.Load<Texture2D>("Exit");

            Levels._one = Content.Load<Texture2D>("1");
            Levels._two = Content.Load<Texture2D>("2");
            Levels._three = Content.Load<Texture2D>("3");
            Levels._four = Content.Load<Texture2D>("4");
            Levels._five = Content.Load<Texture2D>("5");
            Levels._six = Content.Load<Texture2D>("6");

            Levels._blocked_two = Content.Load<Texture2D>("blocked_2");
            Levels._blocked_three = Content.Load<Texture2D>("blocked_3");
            Levels._blocked_four = Content.Load<Texture2D>("blocked_4");
            Levels._blocked_five = Content.Load<Texture2D>("blocked_5");
            Levels._blocked_six = Content.Load<Texture2D>("blocked_6");

            Maze.ExitMaze = Content.Load<Texture2D>("Exit_maze");
            Maze.EmptySpace = Content.Load<Texture2D>("Empty_space");
            Maze.Wall = Content.Load<Texture2D>("Wall");
            Maze.BlockWall = Content.Load<Texture2D>("Block_wall");
            Maze.Teleport = Content.Load<Texture2D>("TeLeport");
            Maze.BottomSpickes = Content.Load<Texture2D>("B_Spickes");
            Maze.TopSpickes = Content.Load<Texture2D>("T_Spickes");
            Maze.LeftSpickes = Content.Load<Texture2D>("L_Spickes");
            Maze.RightSpickes = Content.Load<Texture2D>("R_Spickes");

            Lose._defeat = Content.Load<Texture2D>("Defeat");
            Lose._back = Content.Load<Texture2D>("Back");

            PlayerMovement._Player = Content.Load<Texture2D>("Player");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            switch (state)
            {
                case State.StartMenu:
                    if (MyButtons.EnterButton(StartMenu.exit)) spriteBatch.End();
                    else if (!MyButtons.EnterButton(StartMenu.startGame) && !MyButtons.isPressed)
                        state = State.StartMenu;
                    else state = State.Levels;
                    break;
                case State.Levels:
                    if (MyButtons.EnterButton(Levels.one))
                        state = State.Game;
                    break;
                case State.Game:
                    PlayerMovement.MovementHero();
                    if (PlayerMovement.death)
                        state = State.Lose;
                    break;

            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.PeachPuff);
            spriteBatch.Begin();
            switch (state)
            {
                case State.StartMenu:
                    StartMenu.DrawMenu(spriteBatch);
                    break;
                case State.Levels:
                    Levels.DrawLevels(spriteBatch);
                    break;
                case State.Game:
                    
                    for (int i = 0; i < maze.GetLength(0); i++)
                    {
                        for (int j = 0; j < maze.GetLength(1); j++)
                        {
                            int cellV = maze[i, j];
                            if (cellV == (int)MazeCells.Empty)
                            {
                                Rectangle rect = new Rectangle(j * 32, i * 32, 32, 32);
                                spriteBatch.Draw(Maze.EmptySpace, rect, Color.White);
                            }
                            else  if (cellV == (int)MazeCells.Wall)
                            {
                                Rectangle rect = new Rectangle(j * 32, i * 32, 32, 32);
                                Maze.Walls.Add(rect);
                                spriteBatch.Draw(Maze.Wall, rect, Color.White);
                            }
                            else if (cellV == (int)MazeCells.TopSpickes)
                            {
                                Maze.TopSpickesRect = new Rectangle(j * 32, i * 32, 32, 32);
                                spriteBatch.Draw(Maze.TopSpickes, Maze.TopSpickesRect, Color.White);
                            }
                            else if (cellV == (int)MazeCells.BottomSpickes)
                            {
                                Maze.BottomSpickesRect = new Rectangle(j * 32, i * 32, 32, 32);
                                spriteBatch.Draw(Maze.BottomSpickes, Maze.BottomSpickesRect, Color.White);
                            }
                            else if (cellV == (int)MazeCells.RightSpickes)
                            {
                                Maze.RightSpickesRect = new Rectangle(j * 32, i * 32, 32, 32);
                                spriteBatch.Draw(Maze.RightSpickes, Maze.RightSpickesRect, Color.White);
                            }
                        }
                    }
                    Maze.DrawMaze(spriteBatch);
                    PlayerMovement.DrawPlayer(spriteBatch);
                    
                    break;
                case State.Lose:
                    Lose.DrawLose(spriteBatch);
                    break;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}