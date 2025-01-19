using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpHeight = 16f;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private GroundDetector _groundDetector;

    private Rigidbody2D _rigidbody;

    public event Action Jumped;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _playerInput.Jumping+=Jump;
    }

    private void OnDisable()
    {
        _playerInput.Jumping-=Jump;
    }

    private void Jump()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpHeight);

        Jumped?.Invoke();   
    }
}
