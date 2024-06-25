using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TopDownShooter
{
    public class ZombieFSMStateIdle : EnemyFSMStateBase
    {
        protected EnemyBase _enemyBase;
        protected NavMeshAgent _navMeshAgent;

        public ZombieFSMStateIdle(FSM fsm,  Animator animator, EnemyBase enemyBase, NavMeshAgent navMeshAgent) : base(fsm, animator) 
        {
            _enemyBase = enemyBase;
            _navMeshAgent = navMeshAgent;
        }

        public override void Update()
        {
            _animator.SetInteger("NumState", (int)NumStateAnimation.Idle);
            float distanceToPlayer = _enemyBase.GetDistanceToPlayer();
            if (distanceToPlayer <= _enemyBase.DetectDistance)
            {
                 _fsm.SetState<ZombieFSMStateMove>();
                return;
            }
        }
    }
}