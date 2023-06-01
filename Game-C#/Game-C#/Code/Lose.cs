using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace GameMart
{
    static class Lose
    {
        public static Texture2D _defeat;
        public static Texture2D _back;

        public static Rectangle defeat = new Rectangle(111, 250, 290, 64);
        public static Rectangle back = new Rectangle(192, 400, 128, 128);

        public static void DrawLose(SpriteBatch spriteBatch)
        {
            if (PlayerMovement.death)
            {
                spriteBatch.Draw(_defeat, defeat, Color.White);
                spriteBatch.Draw(_back, back, Color.White);

                if (MyButtons.EnterButton(back))
                {
                    Game1.state = State.Game;
                    PlayerMovement.StayHero();
                }
            }
        }
    }
}
