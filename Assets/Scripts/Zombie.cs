using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Zombie : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Point[] _points;
    
    private Rigidbody2D _rigidbody;
    private Vector3 _direction;
    private int _pointIndex;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _pointIndex = 0;
        _direction = (_points[_pointIndex].transform.position - transform.position).normalized;
    }

    private void Flip()
    {
        var scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }


    private void FixedUpdate()
    {
        _rigidbody.MovePosition(transform.position + _direction * (_speed * Time.fixedDeltaTime));
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.TryGetComponent(out Point point))
        {
            _direction = (_points[++_pointIndex%_points.Length].transform.position - transform.position).normalized;
            Flip();
        }
    }
}
    