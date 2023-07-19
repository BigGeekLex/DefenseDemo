using System;
using UnityEngine;

namespace HP
{
    public class HPBase : MonoBehaviour, IDamagable, IHP
    {
        private int _maxHealth;
        private int _currentHealth;

        public event Action Die;
        public event Action HealthChanged;
        
        public int GetMaxHealth()
        {
            return _maxHealth;
        }

        public int GetCurrentHealth()
        {
            return _currentHealth;
        }

        public void SetHealth(int health)
        {
            _maxHealth = health;
            _currentHealth = _maxHealth;
        }

        public bool TryDamage(int value)
        {
            _currentHealth -= value;

            _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
            
            if (_currentHealth <= 0)
            {
                DieRequest();
            }
        
            HealthChanged?.Invoke();
            return true;
        }
        private void DieRequest()
        {
            Die?.Invoke();
        }
    }
}