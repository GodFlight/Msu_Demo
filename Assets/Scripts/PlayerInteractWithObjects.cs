using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInteractWithObjects : MonoBehaviour
{
    private Camera _camera;
    void Start()
    {
        _camera = GetComponentInChildren<Camera>();
    }
    
    void Update()
    {
        GetInteraction();
    }

    private void GetInteraction()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            GameObject interactiveObject = hitInfo.collider.gameObject;
            if (interactiveObject.CompareTag("Interactive"))
                interactiveObject.GetComponent<IInteractable>().ShowUsability();
        }
    }
}
