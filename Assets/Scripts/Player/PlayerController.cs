using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _moveSpeed;
    private float _currentSpeed;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        StartMove();
    }

    private void FixedUpdate()
    {
        if (_currentSpeed == 0)
        {
            _rigidbody.velocity = Vector3.zero;
            return;
        }
        
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _currentSpeed, _rigidbody.velocity.y, _joystick.Vertical * _currentSpeed);

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
        }
        PlayerAnimations.instance.PlayMoveAnimation(_joystick.Horizontal + _joystick.Vertical);
    }

    public void StartMove()
    {
        _currentSpeed = _moveSpeed;
    }

    public void StopMove()
    {
        _currentSpeed = 0;
    }
}
