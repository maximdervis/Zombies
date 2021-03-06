using UnityEngine.Events;

namespace Abstractions.Player
{
    public interface IPlayerController : IPlayerVerticalScrollerController, IPlayerHorizontalScrollerController
    {
        void AddHandlerToZoomButtonPressedEvent(UnityAction zoomInEventHandler);
        void RemoveHandlerFromZoomButtonPressedEvent(UnityAction zoomInEventHandler); 
        
        void AddHandlerToZoomButtonReleasedEvent(UnityAction zoomOutEventHandler);
        void RemoveHandlerFromZoomButtonReleasedEvent(UnityAction zoomOutEventHandler);
    }
}

