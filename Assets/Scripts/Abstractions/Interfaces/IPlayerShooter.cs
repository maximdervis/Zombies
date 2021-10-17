
using UnityEngine;

namespace Abstractions.Interfaces
{
    public interface IPlayerShooter
    {
        bool Shoot(out GameObject gotTarget);
    }
}
