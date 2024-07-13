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
        private static GameManager _instance;

        public SaveLoadManager SaveLoadManager { get => _saveLoadManager; }

        private void Start()
        {
            if(_instance == null)
            {
                _instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            SaveLoadManager.LoadFromFileData();
        }

        public void LoadNewGame()
        {
            SceneManager.LoadScene(1);
        }
        
        
        private void OnApplicationQuit()
        {
            SaveLoadManager.SaveToFilePlayerConfig();
        }

        public static int GetIDNextScene()
        {
            SaveData save = _instance.SaveLoadManager.LoadFromFileData();
            int IDScene = save.CurrentSceneID;
            if(IDScene >= SceneManager.sceneCount)
            {
                return IDScene;
            }
            else
            {
                return ++IDScene;
            }
        }

    }
}