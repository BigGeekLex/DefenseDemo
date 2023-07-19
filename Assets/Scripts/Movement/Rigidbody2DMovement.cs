using UnityEngine;

namespace Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    sealed class Rigidbody2DMovement : MovementBase
    {
        private Rigidbody2D _rigidbody2D;
        protected override void OnAwake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        protected override void Move()
        {
            Vector2 nextMovePosition = _rigidbody2D.position + speed * Time.fixedDeltaTime * dir;
            _rigidbody2D.MovePosition(nextMovePosition);
        }
        private void FixedUpdate()
        {
            OnUpdate();
        }
    }   
}