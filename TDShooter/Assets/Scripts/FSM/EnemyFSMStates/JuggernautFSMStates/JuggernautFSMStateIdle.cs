using UnityEngine;
using UnityEngine.AI;

namespace TopDownShooter
{
    public class JuggernautFSMStateIdle : EnemyFSMStateIdle
    {
        public JuggernautFSMStateIdle(FSM fsm, Animator animator, EnemyBase enemyBase, AudioSource audioSource, NavMeshAgent navMeshAgent) :
            base(fsm, animator, enemyBase, audioSource, navMeshAgent) { }

        public override void Update()
        {
            base.Update();
        }

        protected override void CheckDistanceAndSetState()
        {
            _animator.SetInteger("NumState", (int)NumStateAnimation.Idle);
            float distanceToPlayer = _enemyBase.GetDistanceToPlayer();
            if (distanceToPlayer <= _enemyBase.DetectDistance)
            {
                _fsm.SetState<JuggernautFSMStateMove>();
            }
        }
    }
}
