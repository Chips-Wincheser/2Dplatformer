using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private Mover _mover;

    private void OnEnable()
    {
        _playerInput.Jumping += OnJump;
        _playerInput.Running += OnRun;
    }

    private void OnDisable()
    {
        _playerInput.Jumping -= OnJump;
        _playerInput.Running -= OnRun;
    }

    private void OnJump()
    {
        _jumper.AttemptJump();
    }

    private void OnRun(float horizontal)
    {
        _mover.ProcessMovement(horizontal);
    }
}
