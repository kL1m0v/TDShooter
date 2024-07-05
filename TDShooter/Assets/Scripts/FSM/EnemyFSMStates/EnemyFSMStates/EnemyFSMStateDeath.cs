using UnityEngine;
using UnityEngine.AI;

namespace TopDownShooter
{
    public class EnemyFSMStateDeath : EnemyFSMStateBase
    {
        public EnemyFSMStateDeath(FSM fsm, Animator animator, EnemyBase enemyBase, AudioSource audioSource, NavMeshAgent navMeshAgent) : base(fsm, animator, enemyBase, audioSource, navMeshAgent) { }

        public override void Enter()
        {
            _navMeshAgent.enabled = false;
            _animator.SetInteger("NumState", (int)NumStateAnimation.Death);
            _audioSource.clip = _enemyBase.GetAudioClip("Death");
            _audioSource.Play();
        }
    }
}