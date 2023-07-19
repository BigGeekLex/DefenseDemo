using System;
using HP;
using Movement;
using UnityEngine;

namespace Units
{
    [RequireComponent(typeof(MovementBase), typeof(HPBase))]
    public abstract class UnitBase : MonoBehaviour
    {
        protected IHP hp;
        protected IDamagable damagable;
        protected IMovable movable;

        public event Action UnitDied;
        private void Awake()
        {
            OnAwake();
        }

        protected virtual void OnAwake()
        {
            hp = GetComponent<IHP>();
            movable = GetComponent<IMovable>();
            damagable = GetComponent<IDamagable>();
            
            hp.Die += OnUnitDieCallback;
        }
        private void OnDestroy()
        {
            hp.Die -= OnUnitDieCallback;
            UnitDied = null;
        }

        public void SetUnitSpeed(float speed)
        {
            movable.SetSpeed(speed);
        }

        public void SetUnitHealth(int health)
        {
            hp.SetHealth(health);
        }

        public IHP GetUnitHealth()
        {
            return hp;
        }

        public IDamagable GetUnitDamagable()
        {
            return damagable;
        }
        
        protected virtual void OnUnitDieCallback()
        {
            UnitDied?.Invoke();
        }
    }
}