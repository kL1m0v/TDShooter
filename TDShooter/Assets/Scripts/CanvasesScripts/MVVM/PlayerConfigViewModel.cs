using UnityEngine;

namespace TopDownShooter
{
    public class PlayerConfigViewModel
    {
        private PlayerConfigModel _model;

        public readonly ReactiveProperty<int> HealthView = new();
        public readonly ReactiveProperty<int> ArmorView = new();
        public readonly ReactiveProperty<int> MoneyView = new();
        public readonly ReactiveProperty<bool> IsHasPistolView = new();
        public readonly ReactiveProperty<bool> IsHasAssaultRifleView = new();

        public readonly ReactiveProperty<bool> HealthButtonEnabled = new();
        public readonly ReactiveProperty<bool> ArmorButtonEnabled = new();
        public readonly ReactiveProperty<bool> MoneyButtonEnabled = new();
        public readonly ReactiveProperty<bool> IsHasPistolButtonEnabled = new();
        public readonly ReactiveProperty<bool> IsHasAssaultRifleButtonEnabled = new();

        public PlayerConfigViewModel(PlayerConfigModel playerConfigModel)
        {
            _model = playerConfigModel;
            _model.Health.OnChanged += OnModelHealthChanged;
            _model.Armor.OnChanged += OnModelArmorChanged;
            _model.Money.OnChanged += OnModelMoneyChanged;
            _model.IsHasPistol.OnChanged += OnModelIsHasPistolChanged;
            _model.IsHasAssaultRifle.OnChanged += OnModelIsHasAssaultRifleChanged;
        }


        private void OnModelHealthChanged(int value)
        {
            HealthView.Value = value;
        }

        private void OnModelArmorChanged(int value)
        {
            ArmorView.Value = value;
        }

        private void OnModelMoneyChanged(int value)
        {
            MoneyView.Value = value;
        }

        private void OnModelIsHasPistolChanged(bool value)
        {
            IsHasPistolView.Value = value;
        }

        private void OnModelIsHasAssaultRifleChanged(bool value)
        {
            IsHasAssaultRifleView.Value = value;
        }

        public void OnIncreaseHealthButtonClicked()
        {
            if(MoneyView.Value >= _model.PricePerCharacteristic)
            {
                IncreasePropertyValue(HealthView, 10);
                IncreasePropertyValue(MoneyView, -_model.PricePerCharacteristic);
            }
        }

        public void OnIncreaseArmorButtonClicked()
        {
            if (MoneyView.Value >= _model.PricePerCharacteristic)
            {
                IncreasePropertyValue(ArmorView, 10);
                IncreasePropertyValue(MoneyView, -_model.PricePerCharacteristic);
            }
        }

        public void OnAddPistolButtonClicked()
        {
            if (MoneyView.Value >= _model.PriceOfPistol)
            {
                IsHasPistolView.Value = true;
                IncreasePropertyValue(MoneyView, -_model.PriceOfPistol);
            }
        }

        public void OnAddAssaultRifleButtonClicked()
        {
            if (MoneyView.Value >= _model.PriceOfAssaultRifle)
            {
                IsHasAssaultRifleView.Value = true;
                IncreasePropertyValue(MoneyView, -_model.PriceOfAssaultRifle);
            }
        }

        private void IncreasePropertyValue(ReactiveProperty<int> reactiveProperty, int value)
        {
            reactiveProperty.Value += value;
        }

        public void OnSubmitButtonClicked()
        {
            _model.Health.Value = HealthView.Value;
            _model.Armor.Value = ArmorView.Value;
            _model.Money.Value = MoneyView.Value;
            _model.IsHasPistol.Value = IsHasPistolView.Value;
            _model.IsHasAssaultRifle.Value = IsHasAssaultRifleView.Value;
            GameManager.SaveLoadManager.SaveFromModelToPlayerConfig();
        }

        public void OnResetButtonClicked()
        {
            HealthView.Value = _model.Health.Value;
            ArmorView.Value = _model.Armor.Value;
            MoneyView.Value = _model.Money.Value;
            IsHasPistolView.Value = _model.IsHasPistol.Value;
            IsHasAssaultRifleView.Value = _model.IsHasAssaultRifle.Value;
        }
    }
}