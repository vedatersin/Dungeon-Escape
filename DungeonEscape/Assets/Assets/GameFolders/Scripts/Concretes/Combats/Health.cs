using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Combats;
using UnityEngine;

namespace UdemyProject3.Combats
{
    public class Health : MonoBehaviour, IHealth
    {
        [SerializeField] int maxHealth = 3;
        [SerializeField] int currentHealth;

        public int CurrentHealth => currentHealth;

        public bool IsDead => currentHealth < 1;

        public event System.Action<int,int> OnHealthChanged;
        public event System.Action OnDead;

        private void Awake()
        {
            currentHealth = maxHealth;
        }

        public void TakeHit(IAttacker attacker)
        {
            if (IsDead) return;

            currentHealth = Mathf.Max(currentHealth -= attacker.Damage,0);
            OnHealthChanged?.Invoke(currentHealth,maxHealth);

            if (IsDead) OnDead?.Invoke();
        }

        public void Heal(int lifeCount)
        {
            currentHealth = Mathf.Min(currentHealth += lifeCount, maxHealth);
            OnHealthChanged?.Invoke(currentHealth, maxHealth);
        }
    }
}