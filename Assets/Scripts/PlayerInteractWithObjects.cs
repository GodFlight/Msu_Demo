using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInteractWithObjects : MonoBehaviour
{
    private Camera _camera;
    private Dictionary<int, IInteractable> _cachedComponents = new Dictionary<int, IInteractable>();

    private IInteractable _lastFrameInteractionObject;
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
            var interactiveObject = hitInfo.collider.gameObject;
            if (interactiveObject.CompareTag("Interactive"))
            {
                var interactable = GetCachedComponent(interactiveObject);
                interactable.ShowUsability();
                if (Input.GetKey(KeyCode.E))
                    interactable.Interact();
                _lastFrameInteractionObject = interactable;
            }
            else if (_lastFrameInteractionObject != null)
            {
                _lastFrameInteractionObject.HideUsability();
                _lastFrameInteractionObject = null;
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
