using PlatformerFNAEnvato.CharacterStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerFNAEnvato
{
    public class StateMachine
    {
        private IState currentState;
        private IState newState;
        private bool changing;

        public StateMachine()
        {
            changing = false;
        }

        public void ChangeState(IState state)
        {
            newState = state;
            changing = true;
        }

        public IState GetCurrentState()
        {
            return currentState;
        }

        public void ProcessStatechanges()
        {
            if (!changing)
                return;

            newState.OnExit();

            currentState = newState;
            newState = null;

            currentState.OnEnter();

            changing = false;
        }
    }
}
