using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "Data", menuName = "Settings/RoundConfig", order = 1)]
    public class RoundConfig : ScriptableObject
    {
        public SpawnConfig spawnConfig;
        public EnemyConfig enemyConfig;
        public PlayerConfig playerConfig;
    }
}