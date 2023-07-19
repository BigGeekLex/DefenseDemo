using System.Linq;
using CustomDI;
using Spawn;
using UnityEngine;

namespace Shoot
{
    [RequireComponent(typeof(InstallerBase))]
    public class ShootSimple : MonoBehaviour, IShoot
    {
        [SerializeField] 
        private string[] targets;
        [SerializeField] 
        private Transform shootTr;

        private float _shootRange;
        private float _bulletSpeed;
        private float _shootSpeed;
        private int _damage;
        
        private float _currentDelay;
        private BulletSpawner _bulletSpawner;
        
        [Injectable]
        private void Init(BulletSpawner bulletSpawner)
        {
            _bulletSpawner = bulletSpawner;
        }
        private void Update()
        {
            _currentDelay += Time.deltaTime;
        
            if (_currentDelay >= _shootSpeed)
            {
                TryShoot();
                _currentDelay = 0.0f;
            }
        }
        
        private Vector2 GetNearestEnemyDirection()
        {
            var colliders = Physics2D.OverlapCircleAll(transform.position, _shootRange);
            var enemies = colliders.Select((x) => x).Where(x=> targets.Contains(x.tag));
            float minDistance = float.MaxValue;
            GameObject nearest = null;
            
            foreach (var enemy in enemies)
            {
                float targetDistance = Vector2.Distance(transform.position, enemy.transform.position);
                
                if (minDistance > targetDistance)
                {
                    minDistance = targetDistance;
                    nearest = enemy.gameObject;
                } 
            }

            if (nearest != null)
            {
                var direction = (nearest.transform.position - transform.position).normalized;

                return direction;
            }
            return Vector2.zero;
        }
        public void Initialize(float shootRange, float bulletSpeed, float shootSpeed, int damage)
        {
            _shootRange = shootRange;
            _bulletSpeed = bulletSpeed;
            _shootSpeed = shootSpeed;
            _damage = damage;
        }
        
        private bool TryShoot()
        {
            Vector2 nearestEnemyDir = GetNearestEnemyDirection();
            
            if (nearestEnemyDir == Vector2.zero) return false;
            
            var bullet = _bulletSpawner.SpawnBullet(new Vector3(shootTr.position.x, shootTr.position.y, 0));
            bullet.SetBulletDamage(_damage);
            bullet.SetBulletDirection(nearestEnemyDir);
            bullet.SetBulletTargets(targets);
            bullet.SetBulletSpeed(_bulletSpeed);
            bullet.SetBulletShootRange(_shootRange);

            return true;
        }
    }
}