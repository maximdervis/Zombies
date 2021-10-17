using System;
using System.Collections;
using System.Collections.Generic;
using Abstractions.Interfaces;
using UnityEngine;

[RequireComponent(typeof(IPlayerController))]
[RequireComponent(typeof(IPlayerViewTransformer))]
[RequireComponent(typeof(IPlayerUI))]
public class Player : MonoBehaviour
{
    private IPlayerController m_playerController;
    private IPlayerViewTransformer m_playerViewTransformer;
    private IPlayerUI m_playerUI;
    
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
    }
    
    private void SetupEventHandlers()
    {
        m_playerController.AddHandlerToZoomButtonPressedEvent(m_playerViewTransformer.ZoomIn);
        m_playerController.AddHandlerToZoomButtonPressedEvent(m_playerUI.EnableZoomView);
        
        m_playerController.AddHandlerToZoomButtonReleasedEvent(m_playerViewTransformer.ZoomOut);
        m_playerController.AddHandlerToZoomButtonReleasedEvent(m_playerUI.DisableZoomView);
        
        m_playerController.AddHandlerToMouseMoveHorizontallyEvent(m_playerViewTransformer.ScrollViewHorizontally);
        m_playerController.AddHandlerToOnMouseMoveVerticallyEvent(m_playerViewTransformer.ScrollViewVertically);
    }
}
