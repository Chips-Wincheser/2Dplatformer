using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private Mover _mover;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private PlayerAnimator _animator;

    private void OnEnable()
    {
        _playerInput.Jumping += OnJump;
        _playerInput.Running += OnRun;
        _playerInput.PlayerStanding += OnStopRun;

        _groundDetector.PlayerIsFlying += OnFly;
        _groundDetector.PlayerIsLanding += OnLand;
    }

    private void OnDisable()
    {
        _playerInput.Jumping -= OnJump;
        _playerInput.Running -= OnRun;
        _playerInput.PlayerStanding -= OnStopRun;

        _groundDetector.PlayerIsFlying -= OnFly;
        _groundDetector.PlayerIsLanding -= OnLand;
    }

    private void OnJump()
    {
        _jumper.AttemptJump();
        _animator.PlayJumping();
    }

    private void OnRun(float horizontal)
    {
        _mover.ProcessMovement(horizontal);
        _animator.PlayRunning(horizontal != 0);
    }

    private void OnStopRun()
    {
        _animator.PlayRunning(false);
    }

    private void OnFly()
    {
        _animator.PlayFlying();
    }

    private void OnLand()
    {
        _animator.StopFlying();
    }
}
