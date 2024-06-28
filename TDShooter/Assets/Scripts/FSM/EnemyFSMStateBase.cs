using UnityEngine;
using UnityEngine.AI;

namespace TopDownShooter
{
    public class EnemyFSMStateBase : FSMStateBase
    {
        protected Animator _animator;
        protected AudioSource _audioSource;
        protected EnemyBase _enemyBase;
        
        public EnemyFSMStateBase(FSM fsm, Animator animator, EnemyBase enemyBase, AudioSource audioSource) : base(fsm) 
        {
            _animator = animator;
            _enemyBase = enemyBase;
            _audioSource = audioSource;

        }
    }
}