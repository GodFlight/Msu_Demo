using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInteractWithObjects : MonoBehaviour
{
    private Camera _camera;
    private Dictionary<int, List<IInteractable>> _cachedComponents = new Dictionary<int, List<IInteractable>>();

    private List<IInteractable> _lastFrameInteractionObjects;
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
                var interactables = GetCachedComponents(interactiveObject);
                foreach (IInteractable interactable in interactables)
                {
                    interactable.ShowUsability();
                    if (Input.GetKey(KeyCode.E))
                        interactable.Interact();
                }
                _lastFrameInteractionObjects = interactables;
            }
            else if (_lastFrameInteractionObjects != null)
            {
                foreach (IInteractable interactable in _lastFrameInteractionObjects)
                {
                    interactable.HideUsability();
                }
                _lastFrameInteractionObjects = null;
            }
        }
    }

    private List<IInteractable> GetCachedComponents(GameObject interactableObject)
    {
        List<IInteractable> interactables;
        int instanceId = interactableObject.GetInstanceID();
        
        if (_cachedComponents.TryGetValue(instanceId, out interactables))
            return interactables;
        interactables = new List<IInteractable>(interactableObject.GetComponents<IInteractable>());
        _cachedComponents.Add(instanceId, interactables);
        return interactables;
    }
}
