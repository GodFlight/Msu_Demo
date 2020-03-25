using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldVanish : MonoBehaviour
{
    private Material _material;

    [SerializeField] protected float vanishSpeed;
    private bool _isVanished;
    private float _vanishValue = 0f;

    private const string IsActiveField = "BOOLEAN_3F55DA4E_ON";
    private const string VanishStageField = "Vector1_E83CFCAF";
    void Start()
    {
        _material = GetComponent<Renderer>().material;
        _material.SetFloat(VanishStageField, 0f);
        _material.EnableKeyword(IsActiveField);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_isVanished)
        {
            _material.DisableKeyword(IsActiveField);
            _isVanished = true;
        }

        if (_isVanished && _vanishValue <= 1f)
        {
            _vanishValue += Time.deltaTime * vanishSpeed;
            _material.SetFloat(VanishStageField, _vanishValue);
        }
    }
}
