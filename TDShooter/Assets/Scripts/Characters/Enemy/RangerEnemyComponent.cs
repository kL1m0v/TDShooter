using UnityEngine;
using Zenject;

namespace TopDownShooter
{
    public class RangerEnemyComponent : EnemyBase
    {
        [Inject(Id = "ProjectilePool")]
        private ObjectPool _projectilesPool;
        [SerializeField]
        private Transform _muzzle;

        protected override void Start()
        {
            base.Start();
            SetInitialState();
        }

        protected virtual void Update()
        {
            _fsm.Update();
        }

        protected void StopAnimation_AnimationEvent()
        {
            _animator.enabled = false;
        }

        public override void Die()
        {
            base.Die();
            _fsm.SetState<EnemyFSMStateDeath>();
        }

        protected virtual void Shoot_AnimationEvent()
        {
            GameObject projectile = _projectilesPool.Get();
            projectile.transform.SetPositionAndRotation(_muzzle.transform.position, _muzzle.transform.rotation);
            if (projectile.TryGetComponent(out ProjectileComponent projectileComponent))
            {
                projectileComponent.Damage = Damage;
            }
        }
    }
}