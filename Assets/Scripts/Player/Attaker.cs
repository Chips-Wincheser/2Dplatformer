using System;
using UnityEngine;

public class Attaker : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private EnemyAttacker[] _enemyAttackers;
    [SerializeField] private float _stopThresholdAttack = 2f;

    public event Action Attacked;

    private void OnEnable()
    {
        _playerInput.Attacked+=Attack;
    }

    private void OnDisable()
    {
        _playerInput.Attacked-=Attack;
    }

    private void Attack(bool isAttacking)
    {
        foreach (var enemy in _enemyAttackers)
        {
            if (isAttacking && (enemy.transform.position - transform.position).sqrMagnitude < _stopThresholdAttack)
            {
                Attacked?.Invoke();
            }
        }
    }
}
