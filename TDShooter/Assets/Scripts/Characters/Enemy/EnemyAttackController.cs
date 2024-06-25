using UnityEngine;

namespace TopDownShooter
{
    public class EnemyAttackController
    {
        private Collider _colliderForAttack;
        
        public EnemyAttackController(Collider colliderForAttack)
        {
            _colliderForAttack = colliderForAttack;
            EnableCollider();
            //DisableCollider();
        }

        public void EnableCollider()
        {
            _colliderForAttack.enabled = true;
        }

        public void DisableCollider() 
        { 
            _colliderForAttack.enabled = false;
        }
    }
}