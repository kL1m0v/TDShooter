using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace TopDownShooter
{
    public class PauseMenuCanvasComponent : MonoBehaviour
    {
        [Inject]
        private InputManager _inputManager;
        [SerializeField]
        private Button _resumeButton;
        [SerializeField]
        private Button _exitButton;
        private Canvas _canvas;

        private void Start()
        {
            _resumeButton.onClick.AddListener(Continue);
            _exitButton.onClick.AddListener(GoToMainMenu);
            _canvas = GetComponent<Canvas>();
            _canvas.enabled = false;
            _inputManager.PauseAction.performed += PauseAction_performed;
        }

        private void PauseAction_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;
            _canvas.enabled = _canvas.enabled == false ? true : false;
        }

        private void Continue()
        {
            Time.timeScale = 1;
            _canvas.enabled = false;
        }

        private void GoToMainMenu()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }
    }
}