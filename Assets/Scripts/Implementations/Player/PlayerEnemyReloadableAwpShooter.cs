using System.Collections;
using UnityEngine;

namespace Implementations.Player
{
    public class PlayerEnemyReloadableAwpShooter : PlayerEnemyShooter
    {
        [SerializeField] private int maxBullets;
        [SerializeField] private int reloadingTimeSeconds;
        [SerializeField] private int timeBetweenShootsSeconds;

        private int m_bulletsLeft;
        private bool m_mayShoot;

        private WaitForSeconds m_waitBetweenShoots;
        private WaitForSeconds m_waitForReloading; 
        
        private void Start()
        {
            m_bulletsLeft = maxBullets;
            m_waitBetweenShoots = new WaitForSeconds(timeBetweenShootsSeconds);
            m_waitForReloading = new WaitForSeconds(reloadingTimeSeconds);
        }

        public new void Shoot()
        {
            if (m_bulletsLeft <= 0 || !m_mayShoot)
            {
                m_mayShoot = false;
                m_bulletsLeft--;
                StartCoroutine(Reload());
                return; 
            } 
            
            
            base.Shoot();
            m_bulletsLeft--;
            m_mayShoot = true;
            StartCoroutine(WaitBetweenShoots());
            
        }

        private IEnumerator Reload()
        {
            yield return m_waitForReloading;
            m_mayShoot = false;
        }

        private IEnumerator WaitBetweenShoots()
        {
            yield return m_waitBetweenShoots;
            m_mayShoot = false; 
        }
    }
}
