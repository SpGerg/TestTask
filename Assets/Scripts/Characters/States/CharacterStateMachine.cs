using Characters.States.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Characters.States
{
    public class CharacterStateMachine : MonoBehaviour
    {
        public Character Character { get; private set; }

        public Animator Animator => Character.Animator;

        public IReadOnlyDictionary<CharacterStateType, State> States => _states;

        public CharacterStateType Current
        {
            get
            {
                return _current;
            }
            set
            {
                if (_current == value)
                {
                    return;
                }

                if (_currentState != null)
                {
                    _currentState.Exit();
                }

                _current = value;
                _currentState = _states[value];
                _currentState.Enter();
            }
        }

        public State CurrentState => _currentState;

        [SerializeField]
        private Character _character;

        [SerializeField]
        private CharacterStateType _current;

        private State _currentState;

        private Dictionary<CharacterStateType, State> _states;

        public void Awake()
        {
            Character = _character;

            _states = new Dictionary<CharacterStateType, State>()
            {
                { CharacterStateType.Idle, new Idle(this) },
                { CharacterStateType.Attack, new Attack(this) },
                { CharacterStateType.Walk, new Walk(this) },
            };

            Current = CharacterStateType.Idle;
        }

        public void OnDisable()
        {
            Current = CharacterStateType.Idle;
        }
    }
}
