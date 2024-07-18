using UnityEngine;

namespace TopDownShooter
{
    public abstract class BaseCharacter : MonoBehaviour, IDamageable
    {
        [SerializeField]
        [Range(1, 500)]
        protected int _healthPoints;
        
        public int CurrentHealthPoints
        {
            get { return _healthPoints; }
            protected set 
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
            CurrentHealthPoints -= damage;
            if (CurrentHealthPoints == 0)
            {
                Die();
            }
        }
        
        public virtual void Die() {}
    }
}

    
