using UnityEngine;

namespace TopDownShooter
{
    public abstract class BaseCharacter : MonoBehaviour, IDamageable
    {
        [SerializeField]
        [Range(1, 500)]
        private int _healthPoints;
        
        public int HealthPoints
        {
            get { return _healthPoints; }
            private set 
            {
                _healthPoints = value; 
                if (_healthPoints < 0)
                {
                    _healthPoints = 0;
                }
            }
        }

        public virtual void TakeDamage(int damage)
        {
            HealthPoints -= damage;
            if (HealthPoints == 0)
            {
                Die();
            }
        }
        
        public virtual void Die() {}
    }
}

    
