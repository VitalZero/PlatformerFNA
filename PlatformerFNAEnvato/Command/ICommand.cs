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

    public class Move : ICommand
    {
        private Vector2 oldPos;
        private Vector2 offset;
        private Character owner;

        public Move(Character owner, Vector2 offset)
        {
            this.owner = owner;
            this.offset = offset;
        }

        public void Execute()
        {
            oldPos = owner.Pos;

            owner.Pos += offset;
        }
    }
}
