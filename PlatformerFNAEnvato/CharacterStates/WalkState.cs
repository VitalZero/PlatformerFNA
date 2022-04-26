using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PlatformerFNAEnvato.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerFNAEnvato.CharacterStates
{
    public class WalkState : IState
    {
        ICommand cmd;

        public void OnEnter(Character owner)
        {
        }

        public void OnExit(Character owner)
        {
        }

        public IState Update(Character owner, float dt)
        {
            //animationPlayer.Play("walk");
            if (owner.keyState.IsKeyDown(Keys.Right) == owner.keyState.IsKeyDown(Keys.Left))
            {
                return new StandState();
            }

            if (owner.keyState.IsKeyDown(Keys.Right))
            {
                if (owner.PushingRightWall)
                {
                    owner.Move(0, 0);
                }
                else
                {
                    owner.Move(owner.walkSpeed * dt, 0);
                }

                owner.flip = SpriteEffects.None;
            }
            else if (owner.keyState.IsKeyDown(Keys.Left))
            {
                if (owner.PushingLeftWall)
                {
                    owner.Move(0, 0);
                }
                else
                {
                    owner.Move(-owner.walkSpeed * dt, 0);
                }

                owner.flip = SpriteEffects.FlipHorizontally;
            }

            owner.Scale.X = Math.Abs(owner.Scale.X);


            if (owner.keyState.IsKeyDown(Keys.Space) || !owner.IsOnGround)
            {
                return new JumpState();
            }

            return null;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}
