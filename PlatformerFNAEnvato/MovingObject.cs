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
        private Vector2 Accel;

        public bool PushedRightWall;
        public bool PushingRightWall;
        public bool PushedLeftWall;
        public bool PushingLeftWall;
        public bool WasOnGround;
        public bool IsOnGround;
        public bool WasAtCeiling;
        public bool IsAtCeiling;
        public float MaxFallingSpeed { get { return 900f; } }

        public void Move(Vector2 velocity)
        {
            Move(velocity.X, velocity.Y);
        }

        public void Move(float x, float y)
        {
            Pos.X += x;
            Pos.Y += y;
        }

        public void Accelerate(Vector2 acceleration)
        {
            Accelerate(acceleration.X, acceleration.Y);
        }

        public void Accelerate(float x, float y)
        {
            Accel.X = x;
            Accel.Y = y;
        }

        public void UpdatePhysics(GameTime gameTime)
        {
            Speed += Accel;
            Accel = Vector2.Zero;

            Speed.Y = MathHelper.Clamp(Speed.Y, -MaxFallingSpeed, MaxFallingSpeed);

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
