using System;
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
        private AudioSource _audioSource;
        private InventoryComponent _inventoryComponent;
        private MovementController _movementController;
        private PlayerAnimationController _animationController;
        private ShootingManager _shootingManager;

        public static event Action<int> OnHealthChanged;
        public static event Action<int> OnArmorChanged;

        [SerializeField]
        private float _movementSpeed;
        private int _armorPoints;
        private int _money;

        public static Vector3 PlayerPosition { get; private set; }
        public float MovementSpeed { get => _movementSpeed; private set => _movementSpeed = value; }
        public int ArmorPoints 
        { 
            get => _armorPoints; 
            private set 
            {
                _armorPoints = value;
                if (_armorPoints < 0)
                {
                    _armorPoints = 0;
                }
            } 
        }
        public int Money { get => _money; private set => _money = value; }

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
            _audioSource = GetComponent<AudioSource>();
            _movementController = new(transform, _characterController, _inputManager);
            _animationController = new(transform, _animator, _movementController);
            _shootingManager = new(_inputManager, _inventoryComponent, _lineRenderer, transform);
            PlayerPosition = new Vector3();
        }

        private void Update()
        {
            _movementController.UpdateMovement(MovementSpeed);
            _animationController.PlayRunAnimation();
            _shootingManager.Update();
            PlayerPosition = transform.position;
        }

        public override void TakeDamage(int damage)
        {
            if (ArmorPoints >= damage)
            {
                ArmorPoints -= damage;
                OnArmorChanged?.Invoke(ArmorPoints);
            }
            else if (ArmorPoints > 0 && ArmorPoints < damage)
            {
                int residualDamage = damage - ArmorPoints;
                ArmorPoints = residualDamage;
                OnArmorChanged?.Invoke(ArmorPoints);
                base.TakeDamage(residualDamage);
                OnHealthChanged?.Invoke(HealthPoints);
            }

            else
            {
                base.TakeDamage(damage);
                OnHealthChanged?.Invoke(HealthPoints);
            }
            _audioSource.Play();
        }

        public static void CustomizePlayer(PlayerConfig config)
        {
            _instance.HealthPoints = config.Health;
            _instance.ArmorPoints = config.Armor;
            _instance.Money = config.Money;
            _instance._inventoryComponent.Weapons[0].IsAvailable = config.IsHasPistol;
            _instance._inventoryComponent.Weapons[0].IsAvailable = config.IsHasAssaultRifle;
        }

    }
}
