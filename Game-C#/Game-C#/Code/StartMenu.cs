using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameMart
{
    static class StartMenu
    {
        public static Texture2D _startGame;
        public static Texture2D _information;
        public static Texture2D _exit;
        public static Texture2D _monkey;
        public static Rectangle startGame = new Rectangle(32, 100, 448, 64);
        public static Rectangle information = new Rectangle(32, 214, 448, 64);
        public static Rectangle exit = new Rectangle(144, 328, 224, 64);
        static Rectangle monkey = new Rectangle(131, 460, 250, 230);

        public static void DrawMenu(SpriteBatch spriteBatch)
        {
                spriteBatch.Draw(_startGame, startGame, Color.White);
                spriteBatch.Draw(_information, information, Color.White);
                spriteBatch.Draw(_exit, exit, Color.White);
                spriteBatch.Draw(_monkey, monkey, Color.White);
        }
    }
}
