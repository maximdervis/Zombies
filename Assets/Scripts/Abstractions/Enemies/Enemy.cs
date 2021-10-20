
using System;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.Events;

namespace Abstractions.Enemies
{
    public class EnemyEvent : UnityEvent<Enemy> {}

    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] private int health;
        
        private float m_moveSpeed;
        private float m_moveDistance;
        private int m_spawnIndex;

        private EnemyEvent m_onDead;
        private UnityEvent m_onFinishedMovement;

        public void AddHandlerToFinishedMovementEvent(UnityAction finishedMovementHandler)
        {
            if (m_onFinishedMovement == null)
            {
                m_onFinishedMovement = new UnityEvent();
            }
            m_onFinishedMovement.AddListener(finishedMovementHandler);
        }

        protected void InvokeFinishedMovementEvent()
        {
            m_onFinishedMovement?.Invoke();
        }
        
        public int SpawnIndex
        {
            get => m_spawnIndex;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException();
                }
                
                m_spawnIndex = value;
            }
        }

        public float MoveSpeed
        {
            get => m_moveSpeed;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                m_moveSpeed = value; 
            }
        }
        public float MoveDistance
        {
            get => m_moveDistance;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                m_moveDistance = value; 
            }
        }
        
        
        public virtual void TakeDamage(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                m_onDead?.Invoke(this);
                Destroy(gameObject);
            }
        }

        public void AddHandlerToDeadEvent(UnityAction<Enemy> onDeadHandler)
        {
            if (m_onDead == null)
            {
                m_onDead = new EnemyEvent();
            } 
            m_onDead.AddListener(onDeadHandler);
        }
        
        public Enemy Instantiate(Transform transformToInstantiate)
        {
            var instantiatedEnemy = Instantiate(this, transformToInstantiate);
            return instantiatedEnemy;
        }
        public abstract void StartMoving();

        private void OnValidate()
        {
            if (health <= 0)
            {
                health = 1;
            }
        }

        private void OnDestroy()
        {
            
        }   
        
    }
}