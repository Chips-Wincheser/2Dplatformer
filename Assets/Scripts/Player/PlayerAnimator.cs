using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Mover _movement;
    [SerializeField] private Jumper _jump;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private PlayerInput _playerInput;

    private int _fly = Animator.StringToHash("fly");
    private int _isRun = Animator.StringToHash("isRun");

    private bool _isJumped = false;

    private void OnEnable()
    {
        _playerInput.PlayerStanding += StopRunning;
        _movement.PlayerRuning += PlayRunning;
        _jump.Jumped += PlayJumping;
        _groundDetector.PlayerIsFlying += PlayFlying;
        _groundDetector.PlayerIsLanding += StopFlying;
    }

    private void OnDisable()
    {
        _playerInput.PlayerStanding -= StopRunning;
        _movement.PlayerRuning -= PlayRunning;
        _jump.Jumped -= PlayJumping;
        _groundDetector.PlayerIsFlying -= PlayFlying;
        _groundDetector.PlayerIsLanding -= StopFlying;
    }

    private void PlayRunning(float horizontal)
    {
        if (_isJumped==false && horizontal != 0)
        {
            _animator.SetBool(_isRun, true);
        }
    }

    private void StopRunning(float horizontal)
    {
        _animator.SetBool(_isRun, false);
    }

    private void PlayJumping()
    {
        _animator.SetInteger(_fly, 1);
        _isJumped = true;
        StopRunning(0);
    }

    private void PlayFlying()
    {
        _animator.SetInteger(_fly, 0);
        _isJumped = false;
    }

    private void StopFlying()
    {
        if (_isJumped==false)
        {
            _animator.SetInteger(_fly, -1);
        }
    }
}
