using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GroundDetector : MonoBehaviour
{
    private int _numberOccurrences;

    public event Action PlayerIsFlying;
    public event Action PlayerIsLanding;

    private void Awake()
    {
        _numberOccurrences = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<TilemapCollider2D>())
        {
            _numberOccurrences++;

            if (_numberOccurrences>0) 
                PlayerIsLanding?.Invoke();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<TilemapCollider2D>())
        {
            PlayerIsFlying?.Invoke();
        }
    }
}
