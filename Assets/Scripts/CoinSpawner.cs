using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private int _poolSize = 3;
    [SerializeField] private Transform[] _spawnArea;

    private Queue<Coin> _coinPool = new Queue<Coin>();

    private void Awake()
    {
        InitializePool();
        SpawnCoin();
    }

    private void OnDisable()
    {
        foreach (Coin coin in _coinPool)
        {
            coin.PlayerPickedUp-=ReturnCoinToPool;
        }
    }

    private void InitializePool()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            Coin coin = Instantiate(_coinPrefab, transform);
            coin.gameObject.SetActive(false);
            _coinPool.Enqueue(coin);

            coin.PlayerPickedUp+=ReturnCoinToPool;
        }
    }

    private void SpawnCoin()
    {
        if (_coinPool.Count > 0)
        {
            for (int i = 0; i < _poolSize; i++)
            {
                Coin coin = _coinPool.Dequeue();
                coin.transform.position = _spawnArea[i].position;
                coin.gameObject.SetActive(true);
            }
        }
    }

    private void ReturnCoinToPool(Coin coin)
    {
        coin.gameObject.SetActive(false);
        _coinPool.Enqueue(coin);
    }
}
