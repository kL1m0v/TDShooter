using UnityEngine;

namespace TopDownShooter
{
    public class MeleeEnemyAttackCollisionDetector : MonoBehaviour
    {
        private int _damage;
        
        private void Start()
        {
            _damage = GetComponentInParent<EnemyBase>().Damage;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out PlayerManager player))
            {
                player.TakeDamage(_damage);
            }
        }
    }
}