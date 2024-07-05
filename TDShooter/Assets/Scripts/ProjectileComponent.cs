using System.Collections;
using UnityEngine;

namespace TopDownShooter
{
    public class ProjectileComponent : MonoBehaviour
    {
        [SerializeField, Range(0, 200f)]
        private float _speed;
        [SerializeField, Range(0, 5f)]
        private float _lifeTime;
        private float _constLifeTime;
        private int _damage;

        public int Damage { get => _damage; set => _damage = value; }

        private void Awake()
        {
            _constLifeTime = _lifeTime;
        }

        private void OnEnable()
        {
            _lifeTime = _constLifeTime;
            StartCoroutine(Disable());
        }

        private IEnumerator Disable()
        {
            while (_lifeTime > 0)
            {
                transform.position += Time.deltaTime * _speed * transform.forward;
                _lifeTime -= Time.deltaTime;
                yield return null;
            }
            gameObject.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent<PlayerManager>(out PlayerManager player))
            {
                player.TakeDamage(Damage);
            }
            gameObject.SetActive(false);
        }
    }
}