using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDetector : MonoBehaviour
{
    [SerializeField] protected MonoBehaviour[] detectionHandlers;
    
    public void OnTriggerEnter(Collider other)
    {
        HandleDetections();
    }

    public void OnTriggerExit(Collider other)
    {
        HandleDetections();
    }

    private void HandleDetections()
    {
        foreach (var detectionHandler in detectionHandlers)
        {
            (detectionHandler as IInteractionTarget)?.HandleInteraction();
        }
    }
}
