using UnityEngine;
using UnityEngine.AI;

namespace TopDownShooter
{
    public class EnemyFSMStateIdle : EnemyFSMStateBase
    {
        public EnemyFSMStateIdle(FSM fsm, Animator animator, EnemyBase enemyBase, AudioSource audioSource, NavMeshAgent navMeshAgent) : base(fsm, animator, enemyBase, audioSource, navMeshAgent) {}

        public override void Update()
        {
            CheckDistanceAndSetState();
        }

        protected override void CheckDistanceAndSetState()
        {
            _animator.SetInteger("NumState", (int)NumStateAnimation.Idle);
            float distanceToPlayer = _enemyBase.GetDistanceToPlayer();
            if (distanceToPlayer <= _enemyBase.DetectDistance)
            {
                _fsm.SetState<EnemyFSMStateMove>();
            }
        }
    }
}