using Configs;
using CustomDI;
using Spawn;
using UnityEngine;

namespace Level
{
    [RequireComponent(typeof(InstallerBase))]
    public class RoundStarter : MonoBehaviour
    {
        private int _targetEnemyCount;
        
        [Injectable]
        public void Init(SpawnConfig spawnConfig, IEnemySpawner enemySpawner)
        {
            _targetEnemyCount = Random.Range(spawnConfig.MinEnemyCount, spawnConfig.MaxEnemyCount);
            enemySpawner.SpawnEnemies(_targetEnemyCount, spawnConfig.MinDelay, spawnConfig.MaxDelay);
        }

        public int GetTargetRoundEnemySpawnCount()
        {
            return _targetEnemyCount;
        }
    }
}