using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Health : MonoBehaviour
{
    private WaitForSeconds _waitForSeconds;
    private SpriteRenderer _spriteRenderer;
    private float _delay = 0.5f;
    private int _numberTimes = 0;
    private int _numberTransfusions = 3;
    private bool _isTakingDamage = false;


    private void Awake()
    {
        _spriteRenderer=GetComponent<SpriteRenderer>();
        _waitForSeconds = new WaitForSeconds(_delay);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Health>(out Health _))
        {
            if (_isTakingDamage == false)
            {
                _isTakingDamage = true;
                TakeDamage();
            }
        }
    }

    private void TakeDamage()
    {
        if (_numberTimes == 0)
            StartCoroutine(ChangeColorTemporarily());
    }

    private IEnumerator ChangeColorTemporarily()
    {
        _numberTimes++;

        for (int i = 0; i < _numberTransfusions; i++)
        {
            _spriteRenderer.color = Color.red;

            yield return _waitForSeconds;

            _spriteRenderer.color = Color.white;

            yield return _waitForSeconds;
        }

        _numberTimes = 0;
        _isTakingDamage = false;
    }
}
