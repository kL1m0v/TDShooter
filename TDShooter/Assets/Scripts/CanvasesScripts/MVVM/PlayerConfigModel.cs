using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace TopDownShooter
{
    public class PlayerConfigModel
    {
        public readonly ReactiveProperty<int> Health = new();
        public readonly ReactiveProperty<int> Armor = new();

        public readonly ReactiveProperty<int> Money = new();

        public readonly ReactiveProperty<bool> IsHasPistol = new();
        public readonly ReactiveProperty<bool> IsHasAssaultRifle = new();

        public readonly int PricePerCharacteristic = 10;
        public readonly int PriceOfPistol = 100;
        public readonly int PriceOfAssaultRifle = 200;
    }
}