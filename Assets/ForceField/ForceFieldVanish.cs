using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldVanish : MonoBehaviour, IInteractable
{
    [SerializeField] protected float vanishSpeed;

    private bool _isVanishing;
    private bool _isVanished;
    
    private Animator _animator;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetFloat("Vanish Speed", vanishSpeed);
    }
    
    void Update()
    {
        if (_isVanishing)
        {
            _animator.SetTrigger("Vanish");
            _isVanishing = false;
            _isVanished = true;
        }
    }

    public void ShowUsability()
    {
        //_interactVisisble = true;
    }

    public void HideUsability()
    {
        //_interactVisisble = false;
    }

    public void Interact()
    {
        _isVanishing = true;
    }

    public bool GetForceFieldState()
    {
        return _isVanished;
    }
}
