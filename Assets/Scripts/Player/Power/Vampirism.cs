using System.Collections;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private HandlerTriggerPower _triggerPower;
    [SerializeField] private AbilityTimer _cooldownManager;

    private Health _closestEnemy;
    
    private WaitForSeconds _waitForSeconds;
    private int _tickInterval = 1;

    private int _damage = 1;

    private void OnEnable()
    {
        _playerInput.VampirismActivated += HandleVampirism;
    }

    private void OnDisable()
    {
        _playerInput.VampirismActivated -= HandleVampirism;
    }

    private void Awake()
    {
        _waitForSeconds=new WaitForSeconds(_tickInterval);
    }

    private void HandleVampirism()
    {
        _triggerPower.SpriteCollisionToggle(true);
        
        if (_cooldownManager.IsOnCooldown==false)
        {
            FindClosestEnemy();

            _cooldownManager.StartCooldown();
            StartCoroutine(ApplyVampirism());
        }
    }

    private IEnumerator ApplyVampirism()
    {
        while (_cooldownManager.IsVampirismActive)
        {
            if (_closestEnemy != null)
            {
                _closestEnemy.TakeDamage(_damage);
            }

            yield return _waitForSeconds;
        }
    }

    private void FindClosestEnemy()
    {
        float closestDistance = float.MaxValue;

        foreach (Health enemy in _triggerPower.EnemysInTrigger)
        {
            float enemyDistance = (enemy.transform.position - transform.position).sqrMagnitude;

            if (enemyDistance < closestDistance)
            {
                closestDistance = enemyDistance;
                _closestEnemy = enemy;
            }
        }
    }
}
