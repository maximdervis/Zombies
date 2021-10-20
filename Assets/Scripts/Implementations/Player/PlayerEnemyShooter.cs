using Abstractions.Enemies;
using Abstractions.Player;
using UnityEngine;
using UnityEngine.Events;

namespace Implementations.Player
{
    public class PlayerEnemyShooter : MonoBehaviour, IPlayerShooter
    {
        [SerializeField] private Camera cameraToThrowRay;

        private UnityEvent m_onShoot; 
        
        public void Shoot()
        {
            var ray = cameraToThrowRay.ScreenPointToRay(Input.mousePosition);
        
            if (!Physics.Raycast(ray, out var hitTarget))
            {
                return;
            }
            
            if (!hitTarget.collider.TryGetComponent<EnemyPart>(out var enemyComponent))
            {
                return;
            }
            enemyComponent.PassDamage();
        }

        public void AddHandlerToShootEvent(UnityAction shootEventHandler)
        {
            m_onShoot.AddListener(shootEventHandler);
        }
        
        
    }
}
