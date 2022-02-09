using Microsoft.Xna.Framework;
using System;

namespace PlatformerFNAEnvato
{
    public class AABB
    {
        public Vector2 Center;
        public Vector2 HalfSize;

        public AABB(Vector2 center, Vector2 halfSize)
        {
            Center = center;
            HalfSize = halfSize;
        }

        public bool Overlaps(AABB other)
        {
            if (Math.Abs(Center.X - other.Center.X) > (HalfSize.X + other.HalfSize.X))
                return false;

            if (Math.Abs(Center.Y - other.Center.Y) > (HalfSize.Y + other.HalfSize.Y))
                return false;

            return true;
        }
    }
}
