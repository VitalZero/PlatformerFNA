﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerFNAEnvato.CharacterStates
{
    public class WalkState : IState
    {
        private Character owner;

        public WalkState(Character owner)
        {
            this.owner = owner;
        }

        public void OnEnter()
        {
        }

        public void OnExit()
        {
        }

        public void Update(float dt)
        {
            //animationPlayer.Play("walk");
            if (owner.keyState.IsKeyDown(Keys.Right) == owner.keyState.IsKeyDown(Keys.Left))
            {
                owner.machine.ChangeState(owner.standState);
                return;
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

            if (owner.keyState.IsKeyDown(Keys.Space))
            {
                owner.machine.ChangeState(owner.jumpState);
                return;
            }
            else if (!owner.IsOnGround)
            {
                owner.machine.ChangeState(owner.jumpState);
                return;
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