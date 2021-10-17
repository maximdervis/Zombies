using UnityEngine;
using Abstractions.Interfaces;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour, IPlayerUI
{
    [SerializeField] private Image simpleCrosshair;
    [SerializeField] private Image zoomCrosshair; 

    public void EnableZoomView()
    {
        simpleCrosshair.enabled = false;
        zoomCrosshair.enabled = true;
    }

    public void DisableZoomView()
    {
        simpleCrosshair.enabled = true;
        zoomCrosshair.enabled = false;
    }
}
