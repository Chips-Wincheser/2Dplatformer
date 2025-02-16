using System;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private EnemyMover _enemyMover;
    [SerializeField] private Enemy _enemy;

    public event Action<bool> Attaced;

    private void OnEnable()
    {
        _enemyMover.CameClose+=TakeDamage;
    }

    private void OnDisable()
    {
        _enemyMover.CameClose-=TakeDamage;
    } 

    private void TakeDamage(bool isFarAway)
    {
        Attaced?.Invoke(isFarAway);
    }
}
