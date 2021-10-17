using System;
using Abstractions.Interfaces;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class MoveMouseEvent : UnityEvent<float>
{
    
}

public class MousePlayerController : MonoBehaviour, IPlayerController
{
    private MoveMouseEvent m_onMouseMoveHorizontally;
    private MoveMouseEvent m_onMouseMoveVertically;
    private UnityEvent m_onZoomButtonPressed;
    private UnityEvent m_onZoomButtonReleased;

    public MousePlayerController(MoveMouseEvent onMouseMoveVertically)
    {
        this.m_onMouseMoveVertically = onMouseMoveVertically;
    }

    public void AddHandlerToOnMouseMoveVerticallyEvent(UnityAction<float> moveMouseVerticallyEventHandler)
    {
        m_onMouseMoveVertically.AddListener(moveMouseVerticallyEventHandler);
    }

    public void RemoveHandlerFromOnMouseMoveVerticallyEvent(UnityAction<float> moveMouseVerticallyEventHandler)
    {
        m_onMouseMoveVertically.RemoveListener(moveMouseVerticallyEventHandler);
    }

    public void AddHandlerToMouseMoveHorizontallyEvent(UnityAction<float> moveMouseHorizontallyEventHandler)
    {
        m_onMouseMoveHorizontally.AddListener(moveMouseHorizontallyEventHandler);
    }

    public void RemoveHandlerFromMouseMoveHorizontallyEvent(UnityAction<float> moveMouseHorizontallyEventHandler)
    {
        m_onMouseMoveHorizontally.RemoveListener(moveMouseHorizontallyEventHandler);
    }

    public void AddHandlerToZoomButtonPressedEvent(UnityAction zoomInEventHandler)
    {
        m_onZoomButtonPressed.AddListener(zoomInEventHandler);
    }

    public void RemoveHandlerFromZoomButtonPressedEvent(UnityAction zoomInEventHandler)
    {
        m_onZoomButtonPressed.RemoveListener(zoomInEventHandler);
    }

    public void AddHandlerToZoomButtonReleasedEvent(UnityAction zoomOutEventHandler)
    {
        m_onZoomButtonReleased.AddListener(zoomOutEventHandler);
    }

    public void RemoveHandlerFromZoomButtonReleasedEvent(UnityAction zoomOutEventHandler)
    {
        m_onZoomButtonReleased.RemoveListener(zoomOutEventHandler);
    }

    private void Awake()
    {
        m_onMouseMoveHorizontally = new MoveMouseEvent();
        m_onMouseMoveVertically = new MoveMouseEvent();
        m_onZoomButtonPressed = new UnityEvent();
        m_onZoomButtonReleased = new UnityEvent();
    }

    private void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        m_onMouseMoveVertically.Invoke(Input.GetAxis("Mouse Y"));
        m_onMouseMoveHorizontally.Invoke(Input.GetAxis("Mouse X"));
        

        if (Input.GetButtonDown("Fire2"))
        {
            m_onZoomButtonPressed.Invoke();
        }
        
        if (Input.GetButtonUp("Fire2"))
        {
            m_onZoomButtonReleased.Invoke();
        }
    }
}
