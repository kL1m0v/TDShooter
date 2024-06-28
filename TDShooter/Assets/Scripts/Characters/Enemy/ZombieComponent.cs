using UnityEngine;
using UnityEngine.AI;

namespace TopDownShooter
{
    [RequireComponent (typeof(Animator), (typeof(NavMeshAgent)))]
    public class ZombieComponent: EnemyBase
    {
        private NavMeshAgent _navMeshAgent;
        private Animator _animator;
        private FSM _fsm;
        [SerializeField]
        private Collider _handCollider;
        
        protected override void Start()
        {
            base.Start();
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();  
            _fsm = new();
            _fsm.AddState(new ZombieFSMStateIdle(_fsm, _animator, this, _navMeshAgent, _audioSource));
            _fsm.AddState(new ZombieFSMStateMove(_fsm, _animator, this, _navMeshAgent, _audioSource));
            _fsm.AddState(new ZombieFSMStateAttack(_fsm, _animator, this, _navMeshAgent, _audioSource));
            _fsm.AddState(new ZombieFSMStateDeath(_fsm, _animator, this, _audioSource));

            _fsm.SetState<ZombieFSMStateIdle>();
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
            _fsm.SetState<ZombieFSMStateDeath>();
        }
    }
}
