using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Inventory _playerInventory;

    private void OnEnable()
    {
        _playerInventory.Collected += OnCoinCollected;
    }

    private void Start()
    {
        SpawnCoins();
    }

    private void OnDisable()
    {
        _playerInventory.Collected -= OnCoinCollected;
    }

    private void SpawnCoins()
    {
        foreach (var point in _spawnPoints)
        {
            Coin coin = Instantiate(_coinPrefab, point.position, Quaternion.identity);
        }
    }

    private void OnCoinCollected(Coin coin)
    {
        Destroy(coin.gameObject);
    }
}