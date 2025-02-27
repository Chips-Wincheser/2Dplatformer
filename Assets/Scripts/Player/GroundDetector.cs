using System;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private GroundTrigger _groundTrigger;

    public bool IsGrounded { get; private set; }

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
        if (IsGrounded)
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
        IsGrounded= true;
    }

    private void LostGround()
    {
        IsGrounded= false;
    }
}
