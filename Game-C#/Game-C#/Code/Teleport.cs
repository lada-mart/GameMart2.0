using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameMart
{
    public class Teleport
    {
        public readonly Rectangle Rect;
        public Teleport SecondTeleport;
        public bool Enter = false;
        public Teleport(Rectangle rect, Teleport second) 
        { 
            Rect = rect;
            SecondTeleport = second;
        }
    }
}
