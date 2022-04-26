using Microsoft.Xna.Framework;
using System;

namespace PlatformerFNAEnvato
{
    public class MovingObject
    {
        protected Vector2 OldPos;
        public Vector2 Pos;
        public AABB Aabb;
        public Vector2 Speed;
        public Vector2 Scale;
        protected Vector2 AabbOffset;
        protected Vector2 OldSpeed;

        public bool PushedRightWall;
        public bool PushingRightWall;
        public bool PushedLeftWall;
        public bool PushingLeftWall;
        public bool WasOnGround;
        public bool IsOnGround;
        public bool WasAtCeiling;
        public bool IsAtCeiling;
        public float MaxFallingSpeed { get { return 900f; } }
        public float Gravity { get { return gravity; } }
        protected float gravity;

        public void Move(Vector2 velocity)
        {
            Move(velocity.X, velocity.Y);
        }

        public void Move(float x, float y)
        {
            OldPos = Pos;

            Pos.X += x;
            Pos.Y += y;
        }

        protected void UpdatePhysics(GameTime gameTime)
        {
            //OldPos = Pos;
            //OldSpeed = Speed;
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
