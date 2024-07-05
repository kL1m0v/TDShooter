using UnityEngine;
using UnityEngine.AI;

namespace TopDownShooter
{
    public class JuggernautFSMStateMove : EnemyFSMStateMove
    {
        public JuggernautFSMStateMove(FSM fsm, Animator animator, EnemyBase enemyBase, AudioSource audioSource, NavMeshAgent navMeshAgent) : 
            base(fsm, animator, enemyBase, audioSource, navMeshAgent) { }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
        }

        protected override void CheckDistanceAndSetState()
        {
            float distanceToPlayer = _enemyBase.GetDistanceToPlayer();
            if (distanceToPlayer > _enemyBase.DetectDistance)
            {
                _fsm.SetState<JuggernautFSMStateIdle>();
                return;
            }
            if (distanceToPlayer <= _navMeshAgent.stoppingDistance)
            {
                _fsm.SetState<JuggernautFSMStateAttack>();
                return;
            }
        }
    }

}
