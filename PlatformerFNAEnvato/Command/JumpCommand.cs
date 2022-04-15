using PlatformerFNAEnvato.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerFNAEnvato
{
    class JumpCommand : ICommand
    {
        public override void Execute(Character owner)
        {
            owner.currentState = Character.CharacterState.Jump;
            owner.Speed.Y = owner.jumpSpeed;
        }
    }
}
