using UnityEngine;

namespace TopDownShooter
{
    public class MainCameraMovementComponent : MonoBehaviour
    {
        [SerializeField]
        private Transform _playerTransform;
        private Vector3 _initialPositionDifference;
        private Quaternion _initialRotation;

        private void OnEnable()
        {
            _initialPositionDifference = _playerTransform.position - transform.position;
            _initialRotation = transform.rotation;
        }

        private void LateUpdate()
        {
            transform.position = _playerTransform.position - _initialPositionDifference;
            transform.rotation = _initialRotation;
        }
    }
}
