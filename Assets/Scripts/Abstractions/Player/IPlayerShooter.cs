
using UnityEngine.Events;

namespace Abstractions.Player
{
    public interface IPlayerShooter
    {
        void Shoot();
        void AddHandlerToShootEvent(UnityAction shootEventHandler); 
    }
}
