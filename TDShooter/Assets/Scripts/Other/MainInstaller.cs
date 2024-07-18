using UnityEngine;
using Zenject;

namespace TopDownShooter
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField]
        private GameObject _playerBulletPrefab;

        public override void InstallBindings()
        {
            InitializeManagers();
            InitializePlayerConfigAndMVVM();
            Container.Bind<SaveData>().AsCached().NonLazy();
        }

        private void InitializeManagers()
        {
            Container.Bind<SaveLoadManager>().AsCached().NonLazy();

        }

        private void InitializePlayerConfigAndMVVM()
        {
            Container.Bind<PlayerConfigViewModel>().AsSingle().NonLazy();
            Container.Bind<PlayerConfigModel>().AsCached().NonLazy();
            Container.Bind<PlayerConfig>().AsCached().NonLazy();
        }
    }
}
