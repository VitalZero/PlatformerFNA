using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerFNAEnvato.ECS
{
    public abstract class Component
    {
        public Entity entity;
        public virtual void Update(float dt) { }
        public virtual void Draw(SpriteBatch spriteBatch) { }
        public abstract void Receive(int message);
    }
}
