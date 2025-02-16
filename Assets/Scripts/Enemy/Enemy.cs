using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyAnimation _enemyAnimation;
    [SerializeField] private EnemyMover _enemyMover;

    private void OnEnable()
    {
        _enemyMover.CameClose+=OnPlayAttack;
    }

    private void OnDisable()
    {
        _enemyMover.CameClose-=OnPlayAttack;
    }

    private void OnPlayAttack(bool isFarAway)
    {
        _enemyAnimation.PlayAttack(isFarAway);
    }
}
