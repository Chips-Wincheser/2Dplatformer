using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float _currentValue;

    public float MaxValue {  get; private set; }

    public event Action<float> Updated;

    private void Awake()
    {
        MaxValue  = 100;
        _currentValue = MaxValue;
    }

    public void TakeDamage(int damage)
    {
        if (damage>0 && _currentValue != 0)
        {
            _currentValue = Mathf.Clamp(_currentValue - damage, 0, MaxValue);
            Updated?.Invoke(_currentValue/MaxValue);
        }
    }

    public void Treatment(int healingAmount)
    {
        if(healingAmount>0)
        {
            _currentValue = Mathf.Clamp(_currentValue + healingAmount, 0, MaxValue);
            Updated?.Invoke(_currentValue/MaxValue);
        }
    }
}