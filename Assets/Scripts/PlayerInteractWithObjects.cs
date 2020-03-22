using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInteractWithObjects : MonoBehaviour
{
    private Camera _camera;
    private Dictionary<int, IInteractable> _cachedComponents = new Dictionary<int, IInteractable>();

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
            {
                IInteractable button = GetCachedComponent(interactiveObject);
                button.ShowUsability();
                if (Input.GetKey(KeyCode.E))
                    button.Interact();
            }
        }
    }

    private IInteractable GetCachedComponent(GameObject interactableObject)
    {
        IInteractable interactable;
        int instanceId = interactableObject.GetInstanceID();

        if (_cachedComponents.TryGetValue(instanceId, out interactable))
            return interactable;
        interactable = interactableObject.GetComponent<IInteractable>();
        _cachedComponents.Add(instanceId, interactable);
        return interactable;
    }
}
