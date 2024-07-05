using System.Collections;
using UnityEngine;

namespace TopDownShooter
{
    public class BulletComponent : MonoBehaviour
    {
        private TrailRenderer _trailRenderer;
        [SerializeField, Range(0, 200f)]
        private float _speed;
        [SerializeField, Range(0, 2f)]
        private float _lifeTime;
        private float _constLifeTime;

        private void Awake()
        {
            _constLifeTime = _lifeTime;
            _trailRenderer = GetComponent<TrailRenderer>();
        }

        private void OnEnable()
        {
            _lifeTime = _constLifeTime;
            StartCoroutine(Disable());
        }

        private IEnumerator Disable()
        {
            _trailRenderer.emitting = true;
            while (_lifeTime > 0) 
            {
                transform.position += Time.deltaTime * _speed * transform.forward;
                _lifeTime -= Time.deltaTime;
                yield return null;
            }
            _trailRenderer.emitting = false;
            gameObject.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("OnTriggerEnter");
        }
    }
}