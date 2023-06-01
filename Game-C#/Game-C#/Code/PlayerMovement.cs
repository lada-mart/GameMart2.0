using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.Linq;

namespace GameMart
{
    public static class PlayerMovement
    {
        public static Texture2D _Player;
        public static Vector2 position;
        public static Rectangle colliderPlayer;
        private static int speed = 10;
        public static bool death;

        private static Vector2 direction;
        private static bool stop;

        static PlayerMovement()
        {
            StayHero();
        }

        public static void StayHero()
        {
            death = false;
            position = new Vector2(32, 608);
            direction = new Vector2(0, 0);
            colliderPlayer = new((int)position.X, (int)position.Y, 64, 64);
            stop = false;
        }

        public static void MovementHero()
        {
            KeyboardState keyboardState = Keyboard.GetState();

            colliderPlayer.Location = position.ToPoint();
            PlayerDeath();
            Collision();

            if (!stop && direction != Vector2.Zero)
            {
                position += direction;
                return;
            }
            else if(stop)
            {
                direction = Vector2.Zero;
            }

            if (keyboardState.IsKeyDown(Keys.Left))
                direction = new Vector2(-speed, 0);
            else if (keyboardState.IsKeyDown(Keys.Right))
                direction = new Vector2(speed, 0);
            else if (keyboardState.IsKeyDown(Keys.Up))
                direction = new Vector2(0, -speed);
            else if (keyboardState.IsKeyDown(Keys.Down))
                direction = new Vector2(0, speed);
        }

        public static void PlayerDeath()
        {
            if (colliderPlayer.Intersects(Maze.TopSpickesRect)
                || colliderPlayer.Intersects(Maze.BottomSpickesRect)
                || colliderPlayer.Intersects(Maze.LeftSpickesRect)
                || colliderPlayer.Intersects(Maze.RightSpickesRect))
            {
                death = true;
                Game1.state = State.Lose;
            }
        }
        
        public static void DrawPlayer(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_Player, position, Color.White);
        }

        private static void Collision()
        {
            var leftRect = new Rectangle(
                (int)position.X, (int)(position.Y + _Player.Height / 4), 
                _Player.Width / 4, _Player.Height / 2);
            var rightRect = new Rectangle(
                (int)position.X + _Player.Width - leftRect.Width, leftRect.Y, 
                leftRect.Width, leftRect.Height);
            var upRect = new Rectangle(
                (int)position.X + _Player.Width/4, (int)position.Y,
                _Player.Width / 2, _Player.Height / 4);
            var downRect = new Rectangle(
                upRect.X, upRect.Y + _Player.Height - upRect.Height, 
                upRect.Width, upRect.Height);

            var haveCollision = false;

            foreach (var wall in Maze.Walls)
            {
                if (leftRect.Intersects(wall))
                {
                    position.X = wall.X + wall.Width;
                    haveCollision = true;
                }
                else if (rightRect.Intersects(wall))
                {
                    position.X = wall.X - _Player.Width;
                    haveCollision = true;
                }
                else if (upRect.Intersects(wall))
                {
                    position.Y = wall.Y + wall.Height;
                    haveCollision = true;
                }
                else if (downRect.Intersects(wall))
                {
                    position.Y = wall.Y - _Player.Height;
                    haveCollision = true;
                }
            }

            stop = haveCollision;
            var posChenged = false;

            foreach (var teleport in Maze.Teleports)
            {
                if (colliderPlayer.Intersects(teleport.Rect))
                {

                    if (!teleport.Enter)
                    {
                        position = teleport.SecondTeleport.Rect.Location.ToVector2();
                        teleport.SecondTeleport.Enter = true;
                        posChenged = true;
                    }

                    teleport.Enter = true;
                }
                else if(!posChenged)
                {
                    teleport.Enter = false;
                }
            }
        }
    }
}
