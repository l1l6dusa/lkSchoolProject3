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
    private bool _isGrounded;
    public bool IsGrounded => _isGrounded;

    [SerializeField] private GameObject _groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask _groundLayers;
    private bool _doubleJumpAvailable;
    //private Animator _animator;
    [SerializeField ]private float _gravityMultiplier;

    private bool _facingRight;
    // Start is called before the first frame update

    private void OnEnable()
    {
        //_animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _doubleJumpAvailable = true;
        _facingRight = true;
    }

    private void Update()
    {
        if (_isGrounded)
        {
            _doubleJumpAvailable = true;
        }
        
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
            //_animator.SetTrigger("jump");
        }else if (Input.GetKeyDown(KeyCode.Space) && _doubleJumpAvailable)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpVelocity);
            _doubleJumpAvailable = false;
            //_animator.SetTrigger("jump");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.transform.position, groundCheckRadius, _groundLayers);
        if (gameObject.layer == _groundLayers)
        {
            Debug.LogWarning("Player got layer \"Ground\"");
        }

        
        moveInput = Input.GetAxis("Horizontal");
        _rigidbody.velocity = new Vector2(moveInput * _speed, _rigidbody.velocity.y);
        if(_isGrounded)
            //_animator.SetFloat("velocity", Mathf.Abs(_rigidbody.velocity.x));
        
            
       


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
