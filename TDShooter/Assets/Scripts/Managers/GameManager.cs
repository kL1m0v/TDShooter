using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace TopDownShooter
{
    public class GameManager : MonoBehaviour
    {
        [Inject]
        private SceneLoader _sceneLoader;
        [Inject]
        private SaveLoadManager _saveLoadManager;

        private void OnApplicationQuit()
        {
            _saveLoadManager.SaveToFilePlayerConfig();
        }

        public void LoadNewGame()
        {
            SceneManager.LoadScene(1);
            StartCoroutine(_sceneLoader.LoadSceneAsync(2));
        }
    }
}