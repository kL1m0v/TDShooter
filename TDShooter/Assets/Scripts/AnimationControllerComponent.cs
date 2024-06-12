using UnityEngine;

namespace TopDownShooter
{
    [RequireComponent(typeof(Animator))]
    public class AnimationControllerComponent : MonoBehaviour
    {
        private Animator _animator;
        private MovementControllerComponent _movementController;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _movementController = GetComponent<MovementControllerComponent>();
        }

        private void Update() 
        {
            PlayRunAnimation();
        }
        
        private void PlayRunAnimation()
        {
            if(_movementController.MovementDirection == Vector3.zero)
            {
                _animator.SetFloat("Forward", 0);
                _animator.SetFloat("Sideway", 0);
                return;
            }
            Vector3 directionForAnimation = _movementController.MovementDirection + transform.position;
            directionForAnimation = transform.InverseTransformPoint(directionForAnimation);
            _animator.SetFloat("Sideway", directionForAnimation.x);
            _animator.SetFloat("Forward", directionForAnimation.z);
        }
    }
}
