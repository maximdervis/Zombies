using UnityEngine.Events;

namespace Abstractions.Interfaces
{
    public interface IPlayerHorizontalScrollerController
    {
        void AddHandlerToMouseMoveHorizontallyEvent(UnityAction<float> moveMouseEventHandler);
        void RemoveHandlerFromMouseMoveHorizontallyEvent(UnityAction<float> moveMouseEventHandler);
    }
}