using UnityEngine;
using UnityEngine.AI;

namespace TopDownShooter
{
    public class EnemyFSMStateAttack : EnemyFSMStateBase
    {
        public EnemyFSMStateAttack(FSM fsm, Animator animator, EnemyBase enemyBase, AudioSource audioSource, NavMeshAgent navMeshAgent) : base(fsm, animator, enemyBase, audioSource, navMeshAgent)
        {
            _enemyBase = enemyBase;
        }

        public override void Update()
        {
            float distanceToPlayer = _enemyBase.GetDistanceToPlayer();
            Vector3 direction = new(PlayerManager.PlayerPosition.x, _enemyBase.transform.position.y, PlayerManager.PlayerPosition.z);
            _enemyBase.transform.LookAt(direction);
            if (distanceToPlayer > _navMeshAgent.stoppingDistance)
            {
                _fsm.SetState<EnemyFSMStateMove>();
                return;
            }
            _animator.SetInteger("NumState", (int)NumStateAnimation.Attack);
        }
    }
}