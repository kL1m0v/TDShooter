using UnityEngine;
using UnityEngine.AI;

namespace TopDownShooter
{
    public class ZombieFSMStateAttack : EnemyFSMStateBase
    {
        protected EnemyBase _enemyBase;
        protected NavMeshAgent _navMeshAgent;

        public ZombieFSMStateAttack(FSM fsm, Animator animator, EnemyBase enemyBase, NavMeshAgent navMeshAgent) : base(fsm, animator)
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