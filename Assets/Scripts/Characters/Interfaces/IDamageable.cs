using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;

namespace Characters.Interfaces
{
    public interface IDamageable
    {
        int Health { get; set; }

        int MaxHealth { get; set; }

        UnityEvent HealthChanged { get; }

        void Kill();

        void TakeDamage(int damage);
    }
}
