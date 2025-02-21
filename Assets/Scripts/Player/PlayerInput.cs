using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const KeyCode CodeKey= KeyCode.Space;
    private const string Horizontal = "Horizontal";

    private bool _isAttacking;

    public event Action Jumping;
    public event Action PlayerStanding;
    public event Action<float> Running;
    public event Action<bool> Attacked;

    private void Update()
    {
        HandleJump();
        HandleMovement();
        HandleAttack();
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxisRaw(Horizontal);
        Running?.Invoke(horizontal);

        if (horizontal == 0)
        {
            PlayerStanding?.Invoke();
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(CodeKey))
        {
            Jumping?.Invoke();
        }
    }

    private void HandleAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isAttacking= true;
            Attacked?.Invoke(_isAttacking);   
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _isAttacking=false;
            Attacked?.Invoke(_isAttacking);
        }
    }
}
