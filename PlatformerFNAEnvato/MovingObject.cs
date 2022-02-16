using Microsoft.Xna.Framework;
using System;

namespace PlatformerFNAEnvato
{
    public class MovingObject
    {
        public Vector2 OldPos;
        public Vector2 Pos;
        public AABB Aabb;
        public Vector2 Speed;
        public Vector2 Scale;
        public Vector2 AabbOffset;
        public Vector2 OldSpeed;

        public bool PushedRightWall;
        public bool PushingRightWall;
        public bool PushedLeftWall;
        public bool PushingLeftWall;
        public bool WasOnGround;
        public bool IsOnGround;
        public bool WasAtCeiling;
        public bool IsAtCeiling;

        public void UpdatePhysics(GameTime gameTime)
        {
            OldPos = Pos;
            OldSpeed = Speed;
            PushedLeftWall = PushingLeftWall;
            PushedRightWall = PushingRightWall;
            WasOnGround = IsOnGround;
            WasAtCeiling = IsAtCeiling;

            Pos += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(Pos.Y >= 220f)
            {
                Pos.Y = 220f;
                IsOnGround = true;
            }
            else
            {
                IsOnGround = false;
            }

            Aabb.Center = Pos + AabbOffset;
            Pos = new Vector2((float)Math.Round(Pos.X), (float)Math.Round(Pos.Y));
        }
    }
}
