using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameMart
{
    public static class Maze 
    {
        public static Texture2D ExitMaze;
        public static Texture2D EmptySpace;
        public static Texture2D Wall;
        public static Texture2D BlockWall;
        public static Texture2D Teleport;
        public static Texture2D BottomSpickes;
        public static Texture2D TopSpickes;
        public static Texture2D LeftSpickes;
        public static Texture2D RightSpickes;

        public static Rectangle Empty_space;
        public static List<Rectangle> Walls = new List<Rectangle>(); 
        public static Rectangle WallRect;
        public static List<Teleport> Teleports = new List<Teleport>();
        public static Rectangle BottomSpickesRect;
        public static Rectangle TopSpickesRect;
        public static Rectangle LeftSpickesRect;
        public static Rectangle RightSpickesRect;

        private static bool firstCreateTeleports = true;

        public static void DrawMaze(SpriteBatch spriteBatch)
        {
            var blockWall1 = new Rectangle(32, 352, 64, 64);
            var blockWall2 = new Rectangle(160, 544, 64, 64);
            var blockWall3 = new Rectangle(224, 160, 64, 64);
            var teleportRect1 = new Rectangle(32, 160, 64, 64);
            var teleportRect2 = new Rectangle(224, 416, 64, 64);
            var exitMaze = new Rectangle(416, 32, 64, 64);

            Maze.Walls.Add(blockWall1);
            Maze.Walls.Add(blockWall2);
            Maze.Walls.Add(blockWall3);

            spriteBatch.Draw(BlockWall, blockWall1, Color.White);
            spriteBatch.Draw(BlockWall, blockWall2, Color.White);
            spriteBatch.Draw(BlockWall, blockWall3, Color.White);
            spriteBatch.Draw(Teleport, teleportRect1, Color.White);
            spriteBatch.Draw(Teleport, teleportRect2, Color.White);
            spriteBatch.Draw(ExitMaze, exitMaze, Color.White);

            if (firstCreateTeleports)
            {
                var teleport1 = new Teleport(teleportRect1, null);
                var teleport2 = new Teleport(teleportRect2, teleport1);
                teleport1.SecondTeleport = teleport2;
                Maze.Teleports.Add(teleport1);
                Maze.Teleports.Add(teleport2);
                firstCreateTeleports = false;
            }
        }
    }
}
