using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private List<Coin> _coins;

    private void OnEnable()
    {
        foreach (Coin coin in _coins)
        {
            coin.CoinPickedUp+=DestroyCoin;
        }
    }

    private void OnDisable()
    {
        foreach (Coin coin in _coins)
        {
            coin.CoinPickedUp-=DestroyCoin;
        }
    }

    private void DestroyCoin(Coin coin)
    {
        _coins.Remove(coin);
        Destroy(coin.gameObject);
    }
}
