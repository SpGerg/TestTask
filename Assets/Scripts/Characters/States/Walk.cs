using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Characters.States
{
    public class Walk : State
    {
        public Walk(CharacterStateMachine stateMachine) : base(stateMachine)
        {
        }

        public bool IsBackward { get; private set; }

        public override void Enter()
        {
            Character.Animator.SetBool("IsMoveForward", true);
        }

        public void Enter(bool isBackward)
        {
            IsBackward = isBackward;

            //Character.Animator.SetBool("IsMoveBackward", isBackward);
            Character.Animator.SetBool("IsMoveForward", true);

            if (isBackward)
            {
                Character.Model.transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else
            {
                Character.Model.transform.rotation = Quaternion.Euler(0, 270, 0);
            }
        }

        public override void Exit()
        {
            //Character.Animator.SetBool("IsMoveBackward", false);
            Character.Animator.SetBool("IsMoveForward", false);
        }
    }
}
