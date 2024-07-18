using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace TopDownShooter
{
    [RequireComponent(typeof(AudioSource), typeof(Animator), typeof(NavMeshAgent))]
    public class EnemyBase: BaseCharacter
    {
        [SerializeField, Range(0, 50f)]
        private int _damage;
        [SerializeField, Range(0, 15f)]
        protected float _detectDistance;
        [SerializeField]
        protected List<AudioClipWrap> _sounds;
        protected AudioSource _audioSource;
        protected NavMeshAgent _navMeshAgent;
        protected Animator _animator;
        protected FSM _fsm;

        public event Action OnEnemyDied;

        public float DetectDistance => _detectDistance;

        public int Damage { get => _damage; protected set => _damage = value; }

        protected virtual void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
             _fsm = new();
        }

        public AudioClip GetAudioClip(string name)
        {
            AudioClipWrap audioClipWrap = _sounds.Where(s => s.Name == name).FirstOrDefault();
            return audioClipWrap.Clip;
        }

        protected virtual void SetInitialState() 
        {
            _fsm.AddState(new EnemyFSMStateIdle(_fsm, _animator, this, _audioSource, _navMeshAgent));
            _fsm.AddState(new EnemyFSMStateMove(_fsm, _animator, this, _audioSource, _navMeshAgent));
            _fsm.AddState(new EnemyFSMStateAttack(_fsm, _animator, this, _audioSource, _navMeshAgent));
            _fsm.AddState(new EnemyFSMStateDeath(_fsm, _animator, this, _audioSource, _navMeshAgent));
            _fsm.SetState<EnemyFSMStateIdle>();
        }

        public override void Die()
        {
            OnEnemyDied?.Invoke();
            StartCoroutine(DisableWithDelay());
            OnEnemyDied = null;
        }

        private void OnDisable()
        {
            OnEnemyDied = null;
        }

        private IEnumerator DisableWithDelay()
        {
            yield return new WaitForSeconds(3);
            gameObject.SetActive(false);
        }

    }
}