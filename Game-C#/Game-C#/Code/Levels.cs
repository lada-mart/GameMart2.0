using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Net.Mime.MediaTypeNames;

namespace GameMart
{
    internal class Levels
    {
        #region picturesOfLevels
        public static Texture2D _one;
        public static Texture2D _two;
        public static Texture2D _three;
        public static Texture2D _four;
        public static Texture2D _five;
        public static Texture2D _six;
        public static Texture2D _blocked_two;
        public static Texture2D _blocked_three;
        public static Texture2D _blocked_four;
        public static Texture2D _blocked_five;
        public static Texture2D _blocked_six;
        public static Rectangle one = new Rectangle(80, 248, 64, 64);
        static Rectangle two = new Rectangle(224, 248, 64, 64);
        static Rectangle three = new Rectangle(368, 248, 64, 64);
        static Rectangle four = new Rectangle(80, 392, 64, 64);
        static Rectangle five = new Rectangle(224, 392, 64, 64);
        static Rectangle six = new Rectangle(368, 392, 64, 64);
        static Rectangle blocked_two = new Rectangle(224, 248, 64, 64);
        static Rectangle blocked_three = new Rectangle(368, 248, 64, 64);
        static Rectangle blocked_four = new Rectangle(80, 392, 64, 64);
        static Rectangle blocked_five = new Rectangle(224, 392, 64, 64);
        static Rectangle blocked_six = new Rectangle(368, 392, 64, 64);
        #endregion

        public static void DrawLevels(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_one, one, Color.White);
            spriteBatch.Draw(_blocked_two, blocked_two, Color.White);
            spriteBatch.Draw(_blocked_three, blocked_three, Color.White);
            spriteBatch.Draw(_blocked_four, blocked_four, Color.White);
            spriteBatch.Draw(_blocked_five, blocked_five, Color.White);
            spriteBatch.Draw(_blocked_six, blocked_six, Color.White);
        }
    }
}
