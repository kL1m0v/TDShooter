using System;
using UnityEngine;

namespace TopDownShooter
{
    [Serializable]
    public class AudioClipWrap
    {
        [SerializeField]
        private string _name;
        [SerializeField]
        private AudioClip clip;

        public AudioClip Clip { get => clip; }
        public string Name { get => _name; }
    }
}