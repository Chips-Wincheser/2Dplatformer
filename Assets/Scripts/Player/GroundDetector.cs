using System;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private float _groundCheckRadius = 0.2f;
    [SerializeField] private Transform _groundCheckPointDown;

    private bool _isGroundedDown;
    private Collider2D[] _hits = new Collider2D[1];

    public event Action PlayerIsFlying;
    public event Action PlayerIsLanding;

    private void FixedUpdate()
    {
        NotifyPlayerState();
    }

    private void NotifyPlayerState()
    {
        _isGroundedDown = IsSurfaceDetected(_groundCheckPointDown);

        if (_isGroundedDown)
        {
            PlayerIsLanding?.Invoke();
        }
        else
        {
            PlayerIsFlying?.Invoke();
        }
    }

    private bool IsSurfaceDetected(Transform groundCheckPoint)
    {
        int hitCount = Physics2D.OverlapCircleNonAlloc(groundCheckPoint.position, _groundCheckRadius, _hits);

        for (int i = 0; i < hitCount; i++)
        {
            if (_hits[i].GetComponent<Ground>() != null)
            {
                return true;
            }
        }

        return false;
    }

    public bool IsGrounded => _isGroundedDown;
}
