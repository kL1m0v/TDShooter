using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace TopDownShooter
{
    public class GameManager : MonoBehaviour
    {
        [Inject]
        private SaveLoadManager _saveLoadManager;
        private static GameManager _instance;
        [SerializeField]
        private Texture2D _cursorTexture;

        public static SaveLoadManager SaveLoadManager { get => _instance._saveLoadManager; }

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
            AdjustCursor();
        }

        private void OnApplicationQuit()
        {
            SaveLoadManager.SaveConfigToFile();
        }

        public static int GetIDNextScene()
        {
            SaveData save = _instance._saveLoadManager.LoadFromFileData();
            int IDScene = save.CurrentSceneID;
            int NextSceneID = ++IDScene;
            Scene NextScene = SceneManager.GetSceneByBuildIndex(NextSceneID);
            if (NextScene != null)
            {
                return NextSceneID;
            }
            else
            {
                return IDScene;
            }
        }

        private void AdjustCursor()
        {
            Vector2 hotSpot = new(_cursorTexture.width/2, _cursorTexture.height/2);
            Cursor.SetCursor(_cursorTexture, hotSpot, CursorMode.Auto);
        }
    }
}