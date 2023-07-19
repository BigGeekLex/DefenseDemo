using CustomDI;
using Spawn;
using UnityEngine;

namespace Units
{
    [RequireComponent(typeof(InstallerBase))]
    public class Enemy : UnitBase
    {
        private IEnemySpawner _enemySpawner;
        
        [Injectable]
        private void Init(IEnemySpawner enemySpawner)
        {
            _enemySpawner = enemySpawner;
        }
        protected override void OnUnitDieCallback()
        {
            base.OnUnitDieCallback();
            _enemySpawner.HandleEnemyDespawn();
            Destroy(gameObject);
        }
    }
}