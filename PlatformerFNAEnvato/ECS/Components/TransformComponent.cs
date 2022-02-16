using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerFNAEnvato.ECS
{
    public class TransformComponent : Component
    {
        public Vector2 position = Vector2.Zero;
        public Vector2 oldPosition = Vector2.Zero;
        public Vector2 scale = Vector2.Zero;

        public override void Receive(int message)
        {
        }

        public override void Update(float dt)
        {
            oldPosition = position;
        }
    }
}
