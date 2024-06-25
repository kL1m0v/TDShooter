using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace TopDownShooter
{
    public class InputManager : IInitializable, IDisposable
    {
        [Inject]
        private PlayerControls _controls;
        private InputAction _moveAction;
        private InputAction _rotateAction;
        private InputAction _fireAction;

        private InputAction _chooseWeapon1Action;
        private InputAction _chooseWeapon2Action;
        private InputAction _chooseWeapon3Action;

        private Camera _mainCamera;

        public InputAction MoveAction { get => _moveAction;  }
        public InputAction MousePositionAction { get => _rotateAction;  }
        public InputAction FireAction { get => _fireAction; }

        public InputAction ChooseWeapon1Action { get => _chooseWeapon1Action; }
        public InputAction ChooseWeapon2Action { get => _chooseWeapon2Action; }
        public InputAction ChooseWeapon3Action { get => _chooseWeapon3Action; }

        public void Initialize()
        {
            AssignActions();
            EnableActions();
            _mainCamera = Camera.main;
        }    

        private void AssignActions()
        {
            _moveAction = _controls.FindAction("Move");
            _rotateAction = _controls.FindAction("MousePosition");
            _fireAction = _controls.FindAction("Fire");
            _chooseWeapon1Action = _controls.FindAction("ChooseWeapon1");
            _chooseWeapon2Action = _controls.FindAction("ChooseWeapon2");
            _chooseWeapon3Action = _controls.FindAction("ChooseWeapon3");
        }

        private void EnableActions()
        {
            _moveAction.Enable();
            _rotateAction.Enable();
            _fireAction.Enable();
            _chooseWeapon1Action.Enable();
            _chooseWeapon2Action.Enable();
            _chooseWeapon3Action.Enable();
        }

        public RaycastHit GetRaycastHit()
        {
            RaycastHit hit;
            Physics.Raycast(_mainCamera.ScreenPointToRay(MousePositionAction.ReadValue<Vector2>()), out hit);
            return hit;
        }

        public void Dispose()
        {
            _moveAction.Disable();
            _rotateAction.Disable();
            _fireAction.Disable();
            _chooseWeapon1Action.Disable();
            _chooseWeapon2Action.Disable();
            _chooseWeapon3Action.Disable();
        }
    }
}
