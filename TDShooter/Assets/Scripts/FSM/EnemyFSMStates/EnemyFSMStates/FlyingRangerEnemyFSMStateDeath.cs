using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace TopDownShooter
{
    public class FlyingRangerEnemyFSMStateDeath : EnemyFSMStateDeath
    {
        [Inject(Id = "WatcherProjectilePool")]
        private ObjectPool _projectilesPool;
        private Rigidbody _rigidbody;

        public FlyingRangerEnemyFSMStateDeath(FSM fsm, Animator animator, EnemyBase enemyBase, AudioSource audioSource, NavMeshAgent navMeshAgent, Rigidbody rigidbody) : base(fsm, animator, enemyBase, audioSource, navMeshAgent)
        {
            _rigidbody = rigidbody;
        }

        public override void Enter() 
        {
            _rigidbody.useGravity = true;
            base.Enter();
        }
    }
}