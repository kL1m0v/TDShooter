using UnityEngine;
using Zenject;

namespace TopDownShooter
{
    public class MovementController
    {
        
        private InputManager _inputManager;
        private Transform _transform;
        private CharacterController _characterController;
        private Vector3 _movementDirection;
        private float _movementSpeed;

        public Vector3 MovementDirection { get => _movementDirection; }

        public MovementController(Transform transform, CharacterController characterController, InputManager inputManager)
        {
            _transform = transform;
            _characterController = characterController;
            _inputManager = inputManager;
        }

        public void UpdateMovement(float movementSpeed)
        {
            Move(movementSpeed);
            Rotate();
        }

        private void Move(float movementSpeed)
        {
            if (_inputManager.MoveAction.ReadValue<Vector2>() == Vector2.zero)
            {
                _movementDirection = Vector3.zero;
                return;
            }
            _movementDirection.x = _inputManager.MoveAction.ReadValue<Vector2>().y;
            _movementDirection.z = -_inputManager.MoveAction.ReadValue<Vector2>().x;
            _characterController.Move(movementSpeed * Time.deltaTime * _movementDirection) ;
        }

        private void Rotate()
        {
            Vector3 targetPosition = _inputManager.GetRaycastHit().point;
            Vector3 direction = targetPosition - _transform.position;
            direction.y = 0;
            Quaternion rotation = Quaternion.LookRotation(direction);
            _transform.rotation = rotation;
        }
    }
}
