using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerFNAEnvato.ECS
{
    public class InputComponent : Component
    {
        private KeyboardState kbdState = Keyboard.GetState();
   
        public override void Receive(int message)
        {
        }

        public override void Update(float dt)
        {
            KeyboardState oldState = kbdState;
            kbdState = Keyboard.GetState();

            VelocityComponent v = entity.GetComponent<VelocityComponent>();

            if(kbdState.IsKeyDown(Keys.Left) == kbdState.IsKeyDown(Keys.Right))
            {
                v.velocity.X = 0f;
            }
            else if(kbdState.IsKeyDown(Keys.Left))
            {
                v.velocity.X = -v.walkSpeed * dt;
            }
            else if (kbdState.IsKeyDown(Keys.Right))
            {
                v.velocity.X = v.walkSpeed * dt;
            }

            if (kbdState.IsKeyDown(Keys.Up) == kbdState.IsKeyDown(Keys.Down))
            {
                v.velocity.Y = 0f;
            }
            else if (kbdState.IsKeyDown(Keys.Up))
            {
                v.velocity.Y = -v.walkSpeed * dt;
            }
            else if (kbdState.IsKeyDown(Keys.Down))
            {
                v.velocity.Y = v.walkSpeed * dt;
            }

        }
    }
}
