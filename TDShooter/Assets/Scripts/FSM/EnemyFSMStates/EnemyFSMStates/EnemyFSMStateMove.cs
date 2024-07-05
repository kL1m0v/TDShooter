using TopDownShooter;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSMStateMove : EnemyFSMStateBase
{
    public EnemyFSMStateMove(FSM fsm, Animator animator, EnemyBase enemyBase, AudioSource audioSource, NavMeshAgent navMeshAgent) : 
        base(fsm, animator, enemyBase, audioSource, navMeshAgent) { }
     
    public override void Exit()
    {
        _navMeshAgent.ResetPath();
    }

    public override void Update()
    {
        UpdateMovement();
        CheckDistanceAndSetState();
    }

    private void UpdateMovement()
    {
        _animator.SetInteger("NumState", (int)NumStateAnimation.Move);
        _navMeshAgent.SetDestination(PlayerManager.PlayerPosition);
        Vector3 direction = new(PlayerManager.PlayerPosition.x, _enemyBase.transform.position.y, PlayerManager.PlayerPosition.z);
        _enemyBase.transform.LookAt(direction);
    }

    protected override void CheckDistanceAndSetState()
    {
        float distanceToPlayer = _enemyBase.GetDistanceToPlayer();
        if (distanceToPlayer > _enemyBase.DetectDistance)
        {
            _fsm.SetState<EnemyFSMStateIdle>();
            return;
        }
        if (distanceToPlayer <= _navMeshAgent.stoppingDistance)
        {
            _fsm.SetState<EnemyFSMStateAttack>();
            return;
        }
    }
}

