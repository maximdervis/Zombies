using System;
using System.Collections;
using System.Collections.Generic;
using Abstractions.Interfaces;
using UnityEngine;

[RequireComponent(typeof(IPlayerController))]
[RequireComponent(typeof(IPlayerViewTransformer))]
public class Player : MonoBehaviour
{
    private IPlayerController m_playerController;
    private IPlayerViewTransformer m_playerViewTransformer;

    private void Start()
    {
        GetDependenciesComponents();
        SetupEventHandlers(); 
    }

    private void GetDependenciesComponents()
    {
        m_playerController = GetComponent<IPlayerController>();
        m_playerViewTransformer = GetComponent<IPlayerViewTransformer>();
    }
    
    private void SetupEventHandlers()
    {
        m_playerController.AddHandlerToZoomButtonPressedEvent(m_playerViewTransformer.ZoomIn);
        m_playerController.AddHandlerToZoomButtonReleasedEvent(m_playerViewTransformer.ZoomOut);
        m_playerController.AddHandlerToMouseMoveHorizontallyEvent(m_playerViewTransformer.ScrollViewHorizontally);
        m_playerController.AddHandlerToMouseMoveHorizontallyEvent(m_playerViewTransformer.ScrollViewVertically);
    }
}
