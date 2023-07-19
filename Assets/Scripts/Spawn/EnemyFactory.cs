using Units;
using UnityEngine;

namespace Spawn
{
    [CreateAssetMenu(fileName = "EnemyFactory", menuName = "Settings/EnemySpawnFactory", order = 1)]
    sealed class EnemyFactory : FactoryBase
    {
        [SerializeField] private Enemy enemyDefault;
        public Enemy GetEnemy(Vector3 position)
        {
            return Get(enemyDefault, position);
        }
        
        private T Get<T>(T prefab, Vector3 position) where T : Enemy
        {
            return CreateInstance(prefab, position);
        }
    }
}