using UnityEngine;
using Zenject;

namespace TopDownShooter
{
    [RequireComponent (typeof(HandsIKSettingComponent))]
    public class InventoryComponent : MonoBehaviour
    {
        [Inject]
        private InputManager _inputManager;
        [SerializeField]
        private WeaponComponent[] _weapons;
        private WeaponComponent _currentWeapon;
        private HandsIKSettingComponent _HandsIKsettings;

        public WeaponComponent CurrentWeapon { get => _currentWeapon; }
        public WeaponComponent[] Weapons { get => _weapons; private set => _weapons = value; }

        private void Awake()
        {
            _HandsIKsettings = GetComponent<HandsIKSettingComponent>();
            foreach (var weapon in Weapons) 
            {
                DisableWeapon(weapon);
            }
            _currentWeapon = Weapons[0];
            EnableWeapon(_currentWeapon);
            _inputManager.ChooseWeapon1Action.performed += callBackContext => SelectWeapon(0);
            _inputManager.ChooseWeapon2Action.performed += callBackContext => SelectWeapon(1);
        }

        private void SelectWeapon(int num)
        {
            if (Weapons.Length <= num || _currentWeapon == Weapons[num] || !Weapons[num].IsAvailable) return;
            DisableWeapon(_currentWeapon);
            EnableWeapon(Weapons[num]);
            _currentWeapon = Weapons[num];
            
        }

        private void EnableWeapon(WeaponComponent weapon)
        {
            weapon.gameObject.SetActive(true);
            _HandsIKsettings.SetGrips(weapon.RightHandGrip, weapon.LeftHandGrip);
        }

        private void DisableWeapon(WeaponComponent weapon)
        {
            weapon.gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            _inputManager.ChooseWeapon1Action.performed -= callBackContext => SelectWeapon(0);
            _inputManager.ChooseWeapon2Action.performed -= callBackContext => SelectWeapon(1);
        }
    }
}
