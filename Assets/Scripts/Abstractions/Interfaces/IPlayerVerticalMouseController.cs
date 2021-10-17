using UnityEngine.Events;

namespace Abstractions.Interfaces
{
    public interface IPlayerVerticalScrollerController
    {
        void AddHandlerToOnMouseMoveVerticallyEvent(UnityAction<float> moveMouseEventHandler);
        void RemoveHandlerFromOnMouseMoveVerticallyEvent(UnityAction<float> moveMouseEventHandler);
    }
}