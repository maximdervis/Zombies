using UnityEngine.Events;

namespace Abstractions.Player
{
    public interface IPlayerHorizontalScrollerController
    {
        void AddHandlerToMouseMoveHorizontallyEvent(UnityAction<float> moveMouseEventHandler);
        void RemoveHandlerFromMouseMoveHorizontallyEvent(UnityAction<float> moveMouseEventHandler);
    }
}