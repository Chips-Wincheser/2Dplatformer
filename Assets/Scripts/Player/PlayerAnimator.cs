using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private int _fly = Animator.StringToHash("fly");
    private int _isRun = Animator.StringToHash("isRun");
    private int _isAttack = Animator.StringToHash("isAttack");

    public void PlayRunning(bool isRunning)
    {
        _animator.SetBool(_isRun, isRunning);
    }

    public void PlayJumping()
    {
        _animator.SetInteger(_fly, 1);
    }

    public void PlayFlying()
    {
        _animator.SetInteger(_fly, 0);
    }

    public void StopFlying()
    {
        _animator.SetInteger(_fly, -1);
    }

    public void PlayAttack(bool isAttacking)
    {
        _animator.SetBool(_isAttack, isAttacking);
        
    }
}
