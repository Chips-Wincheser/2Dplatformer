using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jump : MonoBehaviour
{
    [SerializeField] private float _jumpHeight = 16f;
    [SerializeField] private PlayerInput _playerInput;

    private Rigidbody2D _rigidbody;

    public event Action OnJump;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _playerInput.OnPlayerJump+=InputHandler;
    }

    private void OnDisable()
    {
        _playerInput.OnPlayerJump-=InputHandler;
    }

    private void InputHandler()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpHeight);
        OnJump?.Invoke();
    }
}
