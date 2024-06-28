using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TopDownShooter
{
    [RequireComponent(typeof(AudioSource))]
    public class EnemyBase: BaseCharacter
    {
        [SerializeField, Range(0, 15f)]
        protected float _detectDistance;
        [SerializeField]
        protected List<AudioClipWrap> _sounds;
        protected AudioSource _audioSource;

        public float DetectDistance => _detectDistance;

        protected virtual void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public AudioClip GetAudioClip(string name)
        {
            AudioClipWrap audioClipWrap = _sounds.Where(s => s.Name == name).FirstOrDefault();
            return audioClipWrap.Clip;
        }
    }
}