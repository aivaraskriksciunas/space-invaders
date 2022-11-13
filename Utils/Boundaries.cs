using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceInvaders.Utils
{
    class Boundaries
    {
        public float StartX { get; private set; }
        public float StartY { get; private set; }
        public float EndX { get; private set; }
        public float EndY { get; private set; }

        public Boundaries( float sx, float sy, float ex, float ey )
        {
            StartX = sx;
            StartY = sy;
            EndX = ex;
            EndY = ey;
        }

        public bool IsInside( float posX, float posY )
        {
            return (posX >= StartX && posX <= EndX) && (posY >= StartY && posY <= EndY);
        }

        public bool Overlaps( Boundaries bounds )
        {
            bool overlapX = Math.Min( bounds.EndX, EndX ) > Math.Max( bounds.StartX, StartX );
            bool overlapY = Math.Min( bounds.EndY, EndY ) > Math.Max( bounds.StartY, StartY );
            return overlapX && overlapY;
        }
    }
}
