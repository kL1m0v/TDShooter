using UnityEngine;
using Zenject;
using System.IO;

namespace TopDownShooter
{
    public class SaveLoadManager
    {
        [Inject]
        private PlayerConfigModel _playerConfigModel;
        [Inject]
        private PlayerConfig _playerConfig;
        [Inject]
        private SaveData _saveData;

        private string _filePathPlayerConfig = Application.persistentDataPath + "/config.json";
        private string _filePathData = Application.persistentDataPath + "/data.json";

        public PlayerConfig PlayerConfig { get => _playerConfig; set => _playerConfig = value; }
        public SaveData SaveData { get => _saveData; set => _saveData = value; }
        public PlayerConfigModel PlayerConfigModel { get => _playerConfigModel; set => _playerConfigModel = value; }

        public void SaveConfigToFile()
        {
            SaveFromPlayerConfigToModel();

            string toJson = JsonUtility.ToJson(PlayerConfig, true);

            File.WriteAllText(_filePathPlayerConfig, toJson);
        }

        public void LoadConfigFromFile()
        {
            if (!File.Exists(_filePathPlayerConfig))
            {
                PlayerConfig playerConfig = new();
                playerConfig.Reset();
                PlayerConfig = playerConfig;
                SaveFromPlayerConfigToModel();
                return;
            }

            string fromJson = File.ReadAllText(_filePathPlayerConfig);
            
            PlayerConfig = JsonUtility.FromJson<PlayerConfig>(fromJson);

            SaveFromPlayerConfigToModel();
        }

        public void SaveFromPlayerConfigToModel()
        {
            PlayerConfigModel.Health.Value = PlayerConfig.Health;
            PlayerConfigModel.Armor.Value = PlayerConfig.Armor;
            PlayerConfigModel.Money.Value = PlayerConfig.Money;
            PlayerConfigModel.IsHasPistol.Value = PlayerConfig.IsHasPistol;
            PlayerConfigModel.IsHasAssaultRifle.Value = PlayerConfig.IsHasAssaultRifle;
        }

        public void SaveFromModelToPlayerConfig()
        {
            PlayerConfig.Health = PlayerConfigModel.Health.Value;
            PlayerConfig.Armor = PlayerConfigModel.Armor.Value;
            PlayerConfig.Money = PlayerConfigModel.Money.Value;
            PlayerConfig.IsHasPistol = PlayerConfigModel.IsHasPistol.Value;
            PlayerConfig.IsHasAssaultRifle = PlayerConfigModel.IsHasAssaultRifle.Value;
        }

        public void SaveToFileData()
        {
            string toJson = JsonUtility.ToJson(SaveData, true);

            File.WriteAllText(_filePathData, toJson);
        }

        public SaveData LoadFromFileData()
        {
            if (!File.Exists(_filePathData))
            {
                SaveData save = new SaveData();
                SaveData = save;
                return SaveData;
            }

            string fromJson = File.ReadAllText(_filePathData);

            return SaveData = JsonUtility.FromJson<SaveData>(fromJson);
        }
    }
}