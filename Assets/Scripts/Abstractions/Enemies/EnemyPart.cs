using UnityEngine;

namespace Abstractions.Enemies
{
    public abstract class EnemyPart : MonoBehaviour
    {
        [SerializeField] private int passingDamage; 
        private Enemy m_parentEnemy;

        protected void SetParentEnemy(Enemy parentEnemy)
        {
            m_parentEnemy = parentEnemy; 
        }

        public void SetPassingDamage(int passingDamage)
        { 
            this.passingDamage = passingDamage; 
        }

        public void PassDamage()
        {
            m_parentEnemy.TakeDamage(passingDamage);
        }
        
        
    }
}