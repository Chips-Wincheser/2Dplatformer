using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Mover _movment;
    [SerializeField] private Jump _jump;
    [SerializeField] private PlayerInput _playerInput;

    private int _fly = Animator.StringToHash("fly");
    private int _isRun = Animator.StringToHash("isRun");

    private bool _isJumped = false;

    private void OnEnable()
    {
        _playerInput.PlayerStanding+=ToggleRunning;
        _movment.PlayerRuning+=ToggleRunning;
        _jump.Jumped+=ToggleJump;
        _jump.PlayerIsFlying+=ToggleFly;
        _jump.PlayerIsLanding+=ToggleLand;
    }

    private void OnDisable()
    {
        _playerInput.PlayerStanding-=ToggleRunning;
        _movment.PlayerRuning-=ToggleRunning;
        _jump.Jumped-=ToggleJump;
        _jump.PlayerIsFlying-=ToggleFly;
        _jump.PlayerIsLanding-=ToggleLand;
    }

    private void ToggleRunning(float horizontal)
    {
        _animator.SetBool(_isRun, false);

        if (_isJumped==false && horizontal!=0)
            _animator.SetBool(_isRun, true);
    }

    private void ToggleJump()
    {
        _animator.SetInteger(_fly, 1);
        _isJumped=true;
        _animator.SetBool(_isRun, false);
    }

    private void ToggleFly()
    {
        _animator.SetInteger(_fly, -1);
        _isJumped = false;
    }

    private void ToggleLand()
    {
        if (_isJumped==false)
        {
            _animator.SetInteger(_fly, 0);
        }
    }
}
