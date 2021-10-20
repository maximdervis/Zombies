using System;
using UnityEngine;
using UnityEngine.Windows.Speech;

namespace Implementations.Enemy
{
    public class ZombieEnemy : Abstractions.Enemies.Enemy
    {
        
        private bool m_moveUp;
        private float m_maxZombieHeight;

        public override void StartMoving()
        {     
            m_moveUp = true;
            m_maxZombieHeight = transform.position.y + MoveDistance;
        }

        private void Update()
        {
            if (m_moveUp && transform.position.y < m_maxZombieHeight)
            {
                transform.position += Vector3.up * MoveSpeed * Time.deltaTime;
            }
            else if (transform.position.y >= m_maxZombieHeight)
            {
                InvokeFinishedMovementEvent();
            }
        }
    }
}