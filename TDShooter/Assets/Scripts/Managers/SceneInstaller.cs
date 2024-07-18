using UnityEngine;
using Zenject;

namespace TopDownShooter
{
    
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField]
        private GameObject _playerBulletPrefab;
        [SerializeField]
        private GameObject _projectilePrefab;

        public override void InstallBindings()
        {
            InitializePlayer();
            InitializeProjectilePool();
        }

        private void InitializePlayer()
        {
            Container.Bind<PlayerControls>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<InputManager>().AsSingle().NonLazy();
            Container.Bind<ObjectPool>().WithId("PlayerBullPool").FromNew().AsCached().WithArguments(_playerBulletPrefab, 2).NonLazy();
        }

        private void InitializeProjectilePool()
        {
            Container.Bind<ObjectPool>().WithId("ProjectilePool").FromNew().AsCached().WithArguments(_projectilePrefab, 3).NonLazy();
        }
    }
}