using System;
using UnityEngine;

public class GroundTrigger : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayerMask;

    public event Action Detected;
    public event Action Lost;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Detected—ollision(Detected, collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Detected—ollision(Lost, collision);
    }

    private void Detected—ollision(Action Action, Collider2D collision)
    {
        if ((_groundLayerMask & (1 << collision.gameObject.layer)) != 0)
        {
            Action?.Invoke();
        }
    }
}
