using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Abstractions.Enemies;
using UnityEngine;

namespace Implementations
{
    public class ZombieSpawner : MonoBehaviour
    {
        [SerializeField] private Abstractions.Enemies.Enemy enemy; 
        
        [SerializeField] private Transform[] positionsToSpawn;
        [SerializeField] private float timeBetweenSpawnSeconds;
        [SerializeField] private int startZombieHealth;
        [SerializeField] private float zombieMoveDistance; 

        [SerializeField] private float startZombieSpeed;
        [SerializeField] private int zombieSpeedIncreasePercent; 
        
        private bool m_continueSpawning;
        private Transform m_previousSpawnPosition;
        private int m_currentZombieNumber;
        private HashSet<int> m_freePositionsIndexesToSpawn;

        private float m_currentZombieSpeed; 

        private void StartSpawning()
        {
            m_continueSpawning = true;
            m_freePositionsIndexesToSpawn = new HashSet<int>();
            
            for (var i = 0; i < positionsToSpawn.Length; ++i)
                m_freePositionsIndexesToSpawn.Add(i);
            

            StartCoroutine(SpawnEnemies());
        }

        public void StopSpawning()
        {
            m_continueSpawning = false;
            m_currentZombieNumber = 0;
        }

        private IEnumerator SpawnEnemies()
        {
            var waitForTimeBetweenSpawnSeconds = new WaitForSeconds(timeBetweenSpawnSeconds);
            while (m_continueSpawning)
            {
                if (m_freePositionsIndexesToSpawn.Count == 0)
                {
                    yield return waitForTimeBetweenSpawnSeconds;
                }
                else
                {
                    m_currentZombieNumber++;

                    var spawnedEnemy = SpawnRandomEnemy();
                    spawnedEnemy.MoveSpeed = m_currentZombieSpeed;
                    m_currentZombieSpeed *= 1 + zombieSpeedIncreasePercent / 100;
                    spawnedEnemy.MoveDistance = zombieMoveDistance;

                    spawnedEnemy.StartMoving();
                    yield return waitForTimeBetweenSpawnSeconds;
                }
            }   
        }

        private Abstractions.Enemies.Enemy SpawnRandomEnemy()
        {
            var randomPositionIndex = UnityEngine.Random.Range(0, m_freePositionsIndexesToSpawn.Count);
            var freePositionsIndexes = m_freePositionsIndexesToSpawn.ToArray();
            var randomSpawnPosition = positionsToSpawn[freePositionsIndexes[randomPositionIndex]];
            m_freePositionsIndexesToSpawn.Remove(freePositionsIndexes[randomPositionIndex]);
            
            var instantiatedEnemy = enemy.Instantiate(randomSpawnPosition);
            instantiatedEnemy.AddHandlerToFinishedMovementEvent(Lose);
            instantiatedEnemy.AddHandlerToDeadEvent(OnZombieDead);
            instantiatedEnemy.SpawnIndex = freePositionsIndexes[randomPositionIndex];
            return instantiatedEnemy;
        }

        private void Lose()
        {
            
        }
        
        private void OnZombieDead(Abstractions.Enemies.Enemy dyingEnemy)
        {
            m_freePositionsIndexesToSpawn.Add(dyingEnemy.SpawnIndex);   
        }
        
        private void Start()
        {
            m_continueSpawning = false;
            m_currentZombieSpeed = startZombieSpeed;
            StartSpawning();
        }
    }
}
