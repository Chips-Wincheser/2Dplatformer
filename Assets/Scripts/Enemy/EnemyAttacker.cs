using System;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private EnemyMover _enemyMover;

    public event Action Attaced;

    private void OnEnable()
    {
        _enemyMover.CameClose+=GiveDamage;
    }

    private void OnDisable()
    {
        _enemyMover.CameClose-=GiveDamage;
    } 

    private void GiveDamage(bool isFarAway)
    {
        if(isFarAway)
        {
            Attaced?.Invoke();
        }
    }
}
