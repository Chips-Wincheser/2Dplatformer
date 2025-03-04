using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 3;
    private int _currentHealth;

    public event Action Damaged;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if(damage>0)
        {
            _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, _maxHealth);
            Damaged?.Invoke();

            if (_currentHealth == 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        if(gameObject.TryGetComponent<Player>(out _)==false)
            Destroy(gameObject);
    }
}
