using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerFNAEnvato.Command
{
    interface ICommand
    {
        void Execute();
    }

    public class MoveCommand : ICommand
    {
        private Vector2 oldPos;
        private Vector2 velocity;
        private Character owner;

        public MoveCommand(Character owner, Vector2 velocity)
        {
            this.owner = owner;
            this.velocity = velocity;
        }

        public void Execute()
        {
            oldPos = owner.Pos;

            owner.Move(velocity);
        }
    }
}
