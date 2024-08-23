using Characters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace Characters.States
{
    public class Attack : State
    {
        public Attack(CharacterStateMachine stateMachine) : base(stateMachine)
        {
        }

        public IDamageable Target { get; set; }

        public override void Enter()
        {
            Character.Animator.SetBool("IsAttacking", true);
            Character.Animator.SetBool("IsLeft", GetAttackAnimationSide());

            Character.AttackAnimationEnded.AddListener(TakeDamageOnAttackAnimation);
        }

        public override void Exit()
        {
            Character.Animator.SetBool("IsAttacking", false);
            Character.Animator.SetBool("IsLeft", false);

            Character.AttackAnimationEnded.RemoveListener(TakeDamageOnAttackAnimation);
        }

        public void TakeDamageOnAttackAnimation()
        {
            Character.Animator.SetBool("IsLeft", GetAttackAnimationSide());
            Character.StateMachine.Current = Enums.CharacterStateType.Idle;

            if (Target is not null)
            {
                Target.TakeDamage(Character.AttackDamage);
                Target = null;

                return;
            }
            var nearestEnemy = GetNearestEnemy();

            if (Vector3.Distance(nearestEnemy.Model.transform.position, Character.Model.transform.position) > Character.AttackRange)
            {
                return;
            }

            nearestEnemy.Damageable.TakeDamage(Character.AttackDamage);
        }

        public bool GetAttackAnimationSide()
        {
            return UnityEngine.Random.Range(0, 2) == 1;
        }

        private EnemyCharacter GetNearestEnemy()
        {
            var enemies = UnityEngine.Object.FindObjectsOfType<EnemyCharacter>();

            if (enemies.Length == 0)
            {
                return null;
            }

            return enemies.OrderBy(enemy => Vector3.Distance(enemy.Model.transform.position, Character.Model.transform.position)).FirstOrDefault();
        }
    }
}
