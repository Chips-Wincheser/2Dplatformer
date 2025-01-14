using UnityEngine;
using UnityEngine.Tilemaps;

public class Animations : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Movment _movment;
    [SerializeField] private Jump _jump;

    private string _fly = "fly";
    private string _isRun = "isRun";

    private bool _isJumped = false;

    private void OnEnable()
    {
        _movment.PlayerRuning+=ToggleRunning;
        _jump.OnJump+=ToggleJump;
    }

    private void OnDisable()
    {
        _movment.PlayerRuning-=ToggleRunning;
        _jump.OnJump-=ToggleJump;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<TilemapCollider2D>())
        {
            _animator.SetInteger(_fly, -1);
            _isJumped = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<TilemapCollider2D>() && _isJumped==false)
        {
            _animator.SetInteger(_fly, 0);
        }
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
}
