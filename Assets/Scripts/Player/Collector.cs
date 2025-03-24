using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            _inventory.Coins.Add(coin);
            coin.Collect();
        }

        if (collision.TryGetComponent<Heart>(out Heart heart) && this.TryGetComponent<Health>(out Health health))
        {
            _inventory.Hearts.Add(heart);
            heart.Collect();
            health.Treatment(15);
        }
    }
}
