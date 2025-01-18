using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;

    private void OnEnable()
    {
        _inventory.PlayerPickedUp+=DestroyCoin;
    }

    private void OnDisable()
    {
        _inventory.PlayerPickedUp-=DestroyCoin;
    }

    private void DestroyCoin(Coin coin)
    {
        Destroy(coin.gameObject);
    }
}
