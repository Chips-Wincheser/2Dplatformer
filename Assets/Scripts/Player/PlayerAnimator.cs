using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Movment _movment;
    [SerializeField] private Jump _jump;

    private int _fly = Animator.StringToHash("fly");
    private int _isRun = Animator.StringToHash("isRun");

    private bool _isJumped = false;

    private void OnEnable()
    {
        _movment.PlayerRuning+=ToggleRunning;
        _jump.OnJump+=ToggleJump;
        _jump.PlayerIsFly+=ToggleFly;
        _jump.PlayerIsLand+=ToggleLand;
    }

    private void OnDisable()
    {
        _movment.PlayerRuning-=ToggleRunning;
        _jump.OnJump-=ToggleJump;
        _jump.PlayerIsFly-=ToggleFly;
        _jump.PlayerIsLand-=ToggleLand;
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
