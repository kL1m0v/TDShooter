using UnityEngine;
using Zenject;

namespace TopDownShooter
{
    [RequireComponent (typeof(Rigidbody))]
    public sealed class FlyingRangerEnemyComponent: RangerEnemyComponent
    {
        private Rigidbody _rigidbody;
        [Inject(Id = "WatcherProjectilePool")]
        private ObjectPool _projectilesPool;

        protected override void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            base.Start();
            SetInitialState();
        }

        protected override void SetInitialState()
        {
            _fsm.AddState(new EnemyFSMStateIdle(_fsm, _animator, this, _audioSource, _navMeshAgent));
            _fsm.AddState(new EnemyFSMStateMove(_fsm, _animator, this, _audioSource, _navMeshAgent));
            _fsm.AddState(new EnemyFSMStateAttack(_fsm, _animator, this, _audioSource, _navMeshAgent));
            _fsm.AddState(new FlyingRangerEnemyFSMStateDeath(_fsm, _animator, this, _audioSource, _navMeshAgent, _rigidbody));
            _fsm.SetState<EnemyFSMStateIdle>();
        }

        public override void Die()
        {
            _fsm.SetState<FlyingRangerEnemyFSMStateDeath>();
        }
    }
}
