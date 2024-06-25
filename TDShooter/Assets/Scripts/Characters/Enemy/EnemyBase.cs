using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public class EnemyBase: BaseCharacter
    {
        [SerializeField, Range(0, 15f)]
        private float _detectDistance;

        public float DetectDistance => _detectDistance;
    }
}