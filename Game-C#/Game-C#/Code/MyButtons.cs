using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameMart
{
    public class MyButtons
    {
        public static bool isPressed;
        static public bool EnterButton(Rectangle button)
        {
            MouseState currentMouseState = Mouse.GetState();

            if (currentMouseState.LeftButton == ButtonState.Pressed
                && button.Contains(currentMouseState.X, currentMouseState.Y))
            {
                isPressed = true;
                return true;
            }
            return false;
        }
    }
}
