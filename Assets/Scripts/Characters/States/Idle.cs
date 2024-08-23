using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Characters.States
{
    public class Idle : State
    {
        public Idle(CharacterStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            Character.Animator.SetBool("IsIdle", true);
        }

        public override void Exit()
        {
            Character.Animator.SetBool("IsIdle", false);
        }
    }
}
