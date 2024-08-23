using Characters.States;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Characters
{
    public class EnemyCharacter : Character
    {
        private PlayerCharacter _player;

        private Walk _walkState;

        private Attack _attackState;

        public void Awake()
        {
            _player = FindObjectOfType<PlayerCharacter>();

            StartCoroutine(LateAwakeCoroutine());
        }

        public void Update()
        {
            if (_walkState is null)
            {
                return;
            }

            if (Vector3.Distance(transform.position, _player.transform.position) > AttackRange)
            {
                StateMachine.Current = States.Enums.CharacterStateType.Walk;

                if (transform.position.x > _player.transform.position.x && _walkState.IsBackward)
                {
                    _walkState.Enter(false);
                }
                else if (transform.position.x < _player.transform.position.x && !_walkState.IsBackward)
                {
                    _walkState.Enter(true);
                }
            }
            else
            {
                StateMachine.Current = States.Enums.CharacterStateType.Attack;
                _attackState.Target = _player.Damageable;
            }
        }

        private IEnumerator LateAwakeCoroutine()
        {
            yield return new WaitForEndOfFrame();

            _walkState = StateMachine.States[States.Enums.CharacterStateType.Walk] as Walk;
            _attackState = StateMachine.States[States.Enums.CharacterStateType.Attack] as Attack;
        }
    }
}
