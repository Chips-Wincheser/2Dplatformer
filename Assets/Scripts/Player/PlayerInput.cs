using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const KeyCode CodeKey= KeyCode.Space;
    private const string _horizontal = "Horizontal";

    private bool _isJump;

    public event Action Jumping;
    public event Action<float> Runing;
    public event Action<float> PlayerStanding;

    private void Update()
    {
        HandleMovement();

        if (Input.GetKeyDown(CodeKey))
        {
            _isJump = true;
        }
    }

    private void FixedUpdate()
    {
        HandleJump();
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxisRaw(_horizontal);

        if (horizontal != 0)
        {
            Runing?.Invoke(horizontal);
        }
        else 
        { 
            PlayerStanding?.Invoke(horizontal);
        }
    }

    private void HandleJump()
    {
        if (_isJump)
        {
            Jumping?.Invoke();
            _isJump= false;
        }
    }
}
