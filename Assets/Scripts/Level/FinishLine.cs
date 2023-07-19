using Configs;
using CustomDI;
using HP;
using Units;
using UnityEngine;

namespace Level
{
    [RequireComponent(typeof(Collider2D))]
    public class FinishLine : MonoBehaviour
    {
        [SerializeField] 
        private string targetTag = "Enemy";
        private Collider2D _collider2D;
        private IDamagable _playerDamagable;

        private int _enemyDamage;
        
        [Injectable]
        private void Init(Player player, EnemyConfig enemyConfig)
        {
            _playerDamagable = player.GetUnitDamagable();
            _enemyDamage = enemyConfig.EnemyDamage;
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(targetTag))
            {
                IDamagable idamagable = other.GetComponent<IDamagable>();
                IHP enemyHp = other.GetComponent<IHP>();

                idamagable.TryDamage(enemyHp.GetMaxHealth());
                _playerDamagable.TryDamage(_enemyDamage);
            }
        }
    }
}