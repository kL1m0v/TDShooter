using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace TopDownShooter
{
    public class HandsIKSettingComponent : MonoBehaviour
    {
        [SerializeField]
        private TwoBoneIKConstraint _rightHandIK;
        [SerializeField]
        private TwoBoneIKConstraint _leftHandIK;

        public void SetGrips(Transform rightHand, Transform leftHand)
        {
            _rightHandIK.data.target.position = rightHand.position;
            _rightHandIK.data.target.rotation = rightHand.rotation;
            _leftHandIK.data.target.position = leftHand.position;
            _leftHandIK.data.target.rotation = leftHand.rotation;
        }
    }
}
