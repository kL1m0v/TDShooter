using System.Collections;
using UnityEngine;
using Zenject;

namespace TopDownShooter
{
    public class WeaponComponent : MonoBehaviour
    {
        [Inject (Id = "PlayerBullPool")]
        private ObjectPool _poolOfBullets;
        private const string _path = "BulletPrefab";
        private GameObject _bulletPref;

        private AudioSource _audioSource;

        [SerializeField]
        private Transform _RightHandGrip;
        [SerializeField]
        private Transform _LeftHandGrip;
        [SerializeField]
        private Transform _muzzle;
        [SerializeField]
        private int _damage;
        [SerializeField]
        private float _delayBetweenShots;
        private float _constDelayBetweenShots;
        private bool _canShoot;

        public Transform RightHandGrip { get => _RightHandGrip; }
        public Transform LeftHandGrip { get => _LeftHandGrip; }
        public Transform Muzzle { get => _muzzle; }
        public int Damage { get => _damage; }

        private void OnEnable()
        {
            _canShoot = true;
        }

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _bulletPref = Resources.Load<GameObject>(_path);
            _constDelayBetweenShots = _delayBetweenShots;
        }

        private void OnValidate()
        {
            _constDelayBetweenShots = _delayBetweenShots;
        }

        public void Shoot()
        {
            if (_canShoot) 
            {
                _audioSource.Play();
                InstantiateBullet();
                _canShoot = false;
                StartCoroutine(ReloadWeapon());
                Ray ray = new(_muzzle.transform.position, _muzzle.transform.forward);
                if (Physics.Raycast(ray, out RaycastHit hitInfo))
                {
                    if (hitInfo.transform.TryGetComponent<IDamageable>(out IDamageable entity))
                    {
                        entity.TakeDamage(Damage);
                    }
                }
            }
        }

        private void InstantiateBullet()
        {
            GameObject bullet = _poolOfBullets.Get(false);
            bullet.transform.SetPositionAndRotation(_muzzle.position, _muzzle.rotation);
            bullet.SetActive(true);
        }

        private IEnumerator ReloadWeapon()
        {
            while(_delayBetweenShots >= 0)
            {
                _delayBetweenShots -= Time.deltaTime;
                yield return null;
            }
            _canShoot = true;
            _delayBetweenShots = _constDelayBetweenShots;
        }
    }
}
