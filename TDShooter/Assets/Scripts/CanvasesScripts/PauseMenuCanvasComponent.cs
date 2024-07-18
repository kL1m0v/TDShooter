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

        private void OnEnable()
        {
            _inputManager.PauseAction.performed += PauseAction_performed;
            _resumeButton.onClick.AddListener(Continue);
            _resumeButton.onClick.AddListener(() => Debug.Log("Click"));
            _exitButton.onClick.AddListener(GoToMainMenu);
        }

        private void Start()
        {
            _canvas = GetComponent<Canvas>();
            _canvas.enabled = false;
        }

        private void OnDestroy()
        {
            _inputManager.PauseAction.performed -= PauseAction_performed;
            _resumeButton.onClick.RemoveAllListeners();
            _exitButton.onClick.RemoveAllListeners();
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