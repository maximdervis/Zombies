using Abstractions.Interfaces;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerShooter : MonoBehaviour, IPlayerShooter
{
    [SerializeField] private Camera cameraToThrowRay;
    
    public bool Shoot([CanBeNull] out GameObject target)
    {
        var ray = cameraToThrowRay.ScreenPointToRay(cameraToThrowRay.transform.position);
        if (Physics.Raycast(ray, out var hitTarget))
        {
            target = hitTarget.collider.gameObject;
            return hitTarget.collider != null;
        }
        else
        {
            target = null;
            return false;
        }
    }
}
