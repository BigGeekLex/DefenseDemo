using CustomDI;
using Shoot;
using UnityEngine;

namespace Spawn
{
    [RequireComponent(typeof(InstallerBase))]
    public class BulletSpawner : MonoBehaviour
    {
        private BulletFactory _bulletFactory;
        
        [Injectable]
        private void Init(BulletFactory bulletFactory)
        {
            _bulletFactory = bulletFactory;
        }
        public BulletSimple SpawnBullet(Vector3 position)
        {
            return _bulletFactory.GetBullet(position);
        }
    }
}