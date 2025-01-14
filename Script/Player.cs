using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpHeight = 16f;
    [SerializeField] private Animator _animator;
    
    private Vector2 _direction;
    private Vector3 _originalScale;
    private string _isRun="isRun";
    private string _fly = "fly";
    private bool _isJumped=false;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _direction = transform.right.normalized;
        _originalScale = transform.localScale;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Movment();
        Jump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<TilemapCollider2D>())
        {
            _animator.SetInteger(_fly, -1);
            _isJumped = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<TilemapCollider2D>() && _isJumped==false)
        {
            _animator.SetInteger(_fly, 0);
        }
    }

    private void Movment()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal != 0)
        {
            MoveAndFlip(horizontal);
        }
        else
        {
            _animator.SetBool(_isRun, false);
        }
    }

    private void MoveAndFlip(float horizontal)
    {
        if(horizontal < 0)
        {
            transform.Translate(-_direction*_speed*Time.deltaTime, Space.World);
            transform.localScale = new Vector3(-_originalScale.x, _originalScale.y, _originalScale.z);
        }
        else if(horizontal > 0)
        {
            transform.Translate(_direction*_speed*Time.deltaTime, Space.World);
            transform.localScale = new Vector3(_originalScale.x, _originalScale.y, _originalScale.z);
        }

        if (_isJumped==false)
            _animator.SetBool(_isRun, true);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpHeight);
            _animator.SetInteger(_fly, 1);
            _isJumped=true;
            _animator.SetBool(_isRun, false);
        }
    }
}
