using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpHeight = 16f;
    [SerializeField] private GroundDetector _groundDetector;

    private Rigidbody2D _rigidbody;
    private bool _isJump;

    public event Action Jumped;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_isJump)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpHeight);
            Jumped?.Invoke();
            _isJump = false;
        }
    }

    public void AttemptJump()
    {
        if (_groundDetector.IsGrounded)
            _isJump = true;
    }
}
