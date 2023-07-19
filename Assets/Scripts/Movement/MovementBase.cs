using UnityEngine;

namespace Movement
{
    public abstract class MovementBase : MonoBehaviour, IMovable
    {
        protected float speed;
        protected Vector2 dir = Vector2.zero;

        public void SetSpeed(float speed)
        {
            this.speed = speed;
        }

        public void SetDirection(Vector2 dir)
        {
            this.dir = dir;
        }

        protected abstract void OnAwake();
    
        protected virtual void OnUpdate()
        {
            Move();
        }
        protected abstract void Move();

        private void Awake()
        {
            OnAwake();
        }
    }
}
