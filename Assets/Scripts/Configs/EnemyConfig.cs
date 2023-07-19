using System;
using UnityEngine;

namespace Configs
{
    [Serializable]
    public class EnemyConfig
    {
        [SerializeField] private float minEnemySpeed;
        [SerializeField] private float maxEnemySpeed;

        [SerializeField] private int enemyDamage = 1;
        [SerializeField] private int enemyHealth;
        
        public float MinEnemySpeed
        {
            get => minEnemySpeed;
        }

        public float MaxEnemySpeed
        {
            get => maxEnemySpeed;
        }

        public int EnemyHealth
        {
            get => enemyHealth;
        }

        public int EnemyDamage
        {
            get => enemyDamage;
        }
    }
}