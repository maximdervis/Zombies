using System;
using Abstractions.Interfaces;
using UnityEngine;
using UnityEngine.Events;

public class MousePlayerController : MonoBehaviour, IPlayerController
{
    public void AddHandlerToOnMouseMoveVerticallyEvent(UnityAction<float> moveMouseEventHandler)
    {
        throw new NotImplementedException();
    }

    public void RemoveHandlerFromOnMouseMoveVerticallyEvent(UnityAction<float> moveMouseEventHandler)
    {
        throw new NotImplementedException();
    }

    public void AddHandlerToMouseMoveHorizontallyEvent(UnityAction<float> moveMouseEventHandler)
    {
        throw new NotImplementedException();
    }

    public void RemoveHandlerFromMouseMoveHorizontallyEvent(UnityAction<float> moveMouseEventHandler)
    {
        throw new NotImplementedException();
    }

    public void AddHandlerToZoomButtonPressedEvent(UnityAction scopeEventHandler)
    {
        throw new NotImplementedException();
    }

    public void RemoveHandlerFromZoomButtonPressedEvent(UnityAction scopeEventHandler)
    {
        throw new NotImplementedException();
    }

    public void AddHandlerToZoomButtonReleasedEvent(UnityAction zoomOutEventHandler)
    {
        throw new NotImplementedException();
    }

    public void RemoveHandlerFromZoomButtonReleasedEvent(UnityAction zoomOutEventHandler)
    {
        throw new NotImplementedException();
    }
}
