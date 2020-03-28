using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideForceFieldUi : MonoBehaviour
{
    private ForceFieldVanish _forceField;
    
    void Start()
    {
        _forceField =  GetComponentInParent<ForceFieldVanish>();
    }

    void Update()
    {
        if (_forceField && _forceField.GetForceFieldState())
            DestroyGameObject();
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
