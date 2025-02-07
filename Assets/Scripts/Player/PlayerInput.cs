using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const KeyCode CodeKey= KeyCode.Space;
    private const string Horizontal = "Horizontal";

    public event Action Jumping;
    public event Action<float> Running;
    public event Action<float> PlayerStanding;

    private void Update()
    {
        HandleJump();
        HandleMovement();
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxisRaw(Horizontal);
        Running?.Invoke(horizontal);

        if (horizontal == 0)
        {
            PlayerStanding?.Invoke(horizontal);
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(CodeKey))
        {
            Jumping?.Invoke();
        }
    }
}
