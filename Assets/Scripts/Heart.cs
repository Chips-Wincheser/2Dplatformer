using System;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public event Action<Heart> Collected;

    public void Collect()
    {
        Collected?.Invoke(this);
    }
}
