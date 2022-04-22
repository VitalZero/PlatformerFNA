using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PlatformerFNAEnvato.CharacterStates;

namespace PlatformerFNAEnvato
{
    public class StandState : IState
    {
        public void OnEnter(Character owner)
        {
            owner.Speed = Vector2.Zero;
        }

        public void OnExit(Character owner)
        {
        }

        public IState Update(Character owner, float dt)
        {
            if (!owner.IsOnGround)
            {
                return new JumpState();
            }

            if (owner.keyState.IsKeyDown(Keys.Right) != owner.keyState.IsKeyDown(Keys.Left))
            {
                return new WalkState();
            }
            else if (owner.keyState.IsKeyDown(Keys.Space))
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
