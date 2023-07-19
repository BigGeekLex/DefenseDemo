using Shoot;
using UnityEngine;
using UnityEngine.Serialization;

namespace Spawn
{
    [CreateAssetMenu(fileName = "BulletFactory", menuName = "Settings/BulletSpawnFactory", order = 1)]
    sealed class BulletFactory : FactoryBase
    {
        [FormerlySerializedAs("bulletBase")] [SerializeField] private BulletSimple bulletSimple;

        public BulletSimple GetBullet(Vector3 position)
        {
            return Get(bulletSimple, position);
        }
        
        private T Get<T>(T prefab, Vector3 position) where T : BulletSimple
        {
            return CreateInstance(prefab, position);
        }
    }
}