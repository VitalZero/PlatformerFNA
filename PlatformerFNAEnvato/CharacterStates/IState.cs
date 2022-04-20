using Microsoft.Xna.Framework.Graphics;

namespace PlatformerFNAEnvato.CharacterStates
{
    public interface IState
    {
        void OnEnter();
        void Update(float dt);
        void Draw(SpriteBatch spriteBatch);
        void OnExit();
    }
}
