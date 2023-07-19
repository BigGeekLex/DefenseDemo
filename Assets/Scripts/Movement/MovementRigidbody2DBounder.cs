using CustomDI;
using Level;
using UnityEngine;

namespace Movement
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D), typeof(InstallerBase))]
    sealed class MovementRigidbody2DBounder : MonoBehaviour
    {
        private float _yMaxValue = 2;
        
        private Camera _playerCamera;
        private Rigidbody2D _rb;
        private Collider2D _collider2D;
    
        private Vector2 _screenBound;
        private float _colliderXBoundSize;
        private float _colliderYBoundSize;
    
        private void Awake()
        {
            _playerCamera = Camera.main;
            _rb = GetComponent<Rigidbody2D>();
            _collider2D = GetComponent<Collider2D>();
            
            GetScreenBound();
            InitColliderBounds();
        }

        [Injectable]
        private void Init(FinishLine finishLine)
        {
            _yMaxValue = finishLine.transform.position.y;
        }
        private void Update()
        {
            ClampMovablePosition();
        }
    
        private void ClampMovablePosition()
        {
            var nextHorizontalValue = Mathf.Clamp(_rb.position.x,
                -_screenBound.x + _colliderXBoundSize, _screenBound.x - _colliderXBoundSize);
            var nextVerticalValue = Mathf.Clamp(_rb.position.y,
                -_screenBound.y + _colliderYBoundSize, _yMaxValue - _colliderYBoundSize);
            var nextMovePosition = new Vector2(nextHorizontalValue, nextVerticalValue);
            _rb.position = nextMovePosition;
        }
    
        private void GetScreenBound()
        {
            var tmp = _playerCamera.ScreenToWorldPoint(new Vector3(Screen.width, (int)Screen.height,
                _playerCamera.transform.position.z));
                
            _screenBound = new Vector2(tmp.x, tmp.y);
        }
    
        private void InitColliderBounds()
        {
            _colliderXBoundSize = _collider2D.bounds.size.x / 2;
            _colliderYBoundSize = _collider2D.bounds.size.y / 2;
        }
    }   
}