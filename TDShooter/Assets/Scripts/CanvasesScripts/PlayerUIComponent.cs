using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TopDownShooter
{
    public class PlayerUIComponent : MonoBehaviour
    {
        [SerializeField]
        private PlayerManager _player;
        [SerializeField]
        private Image _healthStrip;
        [SerializeField]
        private TextMeshProUGUI _healthText;

        [SerializeField]
        private Image _armorStrip;
        [SerializeField]
        private TextMeshProUGUI _armorText;

        private int _initialHealth;
        private int _initialArmor;

        private void Start()
        {
            _initialHealth =   _player.HealthPoints;
            _healthText.text = _initialHealth.ToString();
            _initialArmor = _player.ArmorPoints;
            _armorText.text = _initialArmor.ToString();
            if(_initialArmor == 0)
            {
                _armorStrip.fillAmount = 0;
            }
            PlayerManager.OnHealthChanged += RedrawHealth;
            PlayerManager.OnArmorChanged += RedrawArmor;
        }

        private void RedrawHealth(int value)
        {
            _healthStrip.fillAmount = (float)value / _initialHealth;
            _healthText.text = value.ToString();
            Debug.Log(value);
        }

        private void RedrawArmor(int value)
        {
            _armorStrip.fillAmount = (float)value / _initialArmor;
            _armorText.text = value.ToString();
        }


        private void OnDisable()
        {
            PlayerManager.OnHealthChanged -= RedrawHealth;
            PlayerManager.OnArmorChanged -= RedrawArmor;
        }
    }
}