using UnityEngine;
using Zenject;

namespace TopDownShooter
{
    public class Spawner : MonoBehaviour
    {
        [Inject]
        private DiContainer _container;
        [SerializeField]
        private GameObject _zombiePrefab;
        [SerializeField]
        private GameObject _mutantPrefab;
        [SerializeField]
        private GameObject _watcherPrefab;
        [SerializeField]
        private GameObject _demonPrefab;
        [SerializeField]
        private GameObject _juggernautPrefab;
        private GameObject[] _prefabsArray;
        
        private void Awake()
        {
            _prefabsArray = new[] { _zombiePrefab, _mutantPrefab, _watcherPrefab, _demonPrefab };
        }

        public GameObject SpawnRandomEnemyToPoint(Transform point)
        {
            GameObject enemy = _container.InstantiatePrefab(_prefabsArray[UnityEngine.Random.Range(0, _prefabsArray.Length)]);
            enemy.transform.position = point.position;
            return enemy;
        }

        public GameObject SpanwJuggernautToPoint(Transform point)
        {
            GameObject enemy = _container.InstantiatePrefab(_juggernautPrefab);
            enemy.transform.position = point.position;
            return enemy;
        }

        public void SpawnPlayer(Transform transform)
        {

            GameObject player = Resources.Load<GameObject>("Player");
            _container.InstantiatePrefab(player, transform.position, transform.rotation, this.transform);
        }
    }
}