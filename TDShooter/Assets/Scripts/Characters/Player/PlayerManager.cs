using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace TopDownShooter
{
    [RequireComponent(typeof(Animator), (typeof(InventoryComponent)), (typeof(CharacterController)))]
    public class PlayerManager: BaseCharacter
    {
        private static PlayerManager _instance;
        
        [Inject]
        private InputManager _inputManager;
        private Animator _animator;
        private CharacterController _characterController;
        private LineRenderer _lineRenderer;
        private InventoryComponent _inventoryComponent;
        private MovementController _movementController;
        private PlayerAnimationController _animationController;
        private ShootingManager _shootingManager;
        [SerializeField, Range(0f, 100f)]
        private float _movementSpeed;
        public static Vector3 PlayerPosition { get; private set; }

        private void Start()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
                return;
            }
            _instance = this;
            DontDestroyOnLoad(gameObject);
            
            _animator = GetComponent<Animator>();
            _characterController = GetComponent<CharacterController>();
            _inventoryComponent = GetComponent<InventoryComponent>();
            _lineRenderer = GetComponent<LineRenderer>();
            _movementController = new(transform, _characterController, _inputManager);
            _animationController = new(transform, _animator, _movementController);
            _shootingManager = new(_inputManager, _inventoryComponent, _lineRenderer, transform);
            PlayerPosition = new Vector3();
        }

        private void Update()
        {
            _movementController.UpdateMovement(_movementSpeed);
            _animationController.PlayRunAnimation();
            _shootingManager.Update();
            PlayerPosition = transform.position;
        }

        //private void OnDrawGizmos()
        //{
        //    Gizmos.color = Color.blue;
        //    Gizmos.DrawSphere(_inputManager.GetRaycastHit().point, 0.1f);
        //    Gizmos.DrawLine(transform.position, _inputManager.GetRaycastHit().point);
        //}
    }
}
