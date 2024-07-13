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
        private GameManager _gameManager;
        [Inject]
        private SceneLoader _sceneLoader;
        [SerializeField]
        private Canvas _mainCanvas;
        [SerializeField]
        private Canvas _loadCanvas;
        [SerializeField]
        private Canvas _playerSettingsCanvas;

        [SerializeField]
        private Button _newGameButton;
        [SerializeField]
        private Button _loadButton;
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
            _newGameButton.onClick.AddListener(() =>
            {
                _gameManager.LoadNewGame();
            }
            );

            _loadButton.onClick.AddListener(() => 
            { 

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
#if UNITY_EDITOR
                EditorApplication.isPlaying = false;
#else 
                Application.Quit(); 
#endif
            });
        }

        private void OnDisable()
        {
            _newGameButton.onClick.RemoveAllListeners();
            _loadButton.onClick.RemoveAllListeners();
            _backToMainMenuButton.onClick.RemoveAllListeners();
            _exitButton.onClick.RemoveAllListeners();
        }
    }
}