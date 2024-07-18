using System;
using Zenject;

namespace TopDownShooter
{
    [Serializable]
    public class PlayerConfig
    {
        [Inject]
        private PlayerConfigModel playerConfigModel;

        public int Health;
        public int Armor;
        public int Money;
        public bool IsHasPistol;
        public bool IsHasAssaultRifle;

        public void Reset()
        {
            Health = 100;
            Armor = 0;
            Money = 0;
            IsHasPistol = true;
            IsHasAssaultRifle = false;
        }
    }
}