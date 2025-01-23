using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Rotator _rotator;

    private Rigidbody2D _rigidbody2D;
    private bool _isMovmentLock;
    private float _horizontal;

    public event Action<float> PlayerRuning;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _playerInput.Runing+=ProcessHorizontalInput;
    }

    private void FixedUpdate()
    {
        if (_isMovmentLock==false)
        {
            _rigidbody2D.velocity = new Vector2(_horizontal * _speed, _rigidbody2D.velocity.y);
            _rotator.Rotate(_horizontal);
            _isMovmentLock = true;
        }
    }

    private void OnDisable()
    {
        _playerInput.Runing-=ProcessHorizontalInput;
    }

    private void ProcessHorizontalInput(float horizontal)
    {
        _horizontal=horizontal;
        _isMovmentLock=false;

        PlayerRuning?.Invoke(horizontal);
    }
}
