using System;

namespace Spawn
{
    public interface IEnemySpawner
    {
        void HandleEnemyDespawn();
        
        event Action EnemyDespawned;
        void SpawnEnemies(int enemyCount, float minDelay = 1, float maxDelay = 1);
    }
}