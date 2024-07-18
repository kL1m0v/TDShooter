using UnityEngine;
using UnityEngine.AI;

namespace TopDownShooter
{
    public class MeleeEnemyComponent: EnemyBase
    {
        [SerializeField]
        protected Collider _handCollider;
        
        protected override void Start()
        {
            base.Start();
            SetInitialState();
        }

        private void Update() 
        { 
            _fsm.Update();
        }

        private void EnableHandCollider_AnimationEvent()
        {
            _handCollider.enabled = true;
        }

        private void DisableHandCollider_AnimationEvent()
        {
            _handCollider.enabled = false;
        }

        private void StopAnimation_AnimationEvent()
        {
            _animator.enabled = false;
        }

        public override void Die()
        {
            base.Die();
            _fsm.SetState<EnemyFSMStateDeath>();
        }
    }
}
