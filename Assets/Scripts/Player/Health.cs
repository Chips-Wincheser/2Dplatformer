using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private EnemyAttack[] _enemysAttack;

    private WaitForSeconds _waitForSeconds;
    private float _delay=0.5f;
    private int _numberTimes=0;
    private int _numberTransfusions= 3;

    private void Awake()
    {
        _waitForSeconds=new WaitForSeconds(_delay);
    }

    private void OnEnable()
    {
        foreach (var enemyAttack in _enemysAttack)
        {
            enemyAttack.Attaced+=TakeDamage;
        }
    }

    private void OnDisable()
    {
        foreach (var enemyAttack in _enemysAttack)
        {
            enemyAttack.Attaced-=TakeDamage;
        }
    }

    private void TakeDamage(bool isFarAway)
    {
        if(_numberTimes==0 && isFarAway)
            StartCoroutine(ChangeColorTemporarily());
    }

    private IEnumerator ChangeColorTemporarily()
    {
        _numberTimes++;

        if(gameObject.TryGetComponent<SpriteRenderer> (out SpriteRenderer spriteRenderer))
        {
            for (int i = 0; i < _numberTransfusions; i++)
            {
                spriteRenderer.color = Color.red;
                yield return _waitForSeconds;
                spriteRenderer.color = Color.white;
                yield return _waitForSeconds;
            }
            _numberTimes= 0;
        }
    }
}
