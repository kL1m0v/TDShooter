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
    }
}