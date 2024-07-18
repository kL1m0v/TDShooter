using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace TopDownShooter
{
    public class MainMenuComponent : MonoBehaviour
    {
        [SerializeField]
        private Canvas _mainCanvas;
        [SerializeField]
        private Canvas _loadCanvas;
        [SerializeField]
        private Canvas _playerSettingsCanvas;

        [SerializeField]
        private Button _resetButton;
        [SerializeField]
        private Button _playButton;
        [SerializeField]
        private Button _playerUpdateButton;
        [SerializeField]
        private Button _exitButton;

        [SerializeField]
        private Button _backToMainMenuButton;

        private void Start()
        {
            _mainCanvas.enabled = true;
            _loadCanvas.enabled = false;
            _playerSettingsCanvas.enabled = false;
        }

        private void OnEnable()
        {
            _resetButton.onClick.AddListener(() =>
            {
                GameManager.SaveLoadManager.PlayerConfig.Reset();
                GameManager.SaveLoadManager.SaveConfigToFile();
                GameManager.SaveLoadManager.SaveData.Reset();
                GameManager.SaveLoadManager.SaveToFileData();
            }
            );

            _playButton.onClick.AddListener(() => 
            {
                _loadCanvas.enabled = true;
                SceneManager.LoadScene(GameManager.GetIDNextScene());
            });

            _playerUpdateButton.onClick.AddListener(() => 
            {
                _mainCanvas.enabled = false;
                _playerSettingsCanvas.enabled = true;
            });

            _backToMainMenuButton.onClick.AddListener(() => 
            {
                _mainCanvas.enabled = true;
                _playerSettingsCanvas.enabled = false;
            });

            _exitButton.onClick.AddListener(() => 
            {
                GameManager.SaveLoadManager.SaveConfigToFile();
                GameManager.SaveLoadManager.SaveToFileData();
#if UNITY_EDITOR
                EditorApplication.isPlaying = false;
#else 
                Application.Quit(); 
#endif
            });
        }

        private void OnDisable()
        {
            _resetButton.onClick.RemoveAllListeners();
            _playButton.onClick.RemoveAllListeners();
            _backToMainMenuButton.onClick.RemoveAllListeners();
            _exitButton.onClick.RemoveAllListeners();
        }
    }
}