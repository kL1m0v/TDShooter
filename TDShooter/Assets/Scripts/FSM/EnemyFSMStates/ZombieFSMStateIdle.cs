using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TopDownShooter
{
    public class ZombieFSMStateIdle : EnemyFSMStateBase
    {
        protected NavMeshAgent _navMeshAgent;

        public ZombieFSMStateIdle(FSM fsm, Animator animator, EnemyBase enemyBase, NavMeshAgent navMeshAgent, AudioSource audioSource) : base(fsm, animator, enemyBase, audioSource) 
        {
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