using System;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Attaker : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;

    public event Action<bool> Attacked;

    private void OnEnable()
    {
        _playerInput.Attacked+=Attack;
    }

    private void OnDisable()
    {
        _playerInput.Attacked-=Attack;
    }

    private void Attack(bool _isAttacking)
    {
        Attacked?.Invoke(_isAttacking);
    }
}
