using System;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private float _groundCheckRadius = 0.2f;
    [SerializeField] private Transform _groundCheckPointDown;

    private bool _isGroundedDown;

    public event Action PlayerIsFlying;
    public event Action PlayerIsLanding;
    
    private void Update()
    {
        PlayerStateNotifier();
    }

    private void PlayerStateNotifier()
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
        Collider2D[] hits = Physics2D.OverlapCircleAll(groundCheckPoint.position, _groundCheckRadius);

        foreach (var hit in hits)
        {
            if (hit.GetComponent<Ground>() != null)
            {
                return true;
            }
        }

        return false;
    }
}
