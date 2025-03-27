using System.Collections.Generic;
using UnityEngine;

public class HandlerTriggerPower : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public List<Health> EnemysInTrigger {  get; private set; }

    private void Awake()
    {
        SpriteCollisionToggle(false);

        EnemysInTrigger = new List<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out Health enemyHealth))
        {
            EnemysInTrigger.Add(enemyHealth);
        }
    }

    public void SpriteCollisionToggle(bool isActive)
    {
        _spriteRenderer.enabled = isActive;
    }

    public void ClearEnemysList()
    {
        Debug.Log("Отчистка");
        EnemysInTrigger.Clear();
    }
}
