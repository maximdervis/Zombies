using System;
using System.Collections;
using Abstractions.Interfaces;
using UnityEngine;


public class ClassicPlayerViewTransformer : MonoBehaviour, IPlayerViewTransformer
{
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private float zoomFactor; 
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Transform playerBodyTransform;
    [SerializeField] private Transform playerNeck;
    
    [SerializeField] private float minRotationXAngle;
    [SerializeField] private float maxRotationXAngle;

    [SerializeField] private float minRotationYAngle;
    [SerializeField] private float maxRotationYAngle;
    
    [SerializeField] private Camera cameraToZoom;
    [SerializeField] private float zoomInSpeed;
    [SerializeField] private float zoomOutSpeed; 

    private float m_startCameraFov;
    private bool m_zoomEnabled; 
    
    private float m_currentXRotation;
    private float m_currentYRotation; 
    
    
    public void ScrollViewHorizontally(float horizontalAxis)
    {
        var mouseX = horizontalAxis * mouseSensitivity * Time.deltaTime;

        m_currentYRotation += mouseX;
        m_currentYRotation = Mathf.Clamp(m_currentYRotation, minRotationYAngle, maxRotationYAngle);

        playerBodyTransform.localRotation = Quaternion.Euler(0f, m_currentYRotation, 0f);
        playerNeck.localRotation = Quaternion.Euler(0f, m_currentYRotation, 0f);
    }

    public void ScrollViewVertically(float verticalAxis)
    {
        var mouseY = verticalAxis * mouseSensitivity * Time.deltaTime;

        m_currentXRotation -= mouseY;
        m_currentXRotation = Mathf.Clamp(m_currentXRotation, minRotationXAngle, maxRotationXAngle);

        cameraTransform.localRotation = Quaternion.Euler(m_currentXRotation, 0f, 0f);


    }

    public void ZoomIn()
    {
        m_zoomEnabled = true;
    }

    public void ZoomOut()
    {
        m_zoomEnabled = false;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        m_startCameraFov = cameraToZoom.fieldOfView;
    }

    private void Update()
    {
        if (m_zoomEnabled)
        {
            cameraToZoom.fieldOfView = Mathf.Lerp(cameraToZoom.fieldOfView, 
                                                m_startCameraFov / zoomFactor, 
                                                zoomInSpeed);
        }
        else
        {
            cameraToZoom.fieldOfView = Mathf.Lerp(cameraToZoom.fieldOfView, 
                                                m_startCameraFov, 
                                                zoomOutSpeed);
        }
    }

    private void OnValidate()
    {
        if (minRotationXAngle > maxRotationXAngle)
        {
            minRotationXAngle = maxRotationXAngle - float.Epsilon;
        }

        if (minRotationYAngle > maxRotationYAngle)
        {
            minRotationYAngle = maxRotationYAngle - float.Epsilon;
        }
    }
}