using Microsoft.Xna.Framework;
using System;

namespace PlatformerFNAEnvato.ECS
{
    public class PhysicsComponent : Component
    {
        public float gravity;

        public override void Receive(int message)
        {
        }

        public override void Update(float dt)
        {
            TransformComponent t = entity.GetComponent<TransformComponent>();
            VelocityComponent v = entity.GetComponent<VelocityComponent>();

            t.position += v.velocity;
        }
    }
}
