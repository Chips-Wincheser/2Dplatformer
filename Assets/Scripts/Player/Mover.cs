using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Rotator _rotator;

    private Rigidbody2D _rigidbody2D;
    private bool _isMovementLock;
    private float _horizontal;

    public event Action<float> PlayerRunning;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!_isMovementLock)
        {
            _rigidbody2D.velocity = new Vector2(_horizontal * _speed, _rigidbody2D.velocity.y);
            _rotator.Rotate(_horizontal);
            _isMovementLock = true;
        }
    }

    public void ProcessMovement(float horizontal)
    {
        _horizontal = horizontal;
        _isMovementLock = false;
        PlayerRunning?.Invoke(horizontal);
    }
}
