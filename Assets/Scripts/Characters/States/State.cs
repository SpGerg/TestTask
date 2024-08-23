using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Characters.States
{
    public abstract class State
    {
        public Character Character => StateMachine.Character;

        public State(CharacterStateMachine stateMachine)
        {
            StateMachine = stateMachine;
        }

        public CharacterStateMachine StateMachine { get; }

        public virtual void Enter() { }

        public virtual void Update() { }

        public virtual void Exit() { }
    }
}
