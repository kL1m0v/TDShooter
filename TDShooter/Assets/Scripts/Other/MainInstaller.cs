using UnityEngine;
using Zenject;

namespace TopDownShooter
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField]
        private GameObject _playerBulletPrefab;
        [SerializeField]
        private GameObject _watcherProjectilePrefab;
        [SerializeField]
        private GameObject _demonProjectilePrefab;

        public override void InstallBindings()
        {
            Container.Bind<PlayerControls>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<InputManager>().AsSingle().NonLazy();
            InitializeObjectPools();
            InitializeManagers();
            InitializePlayerConfigAndMVVM();
            Container.Bind<SaveData>().AsCached().NonLazy();
        }

        private void InitializeObjectPools()
        {
            Container.Bind<ObjectPool>().WithId("PlayerBullPool").AsTransient().WithArguments(_playerBulletPrefab, 3).Lazy();
            Container.Bind<ObjectPool>().WithId("WatcherProjectilePool").AsTransient().WithArguments(_watcherProjectilePrefab, 3).Lazy();
            Container.Bind<ObjectPool>().WithId("DemonProjectilePool").AsTransient().WithArguments(_demonProjectilePrefab, 10).Lazy();
        }

        private void InitializeManagers()
        {
            Container.Bind<SaveLoadManager>().AsCached().NonLazy();
            Container.Bind<SceneLoader>().AsCached().NonLazy();

        }

        private void InitializePlayerConfigAndMVVM()
        {
            Container.Bind<PlayerConfigViewModel>().AsSingle().NonLazy();
            Container.Bind<PlayerConfigModel>().AsCached().NonLazy();
            Container.Bind<PlayerConfig>().AsCached().NonLazy();
        }
    }
}
