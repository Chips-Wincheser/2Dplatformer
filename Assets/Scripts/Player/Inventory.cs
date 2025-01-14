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
        if (collision.gameObject.GetComponent<Coin>())
        {
            _coins.Add(collision.gameObject.GetComponent<Coin>());
            Destroy(collision.gameObject);

            Debug.Log($"Количество монеток:{_coins.Count}");
        }
    }
}
