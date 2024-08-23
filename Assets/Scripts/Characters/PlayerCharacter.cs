using Characters.Interfaces;
using Characters.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Characters
{
    public class PlayerCharacter : Character
    {
        public void Awake()
        {
            GameInput.Attacked.AddListener(OnAttacked);
            GameInput.MoveLeftStarted.AddListener(OnLeftMoveStarted);
            GameInput.MoveLeftEnded.AddListener(OnMoveEnded);
            GameInput.MoveRightStarted.AddListener(OnRightMoveStarted);
            GameInput.MoveRightEnded.AddListener(OnMoveEnded);
        }

        public void OnDisable()
        {
            GameInput.Attacked.RemoveListener(OnAttacked);
            GameInput.MoveLeftStarted.RemoveListener(OnLeftMoveStarted);
            GameInput.MoveLeftEnded.RemoveListener(OnMoveEnded);
            GameInput.MoveRightStarted.RemoveListener(OnRightMoveStarted);
            GameInput.MoveRightEnded.RemoveListener(OnMoveEnded);
        }

        public void OnAttacked()
        {
            Attack();
        }

        public void OnLeftMoveStarted()
        {
            if (StateMachine.CurrentState is not Walk walk)
            {
                StateMachine.Current = States.Enums.CharacterStateType.Walk;
                walk = StateMachine.CurrentState as Walk;
            }

            walk.Enter(true);
        }

        public void OnMoveEnded()
        {
            StateMachine.Current = States.Enums.CharacterStateType.Idle;
        }

        public void OnRightMoveStarted()
        {
            if (StateMachine.CurrentState is not Walk walk)
            {
                StateMachine.Current = States.Enums.CharacterStateType.Walk;
                walk = StateMachine.CurrentState as Walk;
            }

            walk.Enter(false);
        }
    }
}
