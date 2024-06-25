using UnityEngine;
using UnityEngine.AI;

namespace TopDownShooter
{
    public class EnemyFSMStateBase : FSMStateBase
    {
        protected Animator _animator;
        
        public EnemyFSMStateBase(FSM fsm, Animator animator) : base(fsm) 
        {
            _animator = animator;
        }
    }
}