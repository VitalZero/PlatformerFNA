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
                    owner.Speed.X = 0f;
                }
                else
                {
                    owner.Speed.X = owner.walkSpeed;
                }

                owner.Scale.X = -Math.Abs(owner.Scale.X);
                owner.flip = SpriteEffects.None;
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

                owner.Scale.X = Math.Abs(owner.Scale.X);
                owner.flip = SpriteEffects.FlipHorizontally;
            }

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
