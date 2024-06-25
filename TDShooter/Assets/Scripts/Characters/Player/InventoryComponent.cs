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

        private void Start()
        {
            _HandsIKsettings = GetComponent<HandsIKSettingComponent>();
            foreach (var weapon in _weapons) 
            {
                DisableWeapon(weapon);
            }
            _currentWeapon = _weapons[0];
            EnableWeapon(_currentWeapon);
            _inputManager.ChooseWeapon1Action.performed += callBackContext => SelectWeapon(0);
            _inputManager.ChooseWeapon2Action.performed += callBackContext => SelectWeapon(1);
            _inputManager.ChooseWeapon3Action.performed += callBackContext => SelectWeapon(2);
        }

        private void SelectWeapon(int num)
        {
            if (_weapons.Length <= num || _currentWeapon == _weapons[num]) return;
            DisableWeapon(_currentWeapon);
            EnableWeapon(_weapons[num]);
            _currentWeapon = _weapons[num];
            
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
    }
}
