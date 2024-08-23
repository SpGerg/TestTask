using Characters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Characters
{
    public class BasicHealth : MonoBehaviour, IDamageable
    {
        public static UnityEvent<Character> Died { get; } = new();

        public int Health
        {
            get
            {
                return _health;
            }
            set
            {
                _health = value;

                _health = Mathf.Clamp(value, 0, MaxHealth);

                HealthChanged.Invoke();
            }
        }

        public int MaxHealth { get; set; }

        public UnityEvent HealthChanged { get; } = new UnityEvent();

        [SerializeField]
        private int _health;

        [SerializeField]
        private int _maxHealth;

        public void Awake()
        {
            MaxHealth = _maxHealth;
            Health = _maxHealth;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;

            if (Health <= 0)
            {
                Kill();
            }
        }

        public void Kill()
        {
            gameObject.SetActive(false);

            if (gameObject.TryGetComponent<EnemyCharacter>(out var enemyCharacter))
            {
                Died.Invoke(enemyCharacter);

                EnemiesPool.Instance.Return(enemyCharacter);
            }
        }
    }
}
