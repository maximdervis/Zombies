using Abstractions.Player;
using UnityEngine;

namespace Implementations.Player
{
    [RequireComponent(typeof(IPlayerController))]
    [RequireComponent(typeof(IPlayerViewTransformer))]
    [RequireComponent(typeof(IPlayerUI))]
    [RequireComponent(typeof(IPlayerShooter))]
    public class Player : MonoBehaviour
    {
        private IPlayerController m_playerController;
        private IPlayerViewTransformer m_playerViewTransformer;
        private IPlayerUI m_playerUI;
        private IPlayerShooter m_playerShooter;
    
        private void Start()
        {
            GetDependenciesComponents();
            SetupEventHandlers();
        }

        private void GetDependenciesComponents()
        {
            m_playerController = GetComponent<IPlayerController>();
            m_playerViewTransformer = GetComponent<IPlayerViewTransformer>();
            m_playerUI = GetComponent<IPlayerUI>();
            m_playerShooter = GetComponent<IPlayerShooter>();
        }
    
        private void SetupEventHandlers()
        {
            m_playerController.AddHandlerToZoomButtonPressedEvent(m_playerViewTransformer.ZoomIn);
            m_playerController.AddHandlerToZoomButtonPressedEvent(m_playerUI.EnableZoomView);
        
            m_playerController.AddHandlerToZoomButtonReleasedEvent(m_playerViewTransformer.ZoomOut);
            m_playerController.AddHandlerToZoomButtonReleasedEvent(m_playerViewTransformer.EnableKickBack);
            m_playerController.AddHandlerToZoomButtonReleasedEvent(m_playerUI.DisableZoomView);
            m_playerController.AddHandlerToZoomButtonReleasedEvent(m_playerShooter.Shoot);
        
            m_playerController.AddHandlerToMouseMoveHorizontallyEvent(m_playerViewTransformer.ScrollViewHorizontally);
            m_playerController.AddHandlerToOnMouseMoveVerticallyEvent(m_playerViewTransformer.ScrollViewVertically);
        
        
        }
    }
}
