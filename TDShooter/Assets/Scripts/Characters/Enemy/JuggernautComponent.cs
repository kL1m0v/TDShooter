using UnityEngine;

namespace TopDownShooter
{
    public class JuggernautComponent: MeleeEnemyComponent
    {
        [SerializeField]
        private Collider _DamageAreaCollider;
        [SerializeField]
        private int areaDamage;

        protected override void Start()
        {
            base.Start();
            SetInitialState();
            DisableDamageAreaCollider();
        }

        protected override void SetInitialState()
        {

            _fsm.AddState(new JuggernautFSMStateIdle(_fsm, _animator, this, _audioSource, _navMeshAgent));
            _fsm.AddState(new JuggernautFSMStateMove(_fsm, _animator, this, _audioSource, _navMeshAgent));
            _fsm.AddState(new JuggernautFSMStateAttack(_fsm, _animator, this, _audioSource, _navMeshAgent));
            _fsm.AddState(new EnemyFSMStateDeath(_fsm, _animator, this, _audioSource, _navMeshAgent));

            _fsm.SetState<JuggernautFSMStateIdle>();
        }

        public override void Die()
        {
            base.Die();
        }

        private void EnableDamageAreaCollider()
        {
            _DamageAreaCollider.enabled = true;
        }

        private void DisableDamageAreaCollider()
        {
            _DamageAreaCollider.enabled = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent<PlayerManager>(out PlayerManager player))
            {
                player.TakeDamage(areaDamage);
            }
        }
    }
}