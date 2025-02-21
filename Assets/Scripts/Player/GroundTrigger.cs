using System;
using UnityEngine;

public class GroundTrigger : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayerMask;

    public event Action Detected;
    public event Action Lost;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DetectCollision(Detected, collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        DetectCollision(Lost, collision);
    }

    private void DetectCollision(Action Action, Collider2D collision)
    {
        if ((_groundLayerMask & (1 << collision.gameObject.layer)) != 0)
        {
            Action?.Invoke();
        }
    }
}
