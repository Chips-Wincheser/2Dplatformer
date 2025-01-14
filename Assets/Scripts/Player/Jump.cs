using System;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Rigidbody2D))]
public class Jump : MonoBehaviour
{
    [SerializeField] private float _jumpHeight = 16f;
    [SerializeField] private PlayerInput _playerInput;

    private Rigidbody2D _rigidbody;

    public event Action OnJump;
    public event Action PlayerIsFly;
    public event Action PlayerIsLand;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _playerInput.OnPlayerJump+=Jumper;
    }

    private void OnDisable()
    {
        _playerInput.OnPlayerJump-=Jumper;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<TilemapCollider2D>())
        {
            PlayerIsFly?.Invoke();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<TilemapCollider2D>())
        {
            PlayerIsLand?.Invoke();
        }
    }

    private void Jumper()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpHeight);
        OnJump?.Invoke();
    }
}
