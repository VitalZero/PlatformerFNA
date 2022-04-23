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
        public void OnEnter(Character owner)
        {
            owner.Speed.Y = owner.jumpSpeed;
        }

        public void OnExit(Character owner)
        {
        }

        public IState Update(Character owner, float dt)
        {
            //animationPlayer.Play("jump")
            owner.Speed.Y += owner.gravity * dt;
            owner.Speed.Y = Math.Min(owner.Speed.Y, owner.MaxFallingSpeed);
            //owner.Accelerate(0, owner.gravity * dt);

            if (owner.keyState.IsKeyDown(Keys.Right) == owner.keyState.IsKeyDown(Keys.Left))
            {
                //owner.Move(0, 0);
                owner.Speed.X = 0f;
            }
            else if (owner.keyState.IsKeyDown(Keys.Right))
            {
                if (owner.PushingRightWall)
                {
                    //owner.Move(0, 0);
                    owner.Speed.X = 0f;
                }
                else
                {
                    //owner.Move(owner.WalkSpeed * dt, 0);
                    owner.Speed.X = owner.walkSpeed;
                }

                owner.Scale.X = Math.Abs(owner.Scale.X);
            }
            else if (owner.keyState.IsKeyDown(Keys.Left))
            {
                if (owner.PushingLeftWall)
                {
                    owner.Move(0, 0);
                    //owner.Speed.X = 0f;
                }
                else
                {
                    //owner.Move(-owner.WalkSpeed * dt, 0);
                    owner.Speed.X = -owner.walkSpeed;
                }
            }

            if (owner.IsOnGround)
            {
                if (owner.keyState.IsKeyDown(Keys.Right) == owner.keyState.IsKeyDown(Keys.Left))
                {
                    return new StandState();
                }
                else
                {
                    return new WalkState();
                }
            }

            return null;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}
