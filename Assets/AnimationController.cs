using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerController))]
public class AnimationController : MonoBehaviour
{
    private PlayerController _playerController;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerController.IsGrounded)
        {
            _animator.SetBool("run",Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)); 
        }
        else
        {
            _animator.SetBool("run", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && _playerController.IsGrounded)
        {
            _animator.SetTrigger("jump");
        }
        _animator.SetBool("fallingDown", _playerController.VelocityY<0);
        
        
    }
}
