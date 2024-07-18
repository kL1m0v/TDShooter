using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace TopDownShooter
{
    public class SceneController : MonoBehaviour
    {
        private Spawner _spawner;
        [SerializeField]
        protected Transform _playerSpawnPoint;
        [SerializeField]
        protected List<Transform> _enemySpawnPoints;
        [SerializeField]
        protected List<Transform> _juggernautSpawnPoint;
        protected int _enemiesKilled;
        protected int _requiredNumberDeaths;
        protected int _moneyForGame;
        [SerializeField, Range(1, 50)]
        protected int _moneyForEnemy;
        [SerializeField]
        protected SceneCanvasComponent _sceneCanvas;
        public event Action<int> OnEmemiesKilledChanged;
        public event Action<int> OnRequiredNumberDeathsChanged;
        public event Action<int> OnMoneyChanged;

        protected virtual void Start()
        {
            _spawner = GetComponent<Spawner>();
            _spawner.SpawnPlayer(_playerSpawnPoint);
            SpawnEnemiesToPoints();
            OnEmemiesKilledChanged += _sceneCanvas.RedrawEnemiesKilledText;
            OnRequiredNumberDeathsChanged += _sceneCanvas.RedrawRequiredNumberDeathsText;
            OnMoneyChanged += _sceneCanvas.RedrawAmountMoney;
            _requiredNumberDeaths = _enemySpawnPoints.Count;
            OnRequiredNumberDeathsChanged?.Invoke(_requiredNumberDeaths);
            PlayerManager.OnPlayerDeath += () => StartCoroutine(MissionFailed());
        }

        protected void OnValidate()
        {
            OnRequiredNumberDeathsChanged?.Invoke(_requiredNumberDeaths);
        }

        protected virtual void SpawnEnemiesToPoints()
        {
            foreach (Transform t in _enemySpawnPoints) 
            {
                GameObject enemy = _spawner.SpawnRandomEnemyToPoint(t);
                enemy.GetComponent<EnemyBase>().OnEnemyDied += CountDeathsEnemies;
            }
            foreach (Transform t in _juggernautSpawnPoint)
            {
                GameObject enemy = _spawner.SpanwJuggernautToPoint(t);
                enemy.GetComponent<EnemyBase>().OnEnemyDied += CountDeathsEnemies;
            }
        }

        protected virtual void CountDeathsEnemies()
        {
            ++_enemiesKilled;
            _moneyForGame += _moneyForEnemy;
            OnMoneyChanged?.Invoke(_moneyForGame);
            OnEmemiesKilledChanged?.Invoke(_enemiesKilled);
            if (_enemiesKilled >= _requiredNumberDeaths)
            {
                StartCoroutine(CompleteMission());
            }
        }

        protected virtual IEnumerator CompleteMission()
        {
            _sceneCanvas.SetTextAndVisible("Vistory", true);
            yield return new WaitForSeconds(3);
            GameManager.SaveLoadManager.PlayerConfig.Money += _moneyForGame;
            GameManager.SaveLoadManager.SaveConfigToFile();
            GameManager.SaveLoadManager.SaveData.CurrentSceneID = SceneManager.GetActiveScene().buildIndex;
            GameManager.SaveLoadManager.SaveToFileData();
            SceneManager.LoadScene(0); 
        }

        protected virtual IEnumerator MissionFailed() 
        {
            _sceneCanvas.SetTextAndVisible("Wasted", true);
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene(0);
        }

        private void OnDisable()
        {
            OnEmemiesKilledChanged -= _sceneCanvas.RedrawEnemiesKilledText;
            OnRequiredNumberDeathsChanged -= _sceneCanvas.RedrawRequiredNumberDeathsText;
            PlayerManager.OnPlayerDeath -= () => StartCoroutine(MissionFailed());
        }
    }
}