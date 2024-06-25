using UnityEngine;

namespace TopDownShooter
{
    public class WeaponComponent : MonoBehaviour
    {
        [SerializeField]
        private Transform _RightHandGrip;
        [SerializeField]
        private Transform _LeftHandGrip;
        [SerializeField]
        private Transform _muzzle;

        public Transform RightHandGrip { get => _RightHandGrip; }
        public Transform LeftHandGrip { get => _LeftHandGrip; }
        public Transform Muzzle { get => _muzzle; }
    }
}
