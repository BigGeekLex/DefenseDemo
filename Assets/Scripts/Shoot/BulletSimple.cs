using System.Linq;
using HP;
using Movement;
using UnityEngine;

namespace Shoot
{
    [RequireComponent(typeof(Collider2D), typeof(MovementBase))]
    public class BulletSimple : MonoBehaviour
    {
        private IMovable _movable;

        private int _damage;
        private float _shootRange;
        private string[] _targetTags;

        private Vector3 _startPos;
        
        public void SetBulletShootRange(float shootRange)
        {
            _shootRange = shootRange;
        }

        public void SetBulletDirection(Vector2 dir)
        {
            _movable.SetDirection(dir);    
        }
        
        public void SetBulletDamage(int damage)
        {
            _damage = damage;
        }
        
        public void SetBulletTargets(string[] targetTags)
        {
            _targetTags = targetTags;
        }
        
        public void SetBulletSpeed(float speed)
        {
            _movable.SetSpeed(speed);
        }
        private void Awake()
        {
            _movable = GetComponent<IMovable>();
            _startPos = gameObject.transform.position;
        }
        private void Update()
        {
            CheckInRange();
        }
        private void CheckInRange()
        {
            if (Vector3.Distance(_startPos, gameObject.transform.position) >= _shootRange)
            {
                DestroyBullet();//In future change to using pool
            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_targetTags.Contains(other.tag))
            {
                if (other.TryGetComponent(out IDamagable damagable))
                {
                    damagable.TryDamage(_damage);
                    DestroyBullet();
                }
            }
        }

        private void DestroyBullet()
        {
            Destroy(gameObject);
        }
    }
}