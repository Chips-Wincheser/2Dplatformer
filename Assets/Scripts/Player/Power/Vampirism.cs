using System.Collections;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Health _playerHealth;
    [SerializeField] private HandlerTriggerPower _triggerPower;
    [SerializeField] private AbilityTimer _cooldownManager;

    private Health _closestEnemy;

    private float _damageInterval = 0.1f;
    private WaitForSeconds _waitForSeconds;

    private int _stepHealth = 1;

    private void Awake()
    {
        _playerHealth=GetComponentInParent<Health>();
        _waitForSeconds =new WaitForSeconds(_damageInterval);
    }

    private void OnEnable()
    {
        _playerInput.VampirismActivated += HandleVampirism;
    }

    private void OnDisable()
    {
        _playerInput.VampirismActivated -= HandleVampirism;
    }

    private void HandleVampirism()
    {
        if (_cooldownManager.IsOnCooldown==false)
        {
            _closestEnemy=FindClosestEnemy();

            _cooldownManager.StartCooldown();
            StartCoroutine(ApplyVampirism());
        }
    }

    private IEnumerator ApplyVampirism()
    {
        while (_cooldownManager.IsVampirismActive)
        {
            if (_closestEnemy != null && _playerHealth!=null)
            {
                _closestEnemy.TakeDamage(_stepHealth);
                _playerHealth.Treatment(_stepHealth);
            }

            yield return _waitForSeconds;
        }
    }

    private Health FindClosestEnemy()
    {
        float closestDistance = float.MaxValue;
        Health closestEnemy = null;

        foreach (Health enemy in _triggerPower.EnemysInTrigger)
        {
            float enemyDistance = (enemy.transform.position - transform.position).sqrMagnitude;

            if (enemyDistance < closestDistance)
            {
                closestDistance = enemyDistance;
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
    }
}
