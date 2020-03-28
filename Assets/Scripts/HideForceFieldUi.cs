using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideForceFieldUi : MonoBehaviour
{

    [SerializeField] private GameObject  _forceFieldGameObject;

    private ForceFieldVanish _forceField;
    
    void Start()
    {
        _forceField =  _forceFieldGameObject.GetComponent<ForceFieldVanish>();
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
