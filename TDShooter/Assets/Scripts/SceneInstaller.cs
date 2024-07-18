using UnityEngine;
using Zenject;

namespace TopDownShooter
{
    
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField]
        private GameObject _playerBulletPrefab;

        public override void InstallBindings()
        {
            InitializePlayer();
        }

        private void InitializePlayer()
        {
            Container.Bind<PlayerControls>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<InputManager>().AsSingle().NonLazy();
            Container.Bind<ObjectPool>().WithId("PlayerBullPool").FromNew().AsSingle().WithArguments(_playerBulletPrefab, 2).NonLazy();
        }
    }
}