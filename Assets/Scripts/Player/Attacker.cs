using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private int _damage = 1;

    private bool _isAttacking=false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out Health health) && _isAttacking==false)
        {
            if (_damage>0)
            {
                _isAttacking=true;
                health.TakeDamage(_damage);

                if (collision.TryGetComponent<DamageEffect>(out DamageEffect damageEffect))
                {
                    damageEffect.PlayDamageEffect();
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out Health _))
        {
            _isAttacking=false;
        }
    }
}
