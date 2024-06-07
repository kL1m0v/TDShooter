using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace TopDownShooter
{
    public class InputManager : MonoBehaviour
    {
        [Inject]
        private PlayerControls _controls;
        private InputAction _moveAction;
        private InputAction _rotateAction;
        private InputAction _fireAction;
        private Camera _mainCamera;
        private Ray _screenRay;

        public InputAction MoveAction { get { return _moveAction; } }
        public InputAction MousePositionAction { get { return _rotateAction; } }
        public InputAction FireAction { get => _fireAction; }
        public Ray ScreenRay { get { return _screenRay; } }


        private void Start()
        {
            _moveAction = _controls.FindAction("Move");
            _rotateAction = _controls.FindAction("MousePosition");
            _fireAction = _controls.FindAction("Fire");
            _moveAction.Enable();
            _rotateAction.Enable();
            _fireAction.Enable();
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            _screenRay = _mainCamera.ScreenPointToRay(MousePositionAction.ReadValue<Vector2>());
        }

        private void OnDisable()
        {
            _moveAction.Disable();
            _rotateAction.Disable();
            _fireAction.Disable();
        }
    }
}
