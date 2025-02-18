using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Health : MonoBehaviour
{
    [SerializeField] private Attaker _player;
    [SerializeField] private EnemyAttacker[] _enemyAttackers;
    [SerializeField] private float _stopThresholdAttack = 2f;
    [SerializeField] private Vector2 _damageForce;
    [SerializeField] private EnemyMover _enemyMover;

    private WaitForSeconds _waitForSeconds;
    private float _delay = 0.5f;
    private int _numberTimes = 0;
    private int _numberTransfusions = 3;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(_delay);
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        if (_player != null)
        {
            _player.Attacked += TakeDamageFromPlayer;
        }

        foreach (var enemyAttack in _enemyAttackers)
        {
            enemyAttack.Attaced += TakeDamageFromEnemy;
        }
    }

    private void OnDisable()
    {
        if (_player != null)
        {
            _player.Attacked -= TakeDamageFromPlayer;
        }

        foreach (var enemyAttack in _enemyAttackers)
        {
            enemyAttack.Attaced -= TakeDamageFromEnemy;
        }
    }

    private void TakeDamageFromPlayer(bool isAttacking)
    {
        if (_numberTimes == 0 && isAttacking && (_player.transform.position - transform.position).sqrMagnitude < _stopThresholdAttack)
        {
            float direction = _enemyMover.Direction;

            StartCoroutine(ChangeColorTemporarily());

            _rigidbody.AddForce(new Vector2(_damageForce.x * -direction, _damageForce.y), ForceMode2D.Impulse);
            _enemyMover.enabled = false;
        }
    }

    private void TakeDamageFromEnemy(bool isFarAway)
    {
        if (_numberTimes == 0 && isFarAway)
        {
            StartCoroutine(ChangeColorTemporarily());
        }
    }

    private IEnumerator ChangeColorTemporarily()
    {
        _numberTimes++;

        if (gameObject.TryGetComponent<SpriteRenderer>(out SpriteRenderer spriteRenderer))
        {
            for (int i = 0; i < _numberTransfusions; i++)
            {
                spriteRenderer.color = Color.red;
                yield return _waitForSeconds;
                spriteRenderer.color = Color.white;
                yield return _waitForSeconds;
            }

            _numberTimes = 0;

            if (_enemyMover != null)
            {
                _enemyMover.enabled = true;
            }
        }
    }
}
