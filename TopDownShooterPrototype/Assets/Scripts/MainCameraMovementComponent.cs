using UnityEngine;

namespace TopDownShooter
{
    public class MainCameraMovementComponent : MonoBehaviour
    {
        [SerializeField]
        private Transform _playerTransform;
        private Vector3 _initialPositionDifference;

        private void Start()
        {
            _initialPositionDifference = transform.position - _playerTransform.position;
        }

        private void Update()
        {
            transform.position = _playerTransform.position + _initialPositionDifference;
        }
    }
}
