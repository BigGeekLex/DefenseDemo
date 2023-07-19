using Configs;
using CustomDI;
using Shoot;
using UnityEngine;

namespace Units
{
    [RequireComponent(typeof(InstallerBase), typeof(ShootSimple))]
    public class Player : UnitBase
    {
        private IShoot _shoot;
        [Injectable]
        private void Init(PlayerConfig playerConfig)
        {
            SetUnitSpeed(playerConfig.MoveSpeed);
            SetUnitHealth(playerConfig.Health);
            InitializeShoot(playerConfig);
        }
        protected override void OnUnitDieCallback()
        {
            base.OnUnitDieCallback();
        }

        protected override void OnAwake()
        {
            base.OnAwake();
            _shoot = GetComponent<IShoot>();
        }

        private void InitializeShoot(PlayerConfig playerConfig)
        {
            _shoot.Initialize(playerConfig.ShootRange, playerConfig.BulletSpeed,
                playerConfig.ShootSpeed, playerConfig.Damage);
        }
    }
}