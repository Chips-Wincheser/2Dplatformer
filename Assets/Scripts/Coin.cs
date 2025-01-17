using System;
using UnityEditor.Sprites;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action<Coin> CoinPickedUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<PlayerInput>(out PlayerInput player))
        {
            CoinPickedUp?.Invoke(this);
        }
    }
}
