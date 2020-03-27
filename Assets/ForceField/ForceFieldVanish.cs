using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldVanish : MonoBehaviour
{
    [SerializeField] protected float vanishSpeed;

    private bool _isVanishing;
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetFloat("Vanish Speed", vanishSpeed);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_isVanishing)
        {
            _animator.SetTrigger("Vanish");
            _isVanishing = true;
        }
    }
}
