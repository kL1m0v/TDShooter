using UnityEngine;
using UnityEngine.AI;

namespace TopDownShooter
{
    public class EnemyFSMStateBase : FSMStateBase
    {
        protected Animator _animator;
        protected AudioSource _audioSource;
        protected EnemyBase _enemyBase;
        protected NavMeshAgent _navMeshAgent;
        
        public EnemyFSMStateBase(FSM fsm, Animator animator, EnemyBase enemyBase, AudioSource audioSource, NavMeshAgent navMeshAgent) : base(fsm) 
        {
            _animator = animator;
            _enemyBase = enemyBase;
            _audioSource = audioSource;
            _navMeshAgent = navMeshAgent;

        }

        protected virtual void CheckDistanceAndSetState() { }
    }
}