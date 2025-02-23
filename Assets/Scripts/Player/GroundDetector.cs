using System;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private GroundTrigger _groundTrigger;

    private bool _isGroundedDown;

    public bool IsGrounded => _isGroundedDown;

    public event Action PlayerFlew;
    public event Action PlayerLanded;

    private void OnEnable()
    {
        _groundTrigger.Detected+=TouchGround;
        _groundTrigger.Lost+=LostGround;
    }

    private void OnDisable()
    {
        _groundTrigger.Detected-=TouchGround;
        _groundTrigger.Lost-=LostGround;
    }

    private void FixedUpdate()
    {
        NotifyPlayerState();
    }

    private void NotifyPlayerState()
    {
        if (_isGroundedDown)
        {
            PlayerLanded?.Invoke();
        }
        else
        {
            PlayerFlew?.Invoke();
        }
    }

    private void TouchGround()
    {
        _isGroundedDown= true;
    }

    private void LostGround()
    {
        _isGroundedDown= false;
    }
}
