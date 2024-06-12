using UnityEngine;

namespace TopDownShooter
{
    public class WeaponComponent : MonoBehaviour
    {
        [SerializeField]
        private Transform _RightHandGrip;
        [SerializeField]
        private Transform _LeftHandGrip;

        public Transform RightHandGrip { get => _RightHandGrip; }
        public Transform LeftHandGrip { get => _LeftHandGrip; }
    }
}
