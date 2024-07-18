using System;
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
        [SerializeField]
        private Transform _cameraTransform;

        public static event Action<int> OnHealthChanged;
        public static event Action<int> OnArmorChanged;
        public static event Action OnPlayerDeath;

        [SerializeField]
        private float _movementSpeed;
        private int _armorPoints;
        private int _money;
        private int _totalHealthPoints;

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
        public int TotalHealthPoints { get => _totalHealthPoints; private set => _totalHealthPoints = value; }

        private void Start()
        {
            if (_instance != null)
            {
                return;
            }
            _instance = this;
            _animator = GetComponent<Animator>();
            _characterController = GetComponent<CharacterController>();
            _inventoryComponent = GetComponent<InventoryComponent>();
            _lineRenderer = GetComponent<LineRenderer>();
            _audioSource = GetComponent<AudioSource>();
            _movementController = new(transform, _characterController, _inputManager);
            _animationController = new(transform, _animator, _movementController);
            _shootingManager = new(_inputManager, _inventoryComponent, _lineRenderer, transform);
            PlayerPosition = new Vector3();
            Camera.main.transform.SetParent(_cameraTransform);
            Camera.main.transform.SetPositionAndRotation(_cameraTransform.position, _cameraTransform.rotation);
            CustomizePlayer(GameManager.SaveLoadManager.PlayerConfig);
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
                OnHealthChanged?.Invoke(CurrentHealthPoints);
            }

            else
            {
                base.TakeDamage(damage);
                OnHealthChanged?.Invoke(CurrentHealthPoints);
            }
            _audioSource.Play();
        }

        public override void Die()
        {
            base.Die();
            OnPlayerDeath?.Invoke();
        }

        public void GiveHealthPoints(int healthPoints)
        {
            if(TotalHealthPoints - CurrentHealthPoints < healthPoints)
            {
                CurrentHealthPoints = TotalHealthPoints;
                OnHealthChanged?.Invoke(CurrentHealthPoints);
            }
            else
            {
                CurrentHealthPoints += healthPoints;
                OnHealthChanged?.Invoke(CurrentHealthPoints);
            }
                
        }

        public static void CustomizePlayer(PlayerConfig config)
        {
            _instance.CurrentHealthPoints = config.Health;
            _instance.TotalHealthPoints = _instance.CurrentHealthPoints;
            _instance.ArmorPoints = config.Armor;
            _instance.Money = config.Money;
            _instance._inventoryComponent.Weapons[0].IsAvailable = config.IsHasPistol;
            _instance._inventoryComponent.Weapons[1].IsAvailable = config.IsHasAssaultRifle;
        }

    }
}
