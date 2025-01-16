using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private KeyCode _keyCode;
    private string _horizontal;

    public event Action Jumping;
    public event Action<float> Runing;
    public event Action<float> PlayerStanding;

    private void Awake()
    {
        _keyCode = KeyCode.Space;
        _horizontal = "Horizontal";
    }

    private void Update()
    {
        HandleMovement();
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
        if (Input.GetKeyDown(_keyCode))
        {
            Jumping?.Invoke();
        }
    }
}
