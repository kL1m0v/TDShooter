using UnityEngine;

namespace TopDownShooter
{
    public class JuggernautComponent: MeleeEnemyComponent
    {
        protected override void Start()
        {
            base.Start();
            SetInitialState();
        }

        protected override void SetInitialState()
        {

            _fsm.AddState(new JuggernautFSMStateIdle(_fsm, _animator, this, _audioSource, _navMeshAgent));
            _fsm.AddState(new JuggernautFSMStateMove(_fsm, _animator, this, _audioSource, _navMeshAgent));
            _fsm.AddState(new JuggernautFSMStateAttack(_fsm, _animator, this, _audioSource, _navMeshAgent));
            _fsm.AddState(new EnemyFSMStateDeath(_fsm, _animator, this, _audioSource, _navMeshAgent));

            _fsm.SetState<JuggernautFSMStateIdle>();
        }
    }
}