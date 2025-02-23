using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private Mover _mover;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private Attaker _attaker;
    [SerializeField] private EnemyAttacker[] _enemyAttackers;
    [SerializeField] private float _stopThresholdAttack = 2f;

    public event Action Attacked;

    private void OnEnable()
    {
        _playerInput.Jumping += OnJump;
        _playerInput.Running += OnRun;
        _playerInput.PlayerStanding += OnStopRun;
        _playerInput.Attacked+=OnPlayAttack;

        _groundDetector.PlayerFlew += OnFly;
        _groundDetector.PlayerLanded += OnLand;
    }

    private void OnDisable()
    {
        _playerInput.Jumping -= OnJump;
        _playerInput.Running -= OnRun;
        _playerInput.PlayerStanding -= OnStopRun;
        _playerInput.Attacked-=OnPlayAttack;

        _groundDetector.PlayerFlew -= OnFly;
        _groundDetector.PlayerLanded -= OnLand;
    }

    private void OnJump()
    {
        _jumper.AttemptJump();
        _animator.StartJumping();
    }

    private void OnRun(float horizontal)
    {
        _mover.ProcessMovement(horizontal);
        _animator.SetRunning(horizontal != 0);
    }

    private void OnStopRun()
    {
        _animator.SetRunning(false);
    }

    private void OnFly()
    {
        _animator.StartFlying();
    }

    private void OnLand()
    {
        _animator.StopFlying();
    }

    private void OnPlayAttack(bool isAttacking)
    {
        _animator.SetAttacking(isAttacking);
        
        foreach (var enemy in _enemyAttackers)
        {
            if (isAttacking && (enemy.transform.position - transform.position).sqrMagnitude < _stopThresholdAttack)
            {
                Attacked?.Invoke();
            }
        }
    }
}
