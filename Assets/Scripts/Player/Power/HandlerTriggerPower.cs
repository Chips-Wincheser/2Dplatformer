using System.Collections.Generic;
using UnityEngine;

public class HandlerTriggerPower : MonoBehaviour
{
    public List<Health> EnemysInTrigger {  get; private set; }

    private void Awake()
    {
        EnemysInTrigger = new List<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out Health enemyHealth))
        {
            EnemysInTrigger.Add(enemyHealth);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out Health enemyHealth))
        {
            EnemysInTrigger.Remove(enemyHealth);
        }
    }
}
