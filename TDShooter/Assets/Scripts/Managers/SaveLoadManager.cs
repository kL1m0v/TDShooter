using UnityEngine;
using Zenject;
using System.IO;

namespace TopDownShooter
{
    public class SaveLoadManager
    {
        [Inject]
        private PlayerConfigModel _configModel;
        [Inject]
        private PlayerConfig _playerConfig;
        [Inject]
        private SaveData _saveData;

        private string _filePathPlayerConfig = Application.persistentDataPath + "/config.json";
        private string _filePathData = Application.persistentDataPath + "/data.json";

        public void SaveToFilePlayerConfig()
        {
            _playerConfig.Health = _configModel.Health.Value;
            _playerConfig.Armor = _configModel. Armor.Value;
            _playerConfig.Money = _configModel.Money.Value;
            _playerConfig.IsHasPistol = _configModel.IsHasPistol.Value;
            _playerConfig.IsHasAssaultRifle = _configModel.IsHasAssaultRifle.Value;

            string toJson = JsonUtility.ToJson(_playerConfig, true);

            File.WriteAllText(_filePathPlayerConfig, toJson);
        }

        public void LoadFromFilePlayerConfig()
        {
            if (!File.Exists(_filePathPlayerConfig))
            {
                return;
                //todo загружать дефолтное значение
            }

            string fromJson = File.ReadAllText(_filePathPlayerConfig);
            
            _playerConfig = JsonUtility.FromJson<PlayerConfig>(fromJson);

            _configModel.Health.Value = _playerConfig.Health;
            _configModel.Armor.Value = _playerConfig.Armor;
            _configModel.Money.Value = _playerConfig.Money;
            _configModel.IsHasPistol.Value = _playerConfig.IsHasPistol;
            _configModel.IsHasAssaultRifle.Value = _playerConfig.IsHasAssaultRifle;
        }

        public void SaveToFileData()
        {
            string toJson = JsonUtility.ToJson(_saveData, true);

            File.WriteAllText(_filePathData, toJson);
        }

        public void LoadFromFileData()
        {
            if (!File.Exists(_filePathData))
            {
                return;
                //todo загружать дефолтное значение
            }

            string fromJson = File.ReadAllText(_filePathData);

            _saveData = JsonUtility.FromJson<SaveData>(fromJson);
        }
    }
}