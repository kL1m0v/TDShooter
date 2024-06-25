using TopDownShooter;
using UnityEngine;
using UnityEngine.AI;

public class ZombieFSMStateMove : EnemyFSMStateBase
{
    protected EnemyBase _enemyBase;
    protected NavMeshAgent _navMeshAgent;

    public ZombieFSMStateMove(FSM fsm, Animator animator, EnemyBase enemyBase, NavMeshAgent navMeshAgent) : base(fsm, animator) 
    {
        _enemyBase = enemyBase;
        _navMeshAgent = navMeshAgent;
    }
     
    public override void Exit()
    {
        _navMeshAgent.ResetPath();
    }

    public override void Update()
    {
        _animator.SetInteger("NumState", (int)NumStateAnimation.Walk);
        _navMeshAgent.SetDestination(PlayerManager.PlayerPosition);
        float distanceToPlayer = _enemyBase.GetDistanceToPlayer();
        if (distanceToPlayer > _enemyBase.DetectDistance)
        {
            _fsm.SetState<ZombieFSMStateIdle>();
            return;
        }
        if(distanceToPlayer <= _navMeshAgent.stoppingDistance)
        {
            _fsm.SetState<ZombieFSMStateAttack>();
            return;
        }
    }
}

