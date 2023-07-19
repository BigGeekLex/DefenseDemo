using System;
using System.Collections;
using Configs;
using CustomDI;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawn
{
    [RequireComponent(typeof(InstallerBase))]
    public class EnemySpawner : MonoBehaviour, IEnemySpawner
    {
        [SerializeField] 
        private Transform[] spawnPoints;//stumb
         
        private EnemyFactory _enemyFactory;
        private EnemyConfig _enemyConfig;
        
        public event Action OnEnemySpawned;
        public event Action EnemyDespawned;

        public void HandleEnemyDespawn()
        {
            EnemyDespawned?.Invoke();
        }
        
        public void SpawnEnemies(int enemyCount, float minDelay, float maxDelay)
        {
            StartCoroutine(SpawnEnemyRoutine(enemyCount, minDelay, maxDelay));
        }
        
        [Injectable]
        private void Init(EnemyFactory enemyFactory, EnemyConfig enemyConfig)
        {
            _enemyFactory = enemyFactory;
            _enemyConfig = enemyConfig;
        }
        private void SpawnEnemy()
        {
            var enemy = _enemyFactory.GetEnemy(GetRandomSpawnPosition());
            enemy.SetUnitSpeed(GetRandomSpeed());
            enemy.SetUnitHealth(_enemyConfig.EnemyHealth);
            
            OnEnemySpawned?.Invoke();
        }
        private Vector3 GetRandomSpawnPosition()
        {
            return spawnPoints[Random.Range(0, spawnPoints.Length)].position;
        }

        private float GetRandomSpeed()
        {
            return Random.Range(_enemyConfig.MinEnemySpeed, _enemyConfig.MaxEnemySpeed);
        }
        private IEnumerator SpawnEnemyRoutine(int targetEnemyCount, float minDelay, float maxDelay)
        {
            int currentCount = 0;
            while (currentCount < targetEnemyCount)
            {
                float targetDelay = Random.Range(minDelay, maxDelay);
                SpawnEnemy();
                currentCount++;
                yield return new WaitForSecondsRealtime(targetDelay);
            }
        }
    }
}