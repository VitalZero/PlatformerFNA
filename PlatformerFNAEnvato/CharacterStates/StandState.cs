using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PlatformerFNAEnvato.CharacterStates;

namespace PlatformerFNAEnvato
{
    public class StandState : IState
    {
        private Character owner;

        public StandState(Character owner)
        {
            this.owner = owner;
        }

        public void OnEnter()
        {
            owner.Speed = Vector2.Zero;
        }

        public void OnExit()
        {
        }

        public void Update(float dt)
        {
            if (!owner.IsOnGround)
            {
                owner.machine.ChangeState(owner.jumpState);
                return;
            }

            if (owner.keyState.IsKeyDown(Keys.Right) != owner.keyState.IsKeyDown(Keys.Left))
            {
                owner.machine.ChangeState(owner.walkState);
                return;
            }
            else if (owner.keyState.IsKeyDown(Keys.Space))
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
