using System;
using UnityEngine;

public class Attaker : MonoBehaviour
{
    [SerializeField] private Player _player;

    public event Action Attacked;

    private void OnEnable()
    {
        _player.Attacked+=Attack;
    }

    private void OnDisable()
    {
        _player.Attacked-=Attack;
    }

    private void Attack()
    {  
        Attacked?.Invoke();
    }
}
