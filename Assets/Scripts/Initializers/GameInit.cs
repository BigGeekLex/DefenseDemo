using Configs;
using CustomDI;
using Level;
using Spawn;
using Units;
using UnityEngine;

namespace Initializers
{
    public class GameInit : MonoBehaviour
    {
        [SerializeField] private Transform playerSpawnPoint;
        [SerializeField] private RoundConfig roundConfig;
        [SerializeField] private EnemyFactory enemyFactory;
        [SerializeField] private BulletFactory bulletFactory;
        [SerializeField] private FinishLine finishLine;
        
        [SerializeField] private EnemySpawner enemySpawner;
        [SerializeField] private BulletSpawner bulletSpawner;
        [SerializeField] private RoundStarter roundStarter;
        [SerializeField] private WinRoundConditionChecker winRoundConditionChecker;
        [SerializeField] private LooseRoundConditionChecker looseRoundConditionChecker;
        [SerializeField] private Player playerBase;
        [SerializeField] private RoundStatementController roundStatementController;
        [SerializeField] private GameObject gameMenu;
        private void Awake()
        {
            SimpleDImple.Set(roundConfig.spawnConfig);
            SimpleDImple.Set(roundConfig.enemyConfig);
            SimpleDImple.Set(roundConfig.playerConfig);
            SimpleDImple.Set(finishLine);
            SimpleDImple.Set(enemyFactory);
            SimpleDImple.Set(bulletFactory);
            SimpleDImple.Set(roundStatementController);
            SimpleDImple.Set<IEnemySpawner>(enemySpawner);
            SimpleDImple.Set(bulletSpawner);
            SimpleDImple.Set(roundStarter);
            SimpleDImple.Set(winRoundConditionChecker);
            SimpleDImple.Set(looseRoundConditionChecker);
            var player = Instantiate(playerBase, playerSpawnPoint.position, Quaternion.identity);
            SimpleDImple.Set(player);
            Instantiate(gameMenu);
        }

        private void OnDestroy()
        {
            SimpleDImple.Clear();
        }
    }
}