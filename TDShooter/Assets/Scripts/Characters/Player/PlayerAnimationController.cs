using UnityEngine;

namespace TopDownShooter
{
    public class PlayerAnimationController
    {
        private Transform _transform;
        private Animator _animator;
        private MovementController _movementController;

        public PlayerAnimationController(Transform transform, Animator animator, MovementController movementController)
        {
            _transform = transform;
            _animator = animator;
            _movementController = movementController;
        }

        public void PlayRunAnimation()
        {
            if(_movementController.MovementDirection == Vector3.zero)
            {
                _animator.SetFloat("Forward", 0);
                _animator.SetFloat("Sideway", 0);
                return;
            }
            Vector3 directionForAnimation = _movementController.MovementDirection + _transform.position;
            directionForAnimation = _transform.InverseTransformPoint(directionForAnimation);
            _animator.SetFloat("Sideway", directionForAnimation.x);
            _animator.SetFloat("Forward", directionForAnimation.z);
        }
    }
}
