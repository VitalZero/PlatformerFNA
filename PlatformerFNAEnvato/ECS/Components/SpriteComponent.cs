using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerFNAEnvato.ECS
{
    public class SpriteComponent : Component
    {
        public Texture2D texture;

        public override void Receive(int message)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            TransformComponent t = entity.GetComponent<TransformComponent>();

            spriteBatch.Draw(texture, t.position, Color.White);
        }
    }
}
