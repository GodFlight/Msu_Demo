using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideForButtonUi : MonoBehaviour
{
    private InteractionButton button;
    
    void Start()
    {
        button = GetComponentInParent<InteractionButton>();
    }

    void Update()
    {
        if (button && button.GetButtonState())
            DestroyGameObject();
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
