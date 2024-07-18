using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TopDownShooter
{
    public class PlayerConfigView : MonoBehaviour
    {
        [Inject]
        private PlayerConfigViewModel _viewModel;
        [Inject]
        private SaveLoadManager _saveLoadManager;

        [SerializeField]
        private TextMeshProUGUI _healthValueText;
        [SerializeField]
        private TextMeshProUGUI _armorValueText;
        [SerializeField]
        private TextMeshProUGUI _moneyValueText;
        [SerializeField]
        private TextMeshProUGUI _pistolButtonText;
        [SerializeField]
        private TextMeshProUGUI _assaultRiffleButtonText;
        [SerializeField]
        private TextMeshProUGUI _pricePerHealthText;
        [SerializeField]
        private TextMeshProUGUI _pricePerArmorText;
        [SerializeField]
        private TextMeshProUGUI _priceOfPistolText;
        [SerializeField]
        private TextMeshProUGUI _priceOfAssaultRifle;

        [SerializeField]
        private Button _healthButton;
        [SerializeField]
        private Button _armorButton;
        [SerializeField]
        private Button _pistolButton;
        [SerializeField]
        private Button _assaultRiffleButton;

        [SerializeField]
        private Button _submitButton;
        [SerializeField]
        private Button _resetButton;

        public void Start()
        {
            _viewModel.HealthView.OnChanged += DisplayHealthView;
            _viewModel.ArmorView.OnChanged += DisplayArmorView;
            _viewModel.MoneyView.OnChanged += DisplayMoneyView;
            _viewModel.IsHasPistolView.OnChanged += DisplayPistolAddButton;
            _viewModel.IsHasAssaultRifleView.OnChanged += DisplayAssaultRifleAddButton;

            _healthButton.onClick.AddListener(_viewModel.OnIncreaseHealthButtonClicked);
            _armorButton.onClick.AddListener(_viewModel.OnIncreaseArmorButtonClicked);
            _pistolButton.onClick.AddListener (_viewModel.OnAddPistolButtonClicked);
            _assaultRiffleButton.onClick.AddListener(_viewModel.OnAddAssaultRifleButtonClicked);

            _submitButton.onClick.AddListener(_viewModel.OnSubmitButtonClicked);
            _resetButton.onClick.AddListener(_viewModel.OnResetButtonClicked);

            _healthValueText.text = _viewModel.HealthView.Value.ToString();
            _armorValueText.text = _viewModel.ArmorView.Value.ToString();
            _pistolButton.enabled = !_viewModel.IsHasPistolView.Value;
            _assaultRiffleButton.enabled = !_viewModel.IsHasAssaultRifleView.Value;

            _saveLoadManager.LoadConfigFromFile();
        }


        private void DisplayHealthView(int value)
        {
            _healthValueText.text = value.ToString();
        }

        private void DisplayArmorView(int value)
        {
            _armorValueText.text = value.ToString();
        }

        private void DisplayMoneyView(int value)
        {
            _moneyValueText.text = value.ToString();
        }

        private void DisplayPistolAddButton(bool isActive)
        {
            if (isActive)
            {
                _pistolButton.gameObject.SetActive(false);
                _priceOfPistolText.enabled = false;
            }
                
            else
            {
                _pistolButton.gameObject.SetActive(true);
                _priceOfPistolText.enabled = false;
            }
        }

        private void DisplayAssaultRifleAddButton(bool isActive)
        {
            if (isActive)
            {
                _assaultRiffleButton.gameObject.SetActive(false);
                _priceOfAssaultRifle.enabled = false;
            }
            else
            {
                _assaultRiffleButton.gameObject.SetActive(true);
                _priceOfAssaultRifle.enabled = true;
            }
        }

        private void OnDisable()
        {
            _viewModel.HealthView.OnChanged -= DisplayHealthView;
            _viewModel.ArmorView.OnChanged -= DisplayArmorView;
            _viewModel.MoneyView.OnChanged -= DisplayMoneyView;
            _viewModel.IsHasPistolView.OnChanged -= DisplayPistolAddButton;
            _viewModel.IsHasAssaultRifleView.OnChanged -= DisplayAssaultRifleAddButton;

            _healthButton.onClick.RemoveAllListeners();
            _armorButton.onClick.RemoveAllListeners();
            _pistolButton.onClick.RemoveAllListeners();
            _assaultRiffleButton.onClick.RemoveAllListeners();

            _submitButton.onClick.RemoveAllListeners();
            _resetButton.onClick.RemoveAllListeners();
        }

    }
}