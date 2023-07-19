using CustomDI;
using Spawn;
using UnityEngine;

namespace Level
{
    public class WinRoundConditionChecker : MonoBehaviour
    {
        private IEnemySpawner _enemySpawner;
        private RoundStarter _roundStarter;
        private RoundStatementController _roundStatementController;
        
        private int _currentEnemyDiedCount;
        
        [Injectable]
        private void Init(RoundStarter roundStarter, IEnemySpawner enemySpawner, RoundStatementController roundStatementController)
        {
            _roundStarter = roundStarter;
            _enemySpawner = enemySpawner;
            _roundStatementController = roundStatementController;
            
            _enemySpawner.EnemyDespawned += CheckWinCondition;
        }

        private void OnDestroy()
        {
            _enemySpawner.EnemyDespawned -= CheckWinCondition;
        }
        
        private void CheckWinCondition()
        {
            _currentEnemyDiedCount++;
            
            if (_currentEnemyDiedCount < _roundStarter.GetTargetRoundEnemySpawnCount()) return;

            _roundStatementController.TryChangeStatement(RoundState.Win);
        }
    }
}