using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace TopDownShooter
{
    [RequireComponent(typeof(CharacterController), (typeof(InputManager)))]

    public class MovementController : MonoBehaviour
    {
        private CharacterController _characterController;
        private InputManager _inputManager;
        private Vector3 _movementDirection;
        [SerializeField]
        private float _movementSpeed;

        public Vector3 MovementDirection { get => _movementDirection; }

        private void Start()
        {
             _characterController = GetComponent<CharacterController>();
            _inputManager = GetComponent<InputManager>();
        }

        private void Update()
        {
            Move();
            Rotate();
        }

        private void Move()
        {
            if (_inputManager.MoveAction.ReadValue<Vector2>() == Vector2.zero)
            {
                _movementDirection = Vector3.zero;
                return;
            }
            _movementDirection.x = _inputManager.MoveAction.ReadValue<Vector2>().y;
            _movementDirection.z = -_inputManager.MoveAction.ReadValue<Vector2>().x;
            _characterController.Move(_movementSpeed * Time.deltaTime * _movementDirection) ;
        }

        private void Rotate()
        {
            if (Physics.Raycast(_inputManager.ScreenRay, out RaycastHit hit))
            {
                Vector3 targetPosition = hit.point;
                Vector3 direction = targetPosition - transform.position;
                direction.y = 0;
                Quaternion rotation = Quaternion.LookRotation(direction);
                transform.rotation = rotation;
            }
        }
    }
}
