using System;

namespace HP
{
    public interface IHP
    {
        event Action Die;

        event Action HealthChanged;
        int GetMaxHealth();
        int GetCurrentHealth();

        void SetHealth(int health);
    }
}