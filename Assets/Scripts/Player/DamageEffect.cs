using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DamageEffect : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private WaitForSeconds _waitForSeconds;

    private int _numberTransfusions = 3;
    private float _delay = 0.5f;
    private bool _isTakingDamage = false;


    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _waitForSeconds = new WaitForSeconds(_delay);
    }
    public void PlayDamageEffect()
    {
        if (!_isTakingDamage)
        {
            _isTakingDamage = true;
            StartCoroutine(ChangeColorTemporarily());
        }
    }

    private IEnumerator ChangeColorTemporarily()
    {
        for (int i = 0; i < _numberTransfusions; i++)
        {
            _spriteRenderer.color = Color.red;
            yield return _waitForSeconds;
            _spriteRenderer.color = Color.white;
            yield return _waitForSeconds;
        }

        _isTakingDamage = false;
    }
}
