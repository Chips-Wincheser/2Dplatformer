using System;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private PlayerInput _playerInput;

    private Vector2 _direction;
    private Vector3 _originalScale;

    public event Action<float> PlayerRuning;

    private void Awake()
    {
        _direction = transform.right.normalized;
        _originalScale = transform.localScale;
    }

    private void OnEnable()
    {
        _playerInput.Runing+=ProcessHorizontalInput;
    }

    private void OnDisable()
    {
        _playerInput.Runing-=ProcessHorizontalInput;
    }

    private void ProcessHorizontalInput(float horizontal)
    {
        if (horizontal < 0)
        {
            transform.Translate(-_direction*_speed*Time.deltaTime, Space.World);
            transform.localScale = new Vector3(-_originalScale.x, _originalScale.y, _originalScale.z);
        }
        else if (horizontal > 0)
        {
            transform.Translate(_direction*_speed*Time.deltaTime, Space.World);
            transform.localScale = new Vector3(_originalScale.x, _originalScale.y, _originalScale.z);
        }

        PlayerRuning?.Invoke(horizontal);
    }
}
