using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerFNAEnvato.CharacterStates
{
    public class JumpState : IState
    {
        private Character owner;

        public JumpState(Character owner)
        {
            this.owner = owner;
        }

        public void OnEnter()
        {
            owner.Speed.Y = owner.jumpSpeed;
        }

        public void OnExit()
        {
        }

        public void Update(float dt)
        {
            //animationPlayer.Play("jump")
            owner.Speed.Y += owner.gravity * dt;
            owner.Speed.Y = Math.Min(owner.Speed.Y, owner.MaxFallingSpeed);

            if (owner.keyState.IsKeyDown(Keys.Right) == owner.keyState.IsKeyDown(Keys.Left))
            {
                owner.Speed.X = 0f;
            }
            else if (owner.keyState.IsKeyDown(Keys.Right))
            {
                if (owner.PushingRightWall)
                {
                    owner.Speed.X = 0f;
                }
                else
                {
                    owner.Speed.X = owner.walkSpeed;
                }

                owner.Scale.X = Math.Abs(owner.Scale.X);
            }
            else if (owner.keyState.IsKeyDown(Keys.Left))
            {
                if (owner.PushingLeftWall)
                {
                    owner.Speed.X = 0f;
                }
                else
                {
                    owner.Speed.X = -owner.walkSpeed;
                }
            }

            if (owner.IsOnGround)
            {
                if (owner.keyState.IsKeyDown(Keys.Right) == owner.keyState.IsKeyDown(Keys.Left))
                {
                    owner.machine.ChangeState(owner.walkState);
                }
                else
                {
                    owner.machine.ChangeState(owner.walkState);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(owner.texture,
                owner.Pos,
                null,
                Color.White,
                0f,
                owner.Aabb.HalfSize,
                1f,
                owner.flip,
                0f);//new Rectangle((int)Pos.X, (int)Pos.Y, (int)size.X, (int)size.Y), Color.Red);
        }
    }
}
