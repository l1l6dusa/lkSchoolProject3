using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpVelocity;
    private Rigidbody2D _rigidbody;
    [SerializeField] private float moveInput;
    [SerializeField] private GameObject _groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask _groundLayers;
    [SerializeField ]private float _gravityMultiplier;
  
    private bool _isGrounded;
    private bool _facingRight;
    public bool IsGrounded => _isGrounded;
    public float VelocityY => _rigidbody.velocity.y;
    
    

    private void OnEnable()
    {
        
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
        _facingRight = true;
    }

    private void Update()
    {
        if (moveInput > 0 && _facingRight==false)
        {
            Flip();
        }
        else if (moveInput < 0 && _facingRight==true)
        {
            Flip();
        }
        if ((Input.GetKeyDown(KeyCode.Space) && _isGrounded))
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpVelocity);
        }
    }

    void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.transform.position, groundCheckRadius, _groundLayers);
        moveInput = Input.GetAxis("Horizontal");
        _rigidbody.velocity = new Vector2(moveInput * _speed, _rigidbody.velocity.y);
        if (_rigidbody.velocity.y < 0)
        {
            _rigidbody.velocity += Vector2.up * (Physics2D.gravity.y * _gravityMultiplier * Time.fixedDeltaTime);
        }
    }

    public void Flip()
    {
        _facingRight = !_facingRight;
        var scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
