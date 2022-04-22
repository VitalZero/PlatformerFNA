using Microsoft.Xna.Framework.Graphics;

namespace PlatformerFNAEnvato.CharacterStates
{
    public interface IState
    {
        void OnEnter(Character owner);
        IState Update(Character owner, float dt);
        void Draw(SpriteBatch spriteBatch);
        void OnExit(Character owner);
    }
}
