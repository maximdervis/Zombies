using UnityEngine.Events;

namespace Abstractions.Player
{
    public interface IPlayerVerticalScrollerController
    {
        void AddHandlerToOnMouseMoveVerticallyEvent(UnityAction<float> moveMouseEventHandler);
        void RemoveHandlerFromOnMouseMoveVerticallyEvent(UnityAction<float> moveMouseEventHandler);
    }
}