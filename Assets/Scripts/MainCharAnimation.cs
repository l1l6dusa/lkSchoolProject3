using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Player))]
public class MainCharAnimation : MonoBehaviour
{
    private Player _player;
    private Animator _animator;
    
    private void Start()
    {
        _player = GetComponent<Player>();
        _animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        if (_player.IsGrounded)
        {
            _animator.SetBool("run",Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)); 
        }
        else
        {
            _animator.SetBool("run", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && _player.IsGrounded)
        {
            _animator.SetTrigger("jump");
        }
        _animator.SetBool("fallingDown", _player.VelocityY<0);
        _animator.SetBool("grounded", _player.IsGrounded);
        
    }
}
