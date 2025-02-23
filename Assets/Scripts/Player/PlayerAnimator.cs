using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private readonly int _fly = Animator.StringToHash("fly");
    private readonly int _isRun = Animator.StringToHash("isRun");
    private readonly int _isAttack = Animator.StringToHash("isAttack");

    public void SetRunning(bool isRunning)
    {
        _animator.SetBool(_isRun, isRunning);
    }

    public void StartJumping()
    {
        _animator.SetInteger(_fly, 1);
    }

    public void StartFlying()
    {
        _animator.SetInteger(_fly, 0);
    }

    public void StopFlying()
    {
        _animator.SetInteger(_fly, -1);
    }

    public void SetAttacking(bool isAttacking)
    {
        _animator.SetBool(_isAttack, isAttacking);
    }
}
