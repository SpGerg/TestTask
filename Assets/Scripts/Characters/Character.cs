using Characters;
using Characters.Interfaces;
using Characters.States;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BasicHealth), typeof(CharacterStateMachine))]
public abstract class Character : MonoBehaviour
{
    public UnityEvent AttackAnimationEnded { get; } = new();

    public CharacterStateMachine StateMachine => _stateMachine;

    public Animator Animator => _animator;

    public IDamageable Damageable => damageable;

    public GameObject Model => _model;

    public Transform RaycastPosition => _rayCastPosition;

    public int AttackDamage => _attackDamage;

    public const float AttackRange = 5.5f;

    [SerializeField]
    private int _attackDamage;

    [SerializeField]
    private CharacterStateMachine _stateMachine;

    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private BasicHealth damageable;

    [SerializeField]
    private Transform _rayCastPosition;

    [SerializeField]
    private GameObject _model;

    public void Start()
    {
        StateMachine.Current = Characters.States.Enums.CharacterStateType.Idle;
    }

    public void Attack()
    {
        StateMachine.Current = Characters.States.Enums.CharacterStateType.Attack;
    }

    public void InvokeEventOnAttackAnimation()
    {
        AttackAnimationEnded.Invoke();
    }
}
