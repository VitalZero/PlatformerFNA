using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerFNAEnvato.ECS
{
    public class VelocityComponent : Component
    {
        public Vector2 velocity = Vector2.Zero;
        public float walkSpeed = 10;
        public float jumpSpeed = -50;
        public float fallSpeed = 40;

        public override void Receive(int message)
        {
        }
    }
}
