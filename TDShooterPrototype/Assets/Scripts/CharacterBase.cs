using UnityEngine;

namespace TopDownShooter
{
    public abstract class CharacterBase : MonoBehaviour, IDamageable
    {
        [SerializeField]
        [Range(1, 100)]
        private int _healthPoints;

        protected int HealthPoints
        {
            get { return _healthPoints; }
            set 
            { 
                _healthPoints = value; 
                if (_healthPoints < 0)
                {
                    _healthPoints = 0;
                }
                //todo инкапсулировать правильно hp
            }
        }

        public void TakeDamage(int damage)
        {
            // todo
        }
        
        void IDamageable.Die()
        {
            if (_healthPoints == 0) 
            {
                Debug.Log("die");
            }
        }
    }
}

    
