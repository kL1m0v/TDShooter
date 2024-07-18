using TopDownShooter;
using UnityEngine;
using UnityEngine.AI;

public class JuggernautFSMStateAttack : EnemyFSMStateBase
{
    public JuggernautFSMStateAttack(FSM fsm, Animator animator, EnemyBase enemyBase, AudioSource audioSource, NavMeshAgent navMeshAgent) : base(fsm, animator, enemyBase, audioSource, navMeshAgent) { }

    public override void Update() 
    {
        float distanceToPlayer = _enemyBase.GetDistanceToPlayer();
        Vector3 direction = new(PlayerManager.PlayerPosition.x, _enemyBase.transform.position.y, PlayerManager.PlayerPosition.z);
        _enemyBase.transform.LookAt(direction);
        if (distanceToPlayer > _navMeshAgent.stoppingDistance)
        {
            _fsm.SetState<JuggernautFSMStateMove>();
            return;
        }

        int randomAttack = Random.Range(0, 2);
        if (randomAttack == 0)
            _animator.SetInteger("NumState", (int)NumStateAnimation.Attack);
        else
            _animator.SetInteger("NumState", (int)NumStateAnimation.SpetialAttack);
    }
}