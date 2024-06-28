using UnityEngine;
using UnityEngine.AI;

namespace TopDownShooter
{
    public class ZombieFSMStateAttack : EnemyFSMStateBase
    {
        protected NavMeshAgent _navMeshAgent;

        public ZombieFSMStateAttack(FSM fsm, Animator animator, EnemyBase enemyBase, NavMeshAgent navMeshAgent, AudioSource audioSource) : base(fsm, animator, enemyBase, audioSource)
        {
            _enemyBase = enemyBase;
            _navMeshAgent = navMeshAgent;
        }

        public override void Update()
        {
            float distanceToPlayer = _enemyBase.GetDistanceToPlayer();
            if (distanceToPlayer > _navMeshAgent.stoppingDistance)
            {
                _fsm.SetState<ZombieFSMStateMove>();
                return;
            }
            _animator.SetInteger("NumState", (int)NumStateAnimation.Attack);
        }
    }
}