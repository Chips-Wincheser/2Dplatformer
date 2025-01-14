using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private KeyCode _keyCode;

    public event Action OnPlayerJump;
    public event Action OnPlayerRun;

    private void Awake()
    {
        _keyCode = KeyCode.Space;
    }

    private void Update()
    {
        HandleMovement();
        HandleJump();
    }

    private void HandleMovement()
    {
        OnPlayerRun?.Invoke();
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(_keyCode))
        {
            OnPlayerJump?.Invoke();
        }
    }
}
