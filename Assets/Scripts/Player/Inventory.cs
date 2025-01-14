using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Coin> _coins;

    private void Awake()
    {
        _coins = new List<Coin>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out Coin coin))
        {
            _coins.Add(coin);
            Destroy(collision.gameObject);
        }
    }
}
