using System;
using UnityEngine;

namespace Configs
{
    [Serializable]
    public class SpawnConfig
    {
        [SerializeField] private int minEnemyCount;
        [SerializeField] private int maxEnemyCount;
        [SerializeField] private float minSpawnDelay;
        [SerializeField] private float maxSpawnDelay;
        
        public int MinEnemyCount
        {
            get => minEnemyCount;
        }

        public int MaxEnemyCount
        {
            get => maxEnemyCount;
        }
        
        public float MinDelay
        {
            get => minSpawnDelay;
        }
    
        public float MaxDelay
        {
            get => maxSpawnDelay;
        }
    }
}